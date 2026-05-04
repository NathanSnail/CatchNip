using UnityEngine;
using UnityEngine.InputSystem;

public class Player_movement : MonoBehaviour
{
    [SerializeField]
    Input_handler input;
    public Rigidbody rb;
    public Transform cameraTransform;

    private Vector2 moveInput;
    public float speed = 0.8f;  //modify for faster/slower movement

    void Start()
    {
        Transform playerBody = transform.Find("player_body");
        float playerHeight = 0;

        if (playerBody != null)
        {
            MeshFilter meshFilter = playerBody.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                //gets player_body height from mesh to set y position correctly
                float bodyHeight = meshFilter.mesh.bounds.size.y * playerBody.localScale.y;
                playerHeight = (bodyHeight / 2) - playerBody.localPosition.y;
            }
        }

        //set initial player position
        transform.position = new Vector3(0, playerHeight, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();   //read input
    }

    void FixedUpdate()
    {
        Vector3 input = new Vector3(moveInput.x, 0, moveInput.y);

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * input.z + right * input.x;

        rb.linearVelocity = new Vector3(
            move.x * speed,
            rb.linearVelocity.y,
            move.z * speed
        );
    }
}
