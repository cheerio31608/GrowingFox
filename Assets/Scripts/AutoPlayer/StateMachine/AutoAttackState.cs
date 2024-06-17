using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttackState : AutoBaseState
{

    private bool alreadyAppliedForce;
    private bool alreadyAppliedDealing;

    public AutoAttackState(AutoPlayerStateMachine autoStateMachine) : base(autoStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.AutoPlayer.AnimationData.AttackParameterHash);
        StartAnimation(stateMachine.AutoPlayer.AnimationData.BaseAttackParameterHash);
        alreadyAppliedForce = false;
        alreadyAppliedDealing = false;
        stateMachine.MovementSpeedModifier = 0;
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.AutoPlayer.AnimationData.AttackParameterHash);
        StopAnimation(stateMachine.AutoPlayer.AnimationData.BaseAttackParameterHash);

    }

    public override void Update()
    {
        base.Update();

        ForceMove();

        float normalizedTime = GetNormalizedTime(stateMachine.AutoPlayer.Animator, "Attack");
        if (normalizedTime < 1f)
        {
            if (normalizedTime >= stateMachine.AutoPlayer.Data.ForceTransitionTime)
                TryApplyForce();

            if (!alreadyAppliedDealing && normalizedTime >= stateMachine.AutoPlayer.Data.Dealing_Start_TransitionTime)
            {
                stateMachine.AutoPlayer.Weapon.SetAttack(stateMachine.AutoPlayer.Data.Damage, stateMachine.AutoPlayer.Data.Force);
                stateMachine.AutoPlayer.Weapon.gameObject.SetActive(true);
                alreadyAppliedDealing = true;
            }

            if (alreadyAppliedDealing && normalizedTime >= stateMachine.AutoPlayer.Data.Dealing_End_TransitionTime)
            {
                stateMachine.AutoPlayer.Weapon.gameObject.SetActive(false);
            }

        }
        else
        {
            if (IsInChasingRange())
            {
                stateMachine.ChangeState(stateMachine.ChasingState);
                return;
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
                return;
            }
        }

    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        stateMachine.AutoPlayer.ForceReceiver.Reset();

        stateMachine.AutoPlayer.ForceReceiver.AddForce(Vector3.forward * stateMachine.AutoPlayer.Data.Force);
    }
}