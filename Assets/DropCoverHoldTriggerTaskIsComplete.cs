using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager.Level;

public class DropCoverHoldTriggerTaskIsComplete : MonoBehaviour
{
	public bool IsComplete;
    [SerializeField] GameObject CompleteDoor;
    [SerializeField] GameObject CompletedUI;
    [SerializeField] LevelGameplayManagerScript MainControl;
    [SerializeField] Collider2D DCHCollider;
    [SerializeField] float delay;
    [SerializeField] CameraFollow _cameraFollow;
    [SerializeField] T3_DropCoverHold_AnimationAndController _t3_DropCoverHold_AnimationAndController;
    [SerializeField] GameObject DCHCanvas;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IsComplete = true;
            CompleteDoor.SetActive(true);
            CompletedUI.SetActive(true);
            Invoke("DCHCompleted", delay);
            _t3_DropCoverHold_AnimationAndController.DCHCompleteStand();
        }
    }

    void DCHCompleted()
	{
        MainControl.HideInspectMission();
        DCHCollider.enabled = false;
        _cameraFollow.IsEnteringMiniGameOverWorld = false;
        DCHCanvas.SetActive(false);

    }


}
