using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;
public class TaskCompleteDrainage : MonoBehaviour
{
    public bool TaskIsDone;

    [SerializeField] CheckWasteIfIsInTheRightTrashBin[] _chechwaste;
    [SerializeField] GameObject CompleteAnim;
    [SerializeField] LevelGameplayManagerScript MainLevel;

    [Header("CentralizeeStage")]
    [SerializeField] CentralizeLevel08GameplayManagerScript CentralizeStage08;

    [SerializeField] bool Stage09;
    [SerializeField] CentralizeLevel09GameplayManagerScript CentralizeStage09;

    [SerializeField] bool Stage10;
    [SerializeField] CentralizeLevel10GamePlayManagerScript CentralizeStage10;
    public void checkTask()
	{
        if (Stage09)
		{
            if (_chechwaste[0].Checker == true &&
                _chechwaste[1].Checker == true &&
                _chechwaste[2].Checker == true &&
                _chechwaste[3].Checker == true &&
                _chechwaste[4].Checker == true &&
                _chechwaste[5].Checker == true &&
                _chechwaste[6].Checker == true &&
                _chechwaste[7].Checker == true &&
                _chechwaste[8].Checker == true &&
                _chechwaste[9].Checker == true &&
                _chechwaste[10].Checker == true &&
                _chechwaste[11].Checker == true &&
                _chechwaste[12].Checker == true &&
                _chechwaste[13].Checker == true &&
                _chechwaste[14].Checker == true &&
                _chechwaste[15].Checker == true &&
                _chechwaste[16].Checker == true &&
                _chechwaste[17].Checker == true &&
                _chechwaste[18].Checker == true &&
                _chechwaste[19].Checker == true &&
                _chechwaste[20].Checker == true &&
                _chechwaste[21].Checker == true &&
                _chechwaste[22].Checker == true &&
                _chechwaste[23].Checker == true &&
                _chechwaste[24].Checker == true &&
                _chechwaste[25].Checker == true &&
                _chechwaste[26].Checker == true 
                )
            {
                TaskIsDone = true;
                StartCoroutine(DoThisWhenComplete());
            }
        }
        else if (Stage10)
        {
            if (_chechwaste[0].Checker == true &&
                _chechwaste[1].Checker == true &&
                _chechwaste[2].Checker == true &&
                _chechwaste[3].Checker == true &&
                _chechwaste[4].Checker == true &&
                _chechwaste[5].Checker == true &&
                _chechwaste[6].Checker == true &&
                _chechwaste[7].Checker == true &&
                _chechwaste[8].Checker == true &&
                _chechwaste[9].Checker == true &&
                _chechwaste[10].Checker == true &&
                _chechwaste[11].Checker == true &&
                _chechwaste[12].Checker == true &&
                _chechwaste[13].Checker == true &&
                _chechwaste[14].Checker == true &&
                _chechwaste[15].Checker == true &&
                _chechwaste[16].Checker == true &&
                _chechwaste[17].Checker == true &&
                _chechwaste[18].Checker == true &&
                _chechwaste[19].Checker == true &&
                _chechwaste[20].Checker == true &&
                _chechwaste[21].Checker == true &&
                _chechwaste[22].Checker == true &&
                _chechwaste[23].Checker == true &&
                _chechwaste[24].Checker == true &&
                _chechwaste[25].Checker == true &&
                _chechwaste[26].Checker == true &&
                _chechwaste[27].Checker == true &&
                _chechwaste[28].Checker == true &&
                _chechwaste[29].Checker == true 

                )
            {
                TaskIsDone = true;
                StartCoroutine(DoThisWhenComplete());
            }
        }
        else //stage 8
        {
            if (_chechwaste[0].Checker == true &&
            _chechwaste[1].Checker == true &&
            _chechwaste[2].Checker == true &&
            _chechwaste[3].Checker == true &&
            _chechwaste[4].Checker == true &&
            _chechwaste[5].Checker == true &&
            _chechwaste[6].Checker == true
            )
            {
                TaskIsDone = true;
                StartCoroutine(DoThisWhenComplete());
            }
        }//stage 8

    }

    IEnumerator DoThisWhenComplete()
	{
        CompleteAnim.SetActive(true);

        if (Stage09)
		{
            CentralizeStage09.MissionCol[8].enabled = false;
            MainLevel.PopUpMission[8].SetActive(false);
        }
        else if (Stage10)
		{
            CentralizeStage10.MissionCol[23].enabled = false;
            MainLevel.PopUpMission[23].SetActive(false);
        }
		else //stage 8
		{
            CentralizeStage08.MissionCol[10].enabled = false;
            MainLevel.PopUpMission[10].SetActive(false);

        }

        yield return new WaitForSeconds(2.9f);
        MainLevel.HideInspectMission();
        gameObject.SetActive(false);
    }
}
