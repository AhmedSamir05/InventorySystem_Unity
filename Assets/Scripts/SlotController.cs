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
        eventData.pointerDrag.GetComponent<ItemController>().parentTransform = transform;
    }
}
