using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public string acceptedTag;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            Debug.LogWarning("OnDrop: pointerDrag é null.");
            return;
        }

        DragAndDrop dropped = eventData.pointerDrag.GetComponent<DragAndDrop>();
        if (dropped == null)
        {
            Debug.LogWarning("OnDrop: O objeto arrastado não possui o componente DragAndDrop.");
            return;
        }

        if (dropped.correctTargetTag == acceptedTag)
        {
            dropped.transform.SetParent(transform);
            dropped.transform.position = transform.position;

            if (GameManager.Instance != null)
                {
                    GameManager.Instance.RegisterCorrectDrop();
                }
            else
            {
                Debug.LogError("GameManager.Instance está null! O GameManager precisa estar presente na cena.");
            }
                    }
                    else
                    {
                        Debug.Log("Objeto arrastado não corresponde ao slot. Esperado: " + acceptedTag + ", recebido: " + dropped.correctTargetTag);
                    }
                }
}
