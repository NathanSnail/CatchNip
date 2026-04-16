using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor; 

public class Object : MonoBehaviour, IInteractable{

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
        Renderer r = x.GetComponent<Renderer>();
        r.material.shader = Shader.Find("EdgeOutline");
    }

    public void hide(GameObject x)
    {
        string path = "Packages/com.unity.render-pipelines.universal/Runtime/Materials/Lit.mat";
        x.GetComponent<Renderer>().material = AssetDatabase.LoadAssetAtPath<Material>(path);
    }
}