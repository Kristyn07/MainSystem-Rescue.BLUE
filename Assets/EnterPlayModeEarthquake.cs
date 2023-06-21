using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager.Level; // level 6 only
public class EnterPlayModeEarthquake : MonoBehaviour
{
    [SerializeField] CentralizeLevel06GameplayManagerScript MainLevel06;
    [SerializeField] LevelGameplayManagerScript MainLevel;
    public bool EnterPlayMode;
    [SerializeField] GameObject EnteringPlatModeAnimation;
    [SerializeField] GameObject MainPlayer;
    [SerializeField] Transform StartLoc;
    [SerializeField] Collider2D coll;
    [SerializeField] GameObject MainPlayerCol;
    [SerializeField] TriggerCameraShake shakecam;
    [SerializeField] Animator PlayerDCHAnim;
    //[SerializeField] GameObject ColliderTriggerCollection;
    private void Start()
	{
		
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Main Player")
        {
            
            shakecam.shake = true;
            EnteringPlatModeAnimation.SetActive(true);
            //FadeAnim.SetActive(false);
            AutoInspect();
            //MainPlayerCol.transform.position = new Vector3(StartLoc.localPosition.x, MainPlayer.transform.localPosition.y, MainPlayer.transform.localPosition.z) ;
            //MainPlayerCol.transform.localScale = new Vector3(-0.75f, 0.75f, 1f);
            //MainPlayer.transform.position = new Vector3(StartLoc.localPosition.x, MainPlayer.transform.localPosition.y, MainPlayer.transform.localPosition.z);
            MainPlayer.SetActive(false);
            MainPlayer.SetActive(true);
            PlayerDCHAnim.SetBool("ISEnteringEarthQuakeMode", true);
            //true animation is entering mode

            EnterPlayMode = true;
            
                
                //ColliderTriggerCollection.SetActive(true);
                coll.enabled = false;
               
            




        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    public void AutoInspect()
	{
        
        MainLevel06.HasANewOverWorld();
    }
}
