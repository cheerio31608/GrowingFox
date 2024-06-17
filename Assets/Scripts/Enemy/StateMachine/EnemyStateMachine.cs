using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }
    //public Health Target { get; private set; }
    public AutoHealth Target { get; private set; }
    public EnemyIdleState IdleState { get; }
    public EnemyChasingState ChasingState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; }

    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;
        //Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<AutoHealth>();

        IdleState = new EnemyIdleState(this);
        ChasingState = new EnemyChasingState(this);
        AttackState = new EnemyAttackState(this);

        MovementSpeed = Enemy.Data.GroundData.BaseSpeed;
        RotationDamping = Enemy.Data.GroundData.BaseRotationDamping;
    }
}