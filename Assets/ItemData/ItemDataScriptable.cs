using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData"), Serializable]
public class ItemDataScriptable : ScriptableObject
{
    public Sprite itemImg;
    public bool isStackable;
    public bool isConsubale;
    public int maxStack;
    public string header;
    [TextArea]
    public string discription;
    public int price;
    static Dictionary<string, ItemDataScriptable> dataDictionary;
    private void OnEnable()
    {
        // Initialize the dictionary if it's null
        if (dataDictionary == null)
        {
            dataDictionary = new Dictionary<string, ItemDataScriptable>();
        }

        // Add this item to the dictionary if not already present
        if (!dataDictionary.ContainsKey(name))
        {
            dataDictionary.Add(name, this);
        }
        else
        {
            Debug.LogError("Repeated scrptable object name");
        }
    }

    // Static function to get ItemDataScriptable by name
    public static ItemDataScriptable GetByName(string itemName)
    {
        if (dataDictionary != null && dataDictionary.TryGetValue(itemName, out var item))
        {
            return item;
        }

        Debug.LogWarning($"ItemDataScriptable with name '{itemName}' not found.");
        return null;
    }

}
