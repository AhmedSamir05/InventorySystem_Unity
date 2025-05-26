using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemDataScriptable))]
public class ItemDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemDataScriptable itemData = (ItemDataScriptable)target;

        // Draw default sprite field with preview
        itemData.itemImg = (Sprite)EditorGUILayout.ObjectField("Item Image", itemData.itemImg, typeof(Sprite), false);


        // Stackable toggle
        itemData.isStackable = EditorGUILayout.Toggle("Is Stackable", itemData.isStackable);

        // Show max stack only if stackable
        if (itemData.isStackable)
        {
            itemData.maxStack = EditorGUILayout.IntField("Max Stack", itemData.maxStack);
        }

        itemData.header = EditorGUILayout.TextField("Header", itemData.header);

        EditorGUILayout.LabelField("Description");
        itemData.discription = EditorGUILayout.TextArea(itemData.discription, GUILayout.Height(60));

        itemData.price = EditorGUILayout.IntField("Price", itemData.price);

        // Mark as dirty so changes are saved
        if (GUI.changed)
        {
            EditorUtility.SetDirty(itemData);
        }
    }
}
