using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    // Name of the slot this item belongs to
    string slotName = "";                
    int number;                         
    [SerializeField] ItemDataScriptable itemData; 
    [SerializeField] Image itemImg;     

    private void Awake()
    {
        LoadData();
    }

    public void SaveData(string parentName)
    {
        // Clear old saved data if any
        if (slotName != "")
        {
            PlayerPrefs.SetString(slotName, "");
        }

        slotName = parentName;

        // Save the item name and number to PlayerPrefs using the slot name as key
        PlayerPrefs.SetString(slotName, itemData.name);
        PlayerPrefs.SetInt(slotName + "_Number", number);
    }

    public void LoadData()
    {
        slotName = transform.parent.name;  // Get the slot name from the parent transform

        if (PlayerPrefs.HasKey(slotName))
        {
            string itemName = PlayerPrefs.GetString(slotName);
            // Load item data by name
            itemData = ItemDataScriptable.GetByName(itemName);
            // Update UI image sprite
            itemImg.sprite = itemData.itemImg;
            // Load saved number
            number = PlayerPrefs.GetInt(slotName + "_Number", number); 
        }
    }
}
