using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage02SubTaskMissions : MonoBehaviour
{

    public SubTasksIsSuccess _subTasksIsSuccess;
    public Stage02Complete _completeScript;

    //Task1
    [Header("CravatFolding")]
    public GameObject CravatFolding_HighLightIndicator;

    [Header("CravatFolding_TMP")]
    public TMPro.TextMeshProUGUI CravatFoldingTxt;
    public TMPro.TextMeshProUGUI CravatFoldingCount;

    //Task2
    [Header("SquareKnot")]
    public GameObject SquareKnot_HighLightIndicator;

    [Header("SquareKnot_TMP")]
    public TMPro.TextMeshProUGUI SquareKnotTxt;
    public TMPro.TextMeshProUGUI SquareKnotCount;


    //Task3
    [Header("LegCravat")]
    public GameObject LegCravat_HighLightIndicator;

    [Header("SquareKnot_TMP")]
    public TMPro.TextMeshProUGUI LegCravatTxt;
    public TMPro.TextMeshProUGUI LegCravatCount;

    //
    [SerializeField]
    //bool Stage02Completed = false;

    // Update is called once per frame
    public void Check_Update()
    {

        SubTaskCheckComplition();
        Stage02Completion();


    }


    void SubTaskCheckComplition()
	{
        
        //Task1
        if (_subTasksIsSuccess.MiniTask1Complete == true)
		{
            CravatFoldingTxt.color = new Color32(0, 0, 0, 90);// lower opacity
            CravatFoldingCount.text = "1/1";
            CravatFoldingCount.color = new Color32(0, 0, 0, 90);// lower opacity
        }
        //Task2
        if (_subTasksIsSuccess.MiniTask2Complete == true)
        {
            SquareKnotTxt.color = new Color32(0, 0, 0, 90);// lower opacity
            SquareKnotCount.text = "1/1";
            SquareKnotCount.color = new Color32(0, 0, 0, 90);// lower opacity
        }
        //Task3
        if (_subTasksIsSuccess.MiniTask3Complete == true)
        {
            LegCravatTxt.color = new Color32(0, 0, 0, 90);// lower opacity
            LegCravatCount.text = "1/1";
            LegCravatCount.color = new Color32(0, 0, 0, 90);// lower opacity
        }


    }

    void Stage02Completion()
	{
        if (_subTasksIsSuccess.MiniTask1Complete == true &&
            _subTasksIsSuccess.MiniTask2Complete == true &&
            _subTasksIsSuccess.MiniTask3Complete == true)
		        {
            _completeScript.CheckCompletion();


                }
    }

}

