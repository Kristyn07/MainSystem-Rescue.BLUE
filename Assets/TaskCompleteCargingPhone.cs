using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;
using Stage080910;
public class TaskCompleteCargingPhone : MonoBehaviour
{
    public bool TaskIsDone;
    [SerializeField] int TaskCount;
    [SerializeField] PlugConnection Plug;
    [SerializeField] CableConnector Cable;
    [SerializeField] GameObject CompleteAnim;
    [SerializeField] LevelGameplayManagerScript MainLevel;
    [Header("Centralize Stage")]
    [SerializeField] CentralizeLevel08GameplayManagerScript CentralizeStage08;
    [SerializeField] bool Stage09;
    [SerializeField] CentralizeLevel09GameplayManagerScript CentralizeStage09;
    [SerializeField] Overworld_ChargeThePhone CompleteStateInOverWorld;

    public void checkTask()
    {
        if (Stage09)
		{
            if (Plug.IsPlugged == false && Cable.IsConnected == false)
            {
                TaskIsDone = true;
                StartCoroutine(DoThisWhenComplete());
            }
        }
		else //stage08
		{
            if (Plug.IsPlugged == true && Cable.IsConnected == true)
            {
                TaskIsDone = true;
                StartCoroutine(DoThisWhenComplete());
            }
        }//stage08

    }


    IEnumerator DoThisWhenComplete()
    {
        CompleteAnim.SetActive(true);
        if (Stage09){
            CentralizeStage09.MissionCol[TaskCount].enabled = false;
            //CompleteStateInOverWorld.PhoneIsNotCharge();
            MainLevel.PopUpMission[TaskCount].SetActive(false);
        }
		else // stage08
		{
            CentralizeStage08.MissionCol[TaskCount].enabled = false;
            MainLevel.PopUpMission[TaskCount].SetActive(false);
        }// stage08

        yield return new WaitForSeconds(2.9f);
        gameObject.SetActive(false);
        MainLevel.HideInspectMission();
    }
}
