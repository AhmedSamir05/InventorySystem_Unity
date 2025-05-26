using System.Collections;
using UnityEngine;
[DefaultExecutionOrder(2000)]
public class InventoryManager : MonoBehaviour
{
    SlotController [] slotController;
    public static InventoryManager instance;
    [SerializeField] GameObject slotsHolder;
    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        slotController = slotsHolder.GetComponentsInChildren<SlotController>();
    }


    public bool IsSlotAvailable(ItemDataScriptable item, int number = 1)
    {
        foreach (SlotController slot in slotController)
        {
            ItemController itemController = slot.itemcontroller;

            // If the slot is empty
            if (itemController == null)
                return true;

            // If the item is stackable and the same type, and adding won't exceed the max stack
            if (item.isStackable &&
                itemController.itemData == item &&
                itemController.number + number <= item.maxStack)
            {
                return true;
            }
        }

        return false;
    }

    public void AddItem(ItemDataScriptable item, int number = 1)
    {
        foreach (SlotController slot in slotController)
        {
            ItemController itemController = slot.itemcontroller;

            // If the slot is empty
            if (itemController == null)
            {
                print(item.name);
                slot.AddItem(item, number);
                break;
            }
            // If the item is stackable and the same type, and adding won't exceed the max stack
            if (item.isStackable &&
                itemController.itemData == item &&
                itemController.number + number <= item.maxStack)
            {
                slot.AddItem(item, number);
                break;
            }
        }
    }

}
