using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoostBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image img;

    private void OnEnable()
    {
        img.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       img.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
