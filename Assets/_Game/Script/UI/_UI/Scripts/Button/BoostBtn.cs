using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoostBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image img;

    private void OnEnable()
    {
        Debug.Log("C");
        img.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.gameObject.SetActive(true);
        Debug.Log("A");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
