using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTasksIsSuccess : MonoBehaviour
{


    //Task1
    [Header("CravatFolding")]
    public CravatNarrowFolding _cravatNarrowFolding;
    public bool MiniTask1Complete = false;
    public GameObject Task1;


    //Task2
    [Header("SquareKnot")]
    public StepByStepBandaging _squareKnotBandagingAnimationController;
    public bool MiniTask2Complete = false;
    public GameObject Task2;

    //Task3
    [Header("LegCravat")]
    public LegCravatMiniTask.LegCravatStepsController _legCravatStepsController;
    public bool MiniTask3Complete = false;
    public GameObject Task3;

    

    public void Task_1()
	{
        // MiniTask1Complete = _cravatNarrowFolding.isSuccess;
        MiniTask1Complete = true;
    }
    public void Task_2()
    {
        //MiniTask2Complete = _squareKnotBandagingAnimationController.isSuccess;
        MiniTask2Complete = true;
    }
    public void Task_3()
    {
        //MiniTask3Complete = _legCravatStepsController.IsSuccess; 
        MiniTask3Complete = true;
    }
}
