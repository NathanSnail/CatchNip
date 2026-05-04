using UnityEngine;

public class Kitchen : Puzzle
{
    public GameObject cat;
    private GameObject door_obj;

    public override GameObject getCat()
    {
        return cat;
    }

    public override bool isSolved()
    {
        Door door = door_obj.GetComponent<Door>();
        if (door.isOpen())
        {
            return true;
        }
        return false;
    }

    public override void resolve()
    {
        base.isResolved();
        Door door = door_obj.GetComponent<Door>();
        door.disable();
        return;
    }
}

public class Door : IInteractable
{
    public static float open_amount;
    public bool disabled;
    private bool open = false;

    public bool isOpen()
    {
        return open;
    }

    public void interact(GameObject x)
    {
        if (disabled)
        {
            return;
        }
        x.transform.Rotate(Vector3.up * (open ? -1 : 1) * open_amount * Time.deltaTime, Space.World); //open/close door
        open = !open;
    }

    public void disable()
    {
        disabled = true;
    }
}