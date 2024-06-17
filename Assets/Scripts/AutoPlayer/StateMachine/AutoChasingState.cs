public class AutoChasingState : AutoBaseState
{
    public AutoChasingState(AutoPlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1;
        base.Enter();
        StartAnimation(stateMachine.AutoPlayer.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.AutoPlayer.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.AutoPlayer.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.AutoPlayer.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsInChasingRange())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
        else if (IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
    }

    protected bool IsInAttackRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.AutoPlayer.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.AutoPlayer.Data.AttackRange * stateMachine.AutoPlayer.Data.AttackRange;
    }
}