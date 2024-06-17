using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }
    public PlayerController Input { get; private set; }
    public CharacterController Controller { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }
    public Health health { get; private set; }

    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponent<Animator>();
        Input = GetComponent<PlayerController>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();
        health = GetComponent<Health>();
        stateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
        health.OnDie += OnDie;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    void OnDie()
    {
        Animator.SetTrigger("Die");
        Debug.Log("Die");
        enabled = false;
    }
}