using UnityEngine;

abstract public class Puzzle : MonoBehaviour
{
    private bool resolved = false;

    public abstract bool isSolved();
    public abstract GameObject getCat();

    public virtual void resolve()
    {
        resolved = true;
    }

    public bool isResolved()
    {
        return resolved;
    }
}