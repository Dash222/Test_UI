using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    private int nbPanel = 0;
    private int currentPanelIndex = 0;

    private void Start()
    {
        panelLocation = transform.position;
        nbPanel = transform.childCount;
    }
    #region Drag Methods
    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.y - data.position.y;
        transform.position = panelLocation - new Vector3(0, difference, 0);
    }

    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.y - data.position.y) / Screen.height;

        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;

            // Avoid to swipe into a non panel zone
            if (percentage > 0 && currentPanelIndex > 0)
            {
                currentPanelIndex--;
                newLocation += new Vector3(0, -Screen.height, 0);
            }
            else if (percentage < 0 && currentPanelIndex < nbPanel - 1)
            {
                currentPanelIndex++;
                newLocation += new Vector3(0, Screen.height, 0);
            }

            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }
    #endregion

    #region Page Up/Down Methods
    public void PageUp()
    {
        if (currentPanelIndex > 0)
        {
            Vector3 newLocation = panelLocation;
            newLocation += new Vector3(0, -Screen.height, 0);

            currentPanelIndex--;
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
    }

    public void PageDown()
    {
        if (currentPanelIndex < nbPanel - 1)
        {
            currentPanelIndex++;
            Vector3 newLocation = panelLocation;
            newLocation += new Vector3(0, Screen.height, 0);

            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
    }
    #endregion

    #region Utility Methods
    public IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float seconds)
    {
        float t = 0f;

        while (t <= 1.0f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }
    }
    #endregion
}
