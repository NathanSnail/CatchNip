using UnityEngine;
using UnityEngine.InputSystem;

public class Input_handler : MonoBehaviour
{
    [SerializeField]    
    private PlayerInput playerInput;
    public Vector2 moveInput;
    public bool interactInput;

    InputAction moveAction;
    InputAction interactAction;

    void Start()
    {
        moveAction = playerInput.actions["Move"];
        interactAction = playerInput.actions["Interact"];
    }

    void Update()
    {
        interactInput = interactAction.ReadValue<bool>();
        moveInput = moveAction.ReadValue<Vector2>();
    }
}
