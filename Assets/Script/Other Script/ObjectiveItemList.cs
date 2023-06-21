using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveItemList : MonoBehaviour
{
    [Header("Items List Objective")]

    [Header("FirstTask")]
    [Tooltip("TMPro content that will display the first item needed")]
    public TMPro.TextMeshProUGUI Task1;
    [Tooltip("TMPro Count Item Piece")]
    public TMPro.TextMeshProUGUI TaskCurrentItemCount;
    [Tooltip("TMPro Count Item Piece")]
    public TMPro.TextMeshProUGUI Task1ItemCountNeeded;


    public ObjectivesFirstAid ObjectiveMission; // itemcount needed
    public GridArray ObjectiveID; // items that are inside the box

   
    void Update()
    {
        
    }
}