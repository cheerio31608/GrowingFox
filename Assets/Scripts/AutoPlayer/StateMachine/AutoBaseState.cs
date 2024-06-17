using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class AutoBaseState : IState
{
    protected AutoPlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;

    public AutoBaseState(AutoPlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
        groundData = stateMachine.AutoPlayer.Data.GroundData;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);

        Move(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 dir = (stateMachine.Target.transform.position - stateMachine.AutoPlayer.transform.position).normalized;
        return dir;
    }

    void Move(Vector3 movementDirection)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.AutoPlayer.Controller.Move(((movementDirection * movementSpeed) + stateMachine.AutoPlayer.ForceReceiver.Movement) * Time.deltaTime);
    }

    void Rotate(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            stateMachine.AutoPlayer.transform.rotation = Quaternion.Lerp(stateMachine.AutoPlayer.transform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    protected void ForceMove()
    {
        stateMachine.AutoPlayer.Controller.Move(stateMachine.AutoPlayer.ForceReceiver.Movement * Time.deltaTime);
    }


    private float GetMovementSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.AutoPlayer.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.AutoPlayer.Animator.SetBool(animationHash, false);
    }

    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }

    protected bool IsInChasingRange()
    {
        if (stateMachine.Target.IsDie) return false;

        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.AutoPlayer.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.AutoPlayer.Data.PlayerChasingRange * stateMachine.AutoPlayer.Data.PlayerChasingRange;
    }
}