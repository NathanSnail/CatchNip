using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    Input_handler input;
    public Toggle itemSlot;
    public bool interactable;
    public Camera camera;
    private Vector2 mousePos;
    private bool interactInput;

    void Start()
    {
        interactInput = false;
        itemSlot.isOn = false;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //toggled input
        interactInput = !interactInput;
        if (interactInput)
        {
            //try pick up thing
            itemSlot.isOn = true;
        }
        else
        {
            //put down thing
            itemSlot.isOn = false;
        }
    }

    void Update()
    {
        //using mouse position cast ray
        mousePos = Mouse.current.position.ReadValue(); 
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(mousePos);
        
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.gameObject.CompareTag("interactable"))
            {
                //if interatable object under mouse then highlight
                interactable = true;
            }
            else
            {
                interactable = false;
            }
        }
    }
}