using UnityEngine;
using UnityEngine.UI;

public class FallingObjectUI : MonoBehaviour
{
    [SerializeField] private Image[] fallingObjects;
    [SerializeField] private float fallSpeed = 1f;
    [SerializeField] private float fallDelay = 1f;

    private RectTransform canvasRect;

    private void Start()
    {
        canvasRect = GetComponent<RectTransform>();

        InvokeRepeating("FallObject", fallDelay, fallDelay);
    }

    private void FallObject()
    {
        Image randomObject = fallingObjects[Random.Range(0, fallingObjects.Length)];
        randomObject.rectTransform.anchoredPosition = new Vector2(Random.Range(-canvasRect.rect.width / 2f, canvasRect.rect.width / 2f), canvasRect.rect.height / 2f);
        randomObject.gameObject.SetActive(true);
    }

    private void Update()
    {
        foreach (Image obj in fallingObjects)
        {
            if (obj.gameObject.activeSelf)
            {
                obj.rectTransform.anchoredPosition += new Vector2(0, -fallSpeed * Time.deltaTime);

                /*if (obj.rectTransform.anchoredPosition.y < -canvasRect.rect.height / 2f)
                {
                    obj.gameObject.SetActive(false);
                }*/
            }
        }
    }
}
