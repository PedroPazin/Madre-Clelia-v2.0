using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{

    public void OnPointerEnter(Button button)
    {
        button.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0.97f, 0.27f, 0.25f, 1);
    }
    public void OnPointerExit(Button button)
    {
        button.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0.88f, 0.88f, 0.88f, 1);
    }
}
