using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;

using Stage080910;
public class TaskCompletePlugOnly : MonoBehaviour
{
    public bool TaskIsDone;
    [SerializeField] int TaskCount;
    [SerializeField] PlugConnection Plug;
    [SerializeField] CableConnector Cable;
    [SerializeField] GameObject CompleteAnim;
    [SerializeField] LevelGameplayManagerScript MainLevel;

    [SerializeField] bool Stage09;
    [SerializeField] CentralizeLevel09GameplayManagerScript CentralizeStage09;
    [SerializeField] Animator FanOverWorld;
    [SerializeField] Animator FanUI;
    [SerializeField] Overworld_ChargeThePhone _fan;
    public void checkTask()
    {
        if (Stage09)
        {
            if (Plug.IsPlugged == false)
            {
                TaskIsDone = true;
                StartCoroutine(DoThisWhenComplete());
            }
        }
    }

    IEnumerator DoThisWhenComplete()
    {
        yield return new WaitForSeconds(0.5f);
        CompleteAnim.SetActive(true);

        if (Stage09)
        {
            CentralizeStage09.MissionCol[TaskCount].enabled = false;
            MainLevel.PopUpMission[TaskCount].SetActive(false);
            if (Plug.IsElectricFan)//electricfan
            {
                FanOverWorld.enabled = false;
                FanUI.enabled = false;
                _fan.PhoneIsNotCharge();
            }
			if (Plug.IsATV)//tv
            {
                _fan.PhoneIsNotCharge();
			}
        }
        
        yield return new WaitForSeconds(2.9f);
        gameObject.SetActive(false);
        MainLevel.HideInspectMission();

        
    }
}
