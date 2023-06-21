using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSlots : MonoBehaviour
{
    public List<GridFillerColliders> colliders = new List<GridFillerColliders>();
    public List<GameObject> collidersAsObjects = new List<GameObject>();
    public ItemGenerator objectID;


    void Start()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].Index = i;
        }
    }
}
