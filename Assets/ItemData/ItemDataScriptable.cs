using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
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
}
