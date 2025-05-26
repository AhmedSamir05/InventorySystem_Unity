using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemMovement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector] public Transform parentTransform;

    static ScrollRect rootScrollRect;
    RectTransform rt;
    CanvasGroup canvasGroup;

    IEnumerator Start()
    {
        // Get reference to the parent ScrollRect only once
        if (!rootScrollRect)
            rootScrollRect = transform.GetComponentInParents<ScrollRect>();

        rt = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Wait until end of frame to ensure layout is ready
        yield return new WaitForEndOfFrame();

        // Adjust scale to fit parent width
        ChangeScale(); 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentTransform = transform.parent;

        transform.parent.GetComponent<SlotController>().DeattachItem();

        // Temporarily reparent for drag
        transform.SetParent(rootScrollRect.transform, false);
        // Disable scrolling during drag
        rootScrollRect.enabled = false;
        // Stop object raycasts
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        // Follow mouse position
        transform.position = Input.mousePosition; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Return to original parent
        transform.SetParent(parentTransform, false);
        // Enable scrolling
        rootScrollRect.enabled = true;
        // Reset local position
        rt.anchoredPosition = Vector2.zero;
        // Enable raycasts
        canvasGroup.blocksRaycasts = true;
        ChangeScale(); 
    }

    void ChangeScale()
    {
        // Scale item to match the width of its parent
        float scale = transform.parent.GetComponent<RectTransform>().rect.width / rt.rect.width;
        transform.localScale = new Vector2(scale, scale);
    }
}
