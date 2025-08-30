using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class byttontexthvper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText; 
    public Color normalColor = Color.grey;
    public Color hoverColor = Color.red;

    [SerializeField] private gotonextscene gotonextscene;

    void Start()
    {
        buttonText.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!gotonextscene.starting)
        {
            buttonText.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!gotonextscene.starting)
        {
            buttonText.color = normalColor;
        }
    }
}