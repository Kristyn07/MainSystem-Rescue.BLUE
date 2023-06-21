using UnityEngine;
using UnityEngine.UI;

public class GridLayoutRandomizer : MonoBehaviour
{
    private GridLayoutGroup gridLayout;

    private void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        RandomizeGridLayout();
    }

    public void RandomizeGridLayout()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            int randomIndex = Random.Range(i, childCount);
            transform.GetChild(i).SetSiblingIndex(randomIndex);
        }
    }
}
