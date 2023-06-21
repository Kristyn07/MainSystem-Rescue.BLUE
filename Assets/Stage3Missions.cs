using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireExtinguisher.Animation;

public class Stage3Missions : MonoBehaviour
{

    [Header("Task 1")]
    [SerializeField] ExtinguisherClassesDragAndDrop _extinguisherClassesDragAndDrop;

    [Header("Items List Objective")]
    [Tooltip("Text content that will display the first item")]
    public TMPro.TextMeshProUGUI MN2_txt;
    [Tooltip("Text content that will display the first item")]
    public TMPro.TextMeshProUGUI MN2_count;


    [Header("GameObject Active Manipulation")]
    [Tooltip("Active Mini game (highlight)")]
    public GameObject MN2_HighLightIndicator;

    



    [Header("Task 2")]
    [SerializeField] FireExtinguisherAnimationScript _fireExtinguisherAnimationScript;

    [Header("Items List Objective")]
    [Tooltip("Text content that will display the first item")]
    public TMPro.TextMeshProUGUI MN1_txt;
    [Tooltip("Text content that will display the first item")]
    public TMPro.TextMeshProUGUI MN1_count;


    [Header("GameObject Active Manipulation")]
    [Tooltip("Active Mini game (highlight)")]
    public GameObject MN1_HighLightIndicator;

  

    
    void Start()
    {

    }

    void Update()
    {

    }

    public void SubTaskSucess()
    {
        if (_extinguisherClassesDragAndDrop.Completed == true)
        {
            MN2_count.text = "1/1";
            MN2_count.color = new Color32(0, 0, 0, 90);// lower opacity
            MN2_txt.color = new Color32(0, 0, 0, 90);// lower opacity
            MN2_HighLightIndicator.SetActive(false);


            Debug.Log("completedMN1");
        }

        if (_fireExtinguisherAnimationScript.TaskIsDone == true)
        {
            MN1_count.text = "1/1";
            MN1_count.color = new Color32(0, 0, 0, 90);// lower opacity
            MN1_txt.color = new Color32(0, 0, 0, 90);// lower opacity
            MN1_HighLightIndicator.SetActive(false);


            Debug.Log("completedMN2");
        }
    }
}

