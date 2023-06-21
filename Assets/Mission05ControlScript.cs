using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniGame.Manager;
public class Mission05ControlScript : MonoBehaviour //subtask missin update
{
    [Header ("Stage Complete")]
   public bool StageComplete;
    //Task1
    [Header("FirstAidKit")]
    [SerializeField] bool Task1;
    [SerializeField] GameObject _T1_FirstAidKit_HighLightIndicator;
    [SerializeField] bool Task1_1;
    [SerializeField] GameObject _T2_FirstAidKit_HighLightIndicator;
    [SerializeField] Objectives _T1_MNFirstAidComplete;
    [SerializeField] Objectives _T2_MNFirstAidComplete;
    [Header("FirstAidKit_TMP")]
    public TMPro.TextMeshProUGUI FirstAidKitTxt;
    public TMPro.TextMeshProUGUI FirstAidKitCount;
    Collider2D T1_FirstAidKit_Collider;
    Collider2D T2_FirstAidKit_Collider;


    //Task2
    [Header("FireExtinguisher")]
    [SerializeField] bool Task2;
    public GameObject FireExtinguisher_HighLightIndicator;
    [SerializeField] FireExtinguisherScript _MNFireExtinguisherComplete;
    [Header("FireExtinguisher_TMP")]
    public TMPro.TextMeshProUGUI FireExtinguisherTxt;
    public TMPro.TextMeshProUGUI FireExtinguisherCount;


    //Task3
    [Header("DropCoverHold")]
    [SerializeField] bool Task3;
    public GameObject DropCoverHold_HighLightIndicator;
    [SerializeField] DropCoverHoldTriggerTaskIsComplete _dropCoverHoldTriggerTaskIsComplete;

    [Header("DropCoverHold_TMP")]
    public TMPro.TextMeshProUGUI DropCoverHoldTxt;
    public TMPro.TextMeshProUGUI DropCoverHoldCount;


    

	private void Start()
	{
        T1_FirstAidKit_Collider = _T1_FirstAidKit_HighLightIndicator.GetComponent<Collider2D>();
        T2_FirstAidKit_Collider = _T2_FirstAidKit_HighLightIndicator.GetComponent<Collider2D>();
    }

	public void Check_Update()
	{
        SubTaskCheckComplition();

    }
	void SubTaskCheckComplition()
    {
        //task 1
        if (_T1_MNFirstAidComplete.isComplete ^ _T2_MNFirstAidComplete.isComplete == true)
        {
            FirstAidKitCount.text = "1/2";
            if (_T1_MNFirstAidComplete.isComplete == true)
			{
                Task1 = true;
                T1_FirstAidKit_Collider.enabled = false;
            }
            else if (_T2_MNFirstAidComplete.isComplete == true)
			{
                Task1_1 = true;
                T2_FirstAidKit_Collider.enabled = false;
            }
        }
        else if ((_T1_MNFirstAidComplete.isComplete == true ) && (_T2_MNFirstAidComplete.isComplete == true))
		{
            Task1 = true;
            Task1_1 = true;
            FirstAidKitTxt.color = new Color32(0, 0, 0, 90);// lower opacity
            FirstAidKitCount.color = new Color32(0, 0, 0, 90);// lower opacity
            FirstAidKitCount.text = "2/2";
            T1_FirstAidKit_Collider.enabled = false;
            T2_FirstAidKit_Collider.enabled = false;
        }


        //task2
        if (_MNFireExtinguisherComplete.Completed == true)
		{
            Task2 = true;
            FireExtinguisherTxt.color = new Color32(0, 0, 0, 90);// lower opacity
            FireExtinguisherCount.color = new Color32(0, 0, 0, 90);// lower opacity
            FireExtinguisherCount.text = "1/1";
            
        }

        //task3
        if (_dropCoverHoldTriggerTaskIsComplete.IsComplete == true)
		{
            Task3 = true;
            DropCoverHoldTxt.color = new Color32(0, 0, 0, 90);// lower opacity
            DropCoverHoldCount.color = new Color32(0, 0, 0, 90);// lower opacity
            DropCoverHoldCount.text = "1/1";
        }

        //Stage Complete
        if (Task1 && Task1_1 && Task2 && Task3)
		{
            StageComplete = true;
		}
    }

}
