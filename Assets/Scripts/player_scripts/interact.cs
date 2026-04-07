using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    Input_handler input;
    public Toggle itemSlot;
    public bool interactable;
    public Camera camera;
    public float hitDistance;   //how far away before player can interact with object
    public int catCount;
    public bool catVisible;
    public TextMeshProUGUI countText; // Reference to your TMP component

    private Vector2 mousePos;
    private bool interactInput;

    void Start()
    {
        interactInput = false;
        itemSlot.isOn = false;
        catVisible = false;
        catCount = 0;
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

    public void OnCount(InputAction.CallbackContext context)
    {
        if (context.performed && catVisible){
            catCount += 1;
        }
    }

    void Update()
    {
        //using ray casting detect object player is looking at
        mousePos = Mouse.current.position.ReadValue(); 
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(mousePos);
        
        if (Physics.Raycast(ray, out hit)) {
            if(hit.distance < hitDistance){
                if (hit.transform.gameObject.CompareTag("interactable"))
                {
                    //if interactable object under mouse then highlight
                    interactable = true;
                }
                if (hit.transform.gameObject.CompareTag("cat"))
                {
                    catVisible = true;
                }
            }
            else
            {
                interactable = false;
                catVisible = false;
            }
        }

        //update cat counter
        if(catCount > 8)
        {
            catCount = 0;
        }
        countText.text = catCount.ToString();
    }
}