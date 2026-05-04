using System;
using Unity.VisualScripting;
using UnityEngine;

public class LibraryBooks : Puzzle
{
    public GameObject books;
    //public GameObject cat;

    public override GameObject getCat()
    {
        return null; //cat;
    }

    public override bool isSolved()
    {
        foreach (Transform book_obj in books.transform)
        {
            Book book = book_obj.gameObject.GetComponent<Book>();
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
        foreach (Transform book_obj in books.transform)
        {
            Book book = book_obj.gameObject.GetComponent<Book>();
            book.disable();
        }
    }
}

