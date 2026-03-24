using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    Input_handler input;

    float playerHeight = 0;
    public float speed = 0.8f;  //modify for faster/slower movement

    void Start()
    {
        //gets player_body height from mesh to set y position correctly
        Transform playerBody = transform.Find("player_body");
        if (playerBody != null)
        {
            MeshFilter meshFilter = playerBody.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                float bodyHeight = meshFilter.mesh.bounds.size.y * playerBody.localScale.y;
                playerHeight = (bodyHeight / 2) - playerBody.localPosition.y;
            }
        }

        //set initial player position
        transform.position = new Vector3(0, playerHeight, 0);
    }

    void Update()
    {
        transform.Translate(new Vector3(input.moveInput.x, 0, input.moveInput.y) * speed * Time.deltaTime);
    }
}
