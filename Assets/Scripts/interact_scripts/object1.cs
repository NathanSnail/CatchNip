using UnityEngine;

//temp
public class Object : MonoBehaviour, IInteractable
{

    public void interact(GameObject x)
    {
        x.transform.Translate(new Vector3(0, 0, 1));
    }

}

public interface IInteractable
{
    public void interact(GameObject x);

    public void show(GameObject x)
    {
        x.layer = LayerMask.NameToLayer("Outlined Objects");
    }

    public void hide(GameObject x)
    {
        x.layer = LayerMask.NameToLayer("Default");
    }
}