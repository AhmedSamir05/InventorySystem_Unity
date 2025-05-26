using UnityEngine;
using UnityEngine.EventSystems;

public class SlotController : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            DropItem(eventData);
        }
    }

    void DropItem(PointerEventData eventData)
    {
        ItemMovement itemController = eventData.pointerDrag.GetComponent<ItemMovement>();
        if (itemController == null)
            return;
        itemController.parentTransform = transform;
    }
}
