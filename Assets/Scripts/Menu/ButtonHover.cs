using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{

    public void OnPointerEnter(Button button)
    {
        var text = button.GetComponentInChildren<TextMeshProUGUI>();
        var color = text.color;
        var hoverColor = new Color(0.97f, 0.27f, 0.25f, 1);
        LeanTween.value(button.gameObject, color, hoverColor, 0.1f).setOnUpdate((Color val) =>
        {
            text.faceColor = val;
        });
    }
    public void OnPointerExit(Button button)
    {
        var text = button.GetComponentInChildren<TextMeshProUGUI>();
        var color = text.color;
        var hoverColor = new Color(0.89f, 0.89f, 0.89f, 1);
        LeanTween.value(button.gameObject, color, Color.white, 0.1f).setOnUpdate((Color val) =>
        {
            text.faceColor = val;
        }).setLoopClamp().setRepeat(1);
    }
}
