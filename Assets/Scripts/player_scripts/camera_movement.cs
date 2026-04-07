using UnityEngine;
using UnityEngine.InputSystem;

public class Camera_movement : MonoBehaviour
{
    [SerializeField]
    Input_handler input;

    [SerializeField]
    public Transform playerBody; 

    public float mouseSensitivity = 0.15f;  //modify for mouse sens
    private Vector2 lookInput;
    private float rotationPitch = 0f; 

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
        //accumulate rotation over time
        rotationPitch -= lookInput.y * mouseSensitivity * Time.deltaTime;    // Note: Y is inverted
        rotationPitch = Mathf.Clamp(rotationPitch, -90f, 90f);               //make sure doesn't flip if mouse goes too far

        transform.localRotation = Quaternion.Euler(rotationPitch, 0, 0);                     //up/down
        playerBody.Rotate(Vector3.up * lookInput.x * mouseSensitivity * Time.deltaTime);     //left/right (linked to player body)
        
    }
}
