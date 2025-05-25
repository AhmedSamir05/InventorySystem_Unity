using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotsCreator : MonoBehaviour
{
    public static SlotsCreator instance;
    [SerializeField, Range(5, 100)] int rowNum;  
    [SerializeField, Range(5, 15)] int columnNum;
    [SerializeField] Transform slotsHolderTransform;
    [SerializeField] GameObject slotPrefab;
    void Awake()
    {
        instance = this;
    }

    IEnumerator Start()
    {
        // Wait a frame before start
        yield return new WaitForEndOfFrame();
        UpdateSlots();
    }

    [ContextMenu("Regenerate Slots")]
    public void UpdateSlots()
    {
        SetGridDimensions();

        CreateSlots();

        // Resize the hight to show all the content.
        GetComponentInChildren<SlotGridResizer>().Resize();
    }

    private void CreateSlots()
    {
        // Create slots in a grid pattern.
        for (int i = 0; i < rowNum; i++)
        {
            for (int j = 0; j < columnNum; j++)
            {
                // Instanitiate and set the parent
                GameObject createdSlot = Instantiate(slotPrefab, slotsHolderTransform);
                //Renaming the object
                createdSlot.name = $"{slotPrefab.name}_{i}_{j}";
            }
        }
    }

    private void SetGridDimensions()
    {
        // Set the cell size for the grid layout based on the number of columns and the grid parameters
        GridLayoutGroup gridLayout = slotsHolderTransform.gameObject.GetComponent<GridLayoutGroup>();
        
        if (!gridLayout)
            Debug.LogError("GridLayoutGroup component not found.");
        RectTransform slotRectTransform = slotsHolderTransform.GetComponent<RectTransform>();

        float parentWidth = (slotRectTransform.rect.max - slotRectTransform.rect.min).x;
        float paddingHorizontal = gridLayout.padding.left + gridLayout.padding.right;
        float totalSpacing = gridLayout.spacing.x * (columnNum - 1);

        float width = (parentWidth - paddingHorizontal - totalSpacing) / columnNum;

        gridLayout.cellSize = new Vector2(width, width);
    }
}
