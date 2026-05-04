using UnityEditor.Animations;
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

    private static void set_layer(GameObject x, string layer)
    {
        x.gameObject.layer = LayerMask.NameToLayer(layer);
        for (int i = 0; i < x.transform.childCount; i++)
        {
            Transform child = x.transform.GetChild(i);
            set_layer(child.gameObject, layer);
        }
    }
    public void show(GameObject x)
    {
        set_layer(x, "Outlined Objects");
    }

    public void hide(GameObject x)
    {
        set_layer(x, "Default");
    }
}