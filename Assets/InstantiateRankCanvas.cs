using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRankCanvas : MonoBehaviour
{
    public GameObject RankImageObj;
    //public Transform Position;
    string canvasName = "MainCanvas";
    public void InstantiateRankOnClick()
	{
        

        // Find the canvas object with the specified name
        GameObject canvasObj = GameObject.FindWithTag(canvasName);
        if (canvasObj == null)
        {
            Debug.LogError("Canvas object not found!");
            return;
        }
        // Instantiate the RankImageObj prefab as a child of the canvas object
        /* GameObject newRankImage = Instantiate(RankImageObj) as GameObject;
         newRankImage.transform.SetParent(canvasObj.transform, false);*/
        GameObject newRankImage = Instantiate(RankImageObj, canvasObj.transform);
    }
}
