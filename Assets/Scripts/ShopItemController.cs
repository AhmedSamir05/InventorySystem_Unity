using UnityEngine;
using UnityEngine.UI;

public class ShopItemController : MonoBehaviour
{
    [SerializeField] ItemDataScriptable itemDataScriptable;
    [SerializeField] TMPro.TextMeshProUGUI priceText, itemName;
    [SerializeField] Image itemImg;
    [SerializeField] int itemsNum = 1;

    void Awake()
    {
        itemName.text = itemDataScriptable.header;
        priceText.text = itemDataScriptable.price.ToString();
        itemImg.sprite = itemDataScriptable.itemImg;
    }

    public void BuyItem()
    {
        if (InventoryManager.instance.IsSlotAvailable(itemDataScriptable, itemsNum))
        {
            if (CoinManager.Instance.SpendCoins(itemDataScriptable.price)) 
            {
                InventoryManager.instance.AddItem(itemDataScriptable, itemsNum);
            }
            else
            {
                Debug.LogError("No coin available, Handle it through a feedback");
            }
        }
        else
        {
            Debug.LogError("No slots avilable");
        }
    }
}
