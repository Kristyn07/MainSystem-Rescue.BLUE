using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectiveFirstAidKit : MonoBehaviour
{
    public GridArray gridArray;
    public Objectives completeIt;
    public List<int> objectiveCounts;
    public GameObject activeWindow;
    public GameObject currentWindow;
    public GridFillerColliders[] colliders;
    void Start()
    {

    }
    void Update()
    {
        foreach (GridFillerColliders a in colliders)
        {
            gridArray.boxFilled = true;
            if (a.isFilled == true)
            {
                gridArray.boxFilled = true;
            }
            else if (a.isFilled == false)
            {
                gridArray.boxFilled = false;
                break;
            }
        }
        if (gridArray.boxFilled && !completeIt.isComplete)
        {
            gridArray.CheckCompletion();
        }
    }
    public void Complete()
    {
        completeIt.isComplete = true;
        currentWindow.SetActive(false);
        activeWindow.SetActive(true);
    }
}
