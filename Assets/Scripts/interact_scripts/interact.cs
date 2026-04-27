using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField] Input_handler input;
    public Toggle item_slot; //checkbox
    public TextMeshProUGUI countText; // Reference to counting text
    public Camera player_camera;
    public float hitDistance;   //how far away before player can interact with object
    public bool interactable;
    public bool catVisible; //temp

    private Vector2 mousePos;
    private bool interactInput;
    private int catCount;//temp
    private static GameObject target;

    void Start()
    {
        interactInput = false;
        catVisible = false;//temp
        catCount = 0;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        target?.GetComponent<IInteractable>().interact(target);
    }

    public void OnCount(InputAction.CallbackContext context)//temp
    {
        if (context.performed && catVisible)
        {
            catCount += 1;
        }
    }

    void Update()
    {
        //using ray casting detect object player is looking at
        GameObject newTarget = Search();

        if (newTarget is not null)
        {
            catVisible = newTarget.CompareTag("cat");  //temp

            //check for interactable
            if (newTarget.TryGetComponent(out IInteractable myInterface))
            {
                target?.GetComponent<IInteractable>().hide(target);     //stop highlighting prev target
                myInterface.show(newTarget);
                target = newTarget;                                     //set new targetas current one
            }
            else
            {
                target?.GetComponent<IInteractable>().hide(target);     //stop highlighting prev target
                target = null;
            }

        }
        else
        { //if no targets

            catVisible = false;//temp
            target?.GetComponent<IInteractable>().hide(target);         //stop highlighting prev target
            target = null;

        }

        //temp
        //update cat counter
        if (catCount > 8)
        {
            catCount = 0;
        }
        countText.text = catCount.ToString();
    }

    private GameObject Search()
    {
        //using ray casting detect object player is looking at
        mousePos = Mouse.current.position.ReadValue();
        RaycastHit hit;
        Ray ray = player_camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out hit) && (hit.distance < hitDistance))
        {
            return hit.transform.gameObject;
        }
        else
        {
            return null;
        }
    }
}