using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;

public class GoOutside : MonoBehaviour
{
    [SerializeField] T3_DropCoverHold_AnimationAndController _t3_DropCoverHold_AnimationAndController;
    [SerializeField] bool IsGoingOutside;
    [SerializeField] CentralizeLevel06GameplayManagerScript MainStage;
    [SerializeField] Animator Anim;
    [SerializeField] GameObject StaticEnvironment;
    [SerializeField] GameObject OutsideEarthquake;
    [SerializeField] GameObject SafeZone;
    [SerializeField] Collider2D MainPlayer;
    //[SerializeField] GameObject MainPlayer1;
    [SerializeField] GameObject RightEnd;
    [SerializeField] Animator anim;
    [SerializeField] CameraFollow _cameraFollow;
    [SerializeField] GameObject[] IndicateWhereTogo;
    //[SerializeField] GameObject SafeZoneCollider;//task complere
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Main Player"))
        {
            _t3_DropCoverHold_AnimationAndController.DoneEartquake = true;
            MainPlayer.transform.position = new Vector3(1, 1, 1);
            IsGoingOutside = true;
            anim.SetBool("SpeedWhenCrawling", false);
            MainStage.AutoGoOutside();
            _t3_DropCoverHold_AnimationAndController.DCHCompleteStand();
            RightEnd.SetActive(false);
            Anim.SetBool("ISEnteringEarthQuakeMode", true);
            StaticEnvironment.SetActive(false);
            MainPlayer.enabled = false;
            OutsideEarthquake.SetActive(true);
            SafeZone.SetActive(true);
            _cameraFollow.PlayerExitTheHouse = true;
            _cameraFollow.FollowSpeed = 7f;
            _t3_DropCoverHold_AnimationAndController.DefaultSpeed = 9f;
            _t3_DropCoverHold_AnimationAndController.MovementSpeed = 9f;
            foreach (GameObject obj in IndicateWhereTogo)
			{
                obj.SetActive(true);
			}
            //MainPlayer1.transform.position
            //setfalse end right collider
            //MainPlayer.transform.position = new Vector3(1, 1, 1);
            //Animation in Outside the word
        }
    }
}
