using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedMiniGame : MonoBehaviour
{
    [Header("Items List Objective")]
    [Tooltip("Text content that will display the first item")]
    public TMPro.TextMeshProUGUI MN1_txt;

    [Tooltip("Text content that will display the first item")]
    public TMPro.TextMeshProUGUI MN1_count;


    [Header("GameObject Active Manipulation")]
    [Tooltip("Active Mini game (highlight)")]
    public GameObject MN1_HighLightIndicator;

    

    [Header("Objective>MN")]
    public Objectives completedMN1;


    [Header("BandagingMiniGame")]
    public TaskIsComplete _taskIsComplete;
    public TMPro.TextMeshProUGUI MN3_txt;
    public TMPro.TextMeshProUGUI MN3_count;
    public GameObject MN3_HighLightIndicator;
    //GetComponent<TMPro.TextMeshProUGUI>().text

    [SerializeField] StageComplete _completeAll;


    
    // Update is called once per frame
    public void Check_Update()
    {
        if (completedMN1.isComplete == true)
        {
            MN1_count.text = "1/1";
            MN1_count.color = new Color32(0, 0, 0, 90);// lower opacity
            MN1_txt.color = new Color32(0, 0, 0, 90);// lower opacity
            MN1_HighLightIndicator.SetActive(false);
            

            Debug.Log("completedMN1");    
        }


        if (_taskIsComplete.isComplete == true)
		{

            MN3_count.text = "1/1";
            MN3_count.color = new Color32(0, 0, 0, 90);// lower opacity
            MN3_txt.color = new Color32(0, 0, 0, 90);// lower opacity
            MN3_HighLightIndicator.SetActive(false);

            
            Debug.Log("completedMN3");
        }
        if ((completedMN1.isComplete == true)&& (_taskIsComplete.isComplete == true))
		{
            _completeAll.CheckCompletion();
            
        }


    }
}
