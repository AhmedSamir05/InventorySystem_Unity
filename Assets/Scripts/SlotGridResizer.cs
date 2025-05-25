using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class SlotGridResizer : MonoBehaviour
{
    private GridLayoutGroup gridLayout;
    private RectTransform rectTransform;

    void Awake()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void Resize()
    {
        int childCount = transform.childCount;
        if (childCount == 0) 
            return;

        // Calculate how many columns can fit in the current width
        int columns = Mathf.Max(1, Mathf.FloorToInt(
            (rectTransform.rect.width - gridLayout.padding.left - gridLayout.padding.right + gridLayout.spacing.x) /
            (gridLayout.cellSize.x + gridLayout.spacing.x)
        ));

        // Determine number of rows needed to fit all children
        int rows = Mathf.CeilToInt((float)childCount / columns);

        // Calculate total height with padding and spacing
        float totalHeight =
            gridLayout.padding.top +
            gridLayout.padding.bottom +
            rows * gridLayout.cellSize.y +
            (rows - 1) * gridLayout.spacing.y;

        // Apply the new height to the RectTransform
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, totalHeight);
    }
}
