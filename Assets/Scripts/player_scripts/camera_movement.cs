using UnityEngine;
using UnityEngine.InputSystem;

public class camera_movement : MonoBehaviour
{
    [SerializeField]
    Input_handler input;

    public Transform playerBody;    
    public float mouseSensitivity = 0.15f;  //modify for mouse sens
    private Vector2 lookInput;

    void Start()
    {
        playerBody = GameObject.Find("player").transform;

        //lock cursor and hide
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();   //read input
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(lookInput.y * mouseSensitivity, 0, 0); //up/down
        playerBody.Rotate(Vector3.up * lookInput.x * mouseSensitivity);                   //left/right (linked to player body)
    }
}
