using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayerStateMachine : StateMachine
{
    public AutoPlayer AutoPlayer { get; }
    public EnemyHealth Target { get; private set; }
    public AutoIdleState IdleState { get; }
    public AutoChasingState ChasingState { get; private set; }
    public AutoAttackState AttackState { get; private set; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; }

    public AutoPlayerStateMachine(AutoPlayer autoPlayer)
    {
        this.AutoPlayer = autoPlayer;
        Target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();

        IdleState = new AutoIdleState(this);
        ChasingState = new AutoChasingState(this);
        AttackState = new AutoAttackState(this);

        MovementSpeed = AutoPlayer.Data.GroundData.BaseSpeed;
        RotationDamping = AutoPlayer.Data.GroundData.BaseRotationDamping;
    }
}

