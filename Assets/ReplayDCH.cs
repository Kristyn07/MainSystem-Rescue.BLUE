using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayDCH : MonoBehaviour
{
    //reset falling obj
    [SerializeField] FadeFallingOBj[] fadeFallingOBj;
    [SerializeField] GameObject[] FallingObject;
    //reset healthbar
    [SerializeField] HealthBarDCH healthBarDCH;
    //reset player bar
    [SerializeField] ResetPosition resetPosition;
    //reset Anim to 
    [SerializeField] T3_DropCoverHold_AnimationAndController t3_DropCoverHold_AnimationAndController;
    //ResetTrigger
    [SerializeField] TriggerShakeCameraCollider[] triggerShakeCameraCollider;
    [SerializeField] TriggerCameraShake[] triggerCameraShakes;
    public void Reply()
	{
        
        foreach (FadeFallingOBj obj in fadeFallingOBj)
		{
            obj.ResetPostion();
        }
        foreach(GameObject obj in FallingObject)
		{
            obj.SetActive(true);
            
        }
       
        healthBarDCH.Replay();
        resetPosition.ResetPos();
        t3_DropCoverHold_AnimationAndController.ResetPlayerAnim();
        foreach (TriggerShakeCameraCollider trig in triggerShakeCameraCollider)
        {
            trig.resetTrigger();
        }
        foreach (TriggerCameraShake shake in triggerCameraShakes)
		{
            shake.ResetShakeCam();

        }

    }
}
