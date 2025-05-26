using UnityEngine;
using UnityEngine.EventSystems;

public class SlotController : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject itemPrefab;

    public void OnDrop(PointerEventData eventData)
    {
        // Only allow drop if this slot has no child item
        if (transform.childCount == 0)
        {
            DropItem(eventData);
        }
    }

    void DropItem(PointerEventData eventData)
    {
        ItemMovement itemMovement = eventData.pointerDrag.GetComponent<ItemMovement>();
        if (itemMovement == null)
            return;

        // Set this slot as the parent of the dropped item
        itemMovement.parentTransform = transform;

        // Save the slot name in the item's data for persistence
        itemMovement.GetComponent<ItemController>().SaveData(gameObject.name);
    }

    private void Start()
    {
        // If PlayerPrefs contains a saved item for this slot, instantiate it
        if (PlayerPrefs.GetString(gameObject.name, "") != "")
        {
            Instantiate(itemPrefab, transform);

        }
    }
}
