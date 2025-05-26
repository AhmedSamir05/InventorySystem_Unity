using UnityEngine;
using UnityEngine.UI;

public class ShopItemController : MonoBehaviour
{
    [SerializeField] ItemDataScriptable itemDataScriptable;
    [SerializeField] TMPro.TextMeshProUGUI priceText, itemName;
    [SerializeField] Image itemImg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        itemName.text = itemDataScriptable.header;
        priceText.text = itemDataScriptable.price.ToString();
        itemImg.sprite = itemDataScriptable.itemImg;
    }
}
