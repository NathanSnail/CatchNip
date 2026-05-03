using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hoverable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite hovered;
    [SerializeField] Sprite unhovered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hi");
        Image img = gameObject.GetComponent<Image>();
        img.sprite = hovered;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Image img = gameObject.GetComponent<Image>();
        img.sprite = unhovered;
    }
}
