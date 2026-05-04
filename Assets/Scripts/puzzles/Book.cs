using UnityEngine;

public class Book : MonoBehaviour, IInteractable
{
    public bool cat;    //set in inspector
    public bool disabled;
    private static float pull_amount = 1;
    private bool pulled = false;

    public void interact(GameObject x)
    {
        if (disabled)
        {
            return;
        }

        //need to connect w gameobject
        Vector3 movement = (pulled ? -1 : 1) * Book.pull_amount * transform.forward; //move book in/out
        pulled = !pulled;
    }

    public bool getPulled()
    {
        return pulled;
    }

    public void disable()
    {
        disabled = true;
    }
}