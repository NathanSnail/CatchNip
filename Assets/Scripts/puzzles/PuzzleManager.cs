using System;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    //list puzzles here
    public LibraryBooks library_books;
    private int cats_found;

    public void Update()
    {
        puzzleApply(puzzle =>
        {
            if (!puzzle.isResolved() && puzzle.isSolved())  //check which puzzles done
            {
                puzzle.resolve();
                cats_found++;                               //update counter

                GameObject cat_obj = puzzle.getCat();
                Cat cat = cat_obj.GetComponent<Cat>();
                cat.play();                                 //play cat animation
            }
        });
    }

    void puzzleApply(Action<Puzzle> fn)
    {
        fn(library_books);
        //list out puzzles like this
    }
}