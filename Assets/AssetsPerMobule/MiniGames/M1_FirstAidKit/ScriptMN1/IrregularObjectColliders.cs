using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IrregularObjectColliders : MonoBehaviour, IEndDragHandler
{
    public List<GameObject> tiles = new List<GameObject>();
    public GameObject[,] objColliders;
    public int ColumnsI, RowsI;
    int x;
    void Start()
    {

        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].GetComponent<ColliderLists>().iObjIndex = i;
        }
        objColliders = new GameObject[ColumnsI, RowsI];
        x = 0;
        for (int i = 0; i < ColumnsI; i++)
        {
            for (int j = 0; j < RowsI; j++)
            {
                objColliders[i, j] = tiles[x];
                tiles[x].GetComponent<ColliderLists>().collided.Clear();
                x++;
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].GetComponent<ColliderLists>().collided.Clear();
        }
    }
}
