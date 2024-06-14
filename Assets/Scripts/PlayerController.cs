using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInputs { get; private set; }
    public PlayerInput.PlayerActions playerActions { get; private set; }

    private void Awake()
    {
        playerInputs = new PlayerInput();
        playerActions = playerInputs.Player;
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
}