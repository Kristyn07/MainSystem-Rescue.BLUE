using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingCredits : MonoBehaviour 
{
    public float scrollSpeed = 20f;
    public RectTransform contentRect;

    private void Start()
    {
        // Start the scrolling animation
        ScrollCredits();
    }

    private void ScrollCredits()
    {
        // Calculate the target position
        float targetPosition = contentRect.rect.height;

        // Move the credits from bottom to top
        StartCoroutine(AnimateScroll(targetPosition));
    }

    private IEnumerator AnimateScroll(float targetPosition)
    {
        float currentPos = 0f;

        while (currentPos < targetPosition)
        {
            currentPos += scrollSpeed * Time.deltaTime;
            contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, currentPos);
            yield return null;
        }

        // Reset the position of the credits to the bottom
        contentRect.anchoredPosition = Vector2.zero;

        // Restart the scrolling animation
        ScrollCredits();
    }
}
