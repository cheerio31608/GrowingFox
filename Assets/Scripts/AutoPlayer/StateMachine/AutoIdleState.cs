public class AutoIdleState : AutoBaseState
{
    public AutoIdleState(AutoPlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;

        base.Enter();
        StartAnimation(stateMachine.AutoPlayer.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.AutoPlayer.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.AutoPlayer.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.AutoPlayer.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (IsInChasingRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
            return;
        }
    }
}

