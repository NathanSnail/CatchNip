using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField]
    Input_handler input;
    public float sensitivity = 100f;
    public Transform player; // assign the parent "player"

    private float xRotation = 0f;
    private Vector2 lookInput;

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        float mouseX = lookInput.x * sensitivity * Time.deltaTime;
        float mouseY = lookInput.y * sensitivity * Time.deltaTime;

        // Vertical rotation (camera only)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.rotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal rotation (rotate whole player)
        player.Rotate(Vector3.up * mouseX);
    }
}