using UnityEngine;
using UnityEngine.InputSystem;

public class Input_handler : MonoBehaviour
{
    [SerializeField]    
    private PlayerInput playerInput;
    public Vector2 moveInput;
    public Vector2 lookInput;
    public float interactInput;

    InputAction moveAction;
    InputAction lookAction;
    InputAction interactAction;

    void Start()
    {
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        interactAction = playerInput.actions["Interact"];
    }

    void Update()
    {
        interactInput = interactAction.ReadValue<float>();
        moveInput = moveAction.ReadValue<Vector2>();
        lookInput = lookAction.ReadValue<Vector2>();
    }
}
