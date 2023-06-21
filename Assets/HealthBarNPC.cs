using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;
using LegCravatMiniTask;

public class HealthBarNPC : MonoBehaviour
{
    float delaySecs = 5f;
    [SerializeField] GameObject LoseState;
    [SerializeField] CameraFollow ChangeCamFocus;
    [SerializeField] Transform newTarget;
    [Header("Health Bar")]
    [SerializeField] Transform Bar;
    [SerializeField] SpriteRenderer BarSprite;
    [SerializeField] Color newColor;
    [SerializeField] float Timer;
    [SerializeField] float MaxTimer;

    [SerializeField] int StageNo;


    [Header ("Stage 2")]
    [SerializeField] Level02GameplayManagerScript _level02GameplayManagerScript;
    [SerializeField] DialogManager_GamePlay _dialogManager_GamePlay;
    [SerializeField] SubTasksIsSuccess legCravatBandaging;


    [Header("Stage 4")]
    [SerializeField] LevelGameplayManagerScript _4_levelGameplayManagerScript;
    [SerializeField] LegCravatStepsController palmCravatBandaging;
    // Start is called before the first frame update
    void Start()
    {
        Bar.localScale = new Vector3(1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarStart();
    }

    public void HealthBarStart()
	{
        switch (StageNo)
		{
            case 1:
                break;
            case 2: //Stage 2
                if (_level02GameplayManagerScript.StartGameplay == true)
                {
                    if (legCravatBandaging.MiniTask3Complete == false)
					{
                        if (Timer > 0)
                        {
                            var bar = Bar.localScale;
                            Timer -= Time.deltaTime;
                            float value = Timer / MaxTimer;
                            Bar.localScale = new Vector3(value, 1f);
                        }
                        else
                        {
                            //lose state
                            ChangeCamFocus.FollowSpeed = 5f;
                            ChangeCamFocus.target = newTarget;
                            Invoke("NPCLoseState", delaySecs);
                            _level02GameplayManagerScript.StartGameplay = false;
                        }
                    }
                    else if (legCravatBandaging.MiniTask3Complete == true)
					{
                        if (Timer < MaxTimer)
                        {
                            var bar = Bar.localScale;
                            Timer += Time.deltaTime;
                            float value = Timer / MaxTimer;
                            Bar.localScale = new Vector3(value, 1f);
                            //ChangeSpriteBTN color to green or blue
                            BarSprite.color = newColor;

                        } // else stop 
                        
                    }
                    
                }
                break;
            case 3:
                break;
            case 4:
                if (_4_levelGameplayManagerScript == true)
                {
                    if (palmCravatBandaging.IsSuccess == false)
                    {

                        if (Timer > 0)
                        {
                            var bar = Bar.localScale;
                            Timer -= Time.deltaTime;
                            float value = Timer / MaxTimer;
                            Bar.localScale = new Vector3(value, 1f);
                        }
                        else
                        {
                            //lose state
                            ChangeCamFocus.FollowSpeed = 5f;
                            ChangeCamFocus.target = newTarget;
                            Invoke("NPCLoseState", delaySecs);
                            _4_levelGameplayManagerScript.StartGameplay = false;
                        }
                    }
                    else if (palmCravatBandaging.IsSuccess == true)
                    {
                        if (Timer < MaxTimer)
                        {
                            var bar = Bar.localScale;
                            Timer += Time.deltaTime;
                            float value = Timer / MaxTimer;
                            Bar.localScale = new Vector3(value, 1f);
                            BarSprite.color = newColor;

                        }
                       
                    }
                }
                break;
        }
	}



    public void NPCLoseState()
	{
        LoseState.SetActive(true);
    }


    /*public void StartHealthBarCountDown(bool StartGame)
    {
        if (StartGame == true)
        {
            StartGameplay = true;
        }

    }*/
}
