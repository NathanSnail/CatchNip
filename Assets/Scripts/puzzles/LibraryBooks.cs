using UnityEngine;

public class LibraryBooks : Puzzle
{
    public GameObject[] books;
    public GameObject cat;

    public override bool isSolved()
    {
        foreach (GameObject book_obj in books)
        {
            Book book = book_obj.GetComponent<Book>();
            if (book.getPulled() != book.cat)   //if all catbooks are pulled and all normalbooks are not
            {
                return false;
            }
        }
        return true;
    }

    public override void resolve()
    {
        base.resolve();
        foreach (GameObject book_obj in books)
        {
            Book book = book_obj.GetComponent<Book>();
            book.disable();
        }
    }

    public override GameObject getCat()
    {
        return cat;
    }
}

public class Book : MonoBehaviour, IInteractable
{
    public bool cat;    //set in inspector
    public bool disabled;
    public static float pull_amount;
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