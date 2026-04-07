using UnityEngine;
using UnityEngine.InputSystem;

public class Input_handler : MonoBehaviour
{
    [SerializeField]    
    private PlayerInput playerInput;
    public Vector2 moveInput;
    public Vector2 lookInput;
    public float interactInput;
    public float countInput;

    InputAction moveAction;
    InputAction lookAction;
    InputAction interactAction;
    InputAction countAction;

    void Start()
    {
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        interactAction = playerInput.actions["Interact"];
        countAction = playerInput.actions["Count"];
    }

    void Update()
    {
        interactInput = interactAction.ReadValue<float>();
        moveInput = moveAction.ReadValue<Vector2>();
        lookInput = lookAction.ReadValue<Vector2>();
        countInput = countAction.ReadValue<float>();
    }
}
