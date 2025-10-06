using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDrag : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private RectTransform dragRectTransform;
    private Canvas canvas;

    void Awake()
    {
        if (dragRectTransform == null)
        {
            dragRectTransform = transform.parent.GetComponent<RectTransform>();
        }

        if (canvas == null)
        {
            Transform testCanvas = transform.parent;
            while (testCanvas != null)
            {
                canvas = testCanvas.GetComponent<Canvas>();
                if (canvas != null)
                {
                    break;
                }
                testCanvas = testCanvas.parent;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }
}
