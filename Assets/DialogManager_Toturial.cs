using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager.Level;
public class DialogManager_Toturial : MonoBehaviour
{
    [SerializeField] DialogTrigger_Toturial _dialogTrigger_Toturial;
    [Header("DialogBox")]
    [SerializeField] Text OfficerName;
    [SerializeField] Text dialogueText;
    [SerializeField] int dialogueCount;
    
    //
    public int x;
    public bool isinToturialMode;
        
    private Queue<string> sentences;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] DialogManager_GamePlay _dialogManager_GamePlay;
    [SerializeField] GameObject tapToContinueDialog;

    [Header("Toturial")]
    [SerializeField] GameObject ToturialCutSceneCollection;
    [Header("PlayerController")]
    [SerializeField] GameObject LeftControl, RightControl, InspectControl;

    [Header("Hand")] 
    [SerializeField] GameObject LeftControlTapHand;
    [SerializeField] GameObject RightControlTapHand;
    [SerializeField] GameObject InspectControlTapHand;
    
    [Header("Collided Target OverWorld Tour Item")]
    [SerializeField] ToturialColliderTrigger _toturialColliderTrigger;
    public GameObject FadeLeftArea;
    public GameObject FadeRightArea;
    public GameObject FadeSeenPopUp;
    public GameObject FadePopUpGuideArea;
    public GameObject FadeMiniGame;
    public GameObject PopUp;

    [Header("Button Trigger")]
    [SerializeField] GameObject LeftControlTapTrigger;
    [SerializeField] GameObject RightControlTapTrigger;
    [SerializeField] GameObject InspectControlTapTrigger;

    [Header("MiniGameTour")]
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Resume;
    [SerializeField] GameObject Info;
    [SerializeField] GameObject Okay;
    [SerializeField] GameObject Return;

    [Header("Reputaion BAr and Mission")]
    [SerializeField] GameObject ReputationBar;
    [SerializeField] GameObject MissionTab;
    [SerializeField] GameObject RepBG;

    Animator fadeleftanim;
    Animator faderightanim;
    Animator fadePopUpGuideAreaanim;

    [Header("Case1")]
    [SerializeField] GameObject[] SetTrue;
    [SerializeField] GameObject[] SetFalse;


    [Header("ReputationStart")]
    [SerializeField] LevelGameplayManagerScript _levelGameplayManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        _dialogTrigger_Toturial.TriggerDialogue();

        fadeleftanim = FadeLeftArea.GetComponent<Animator>();
        faderightanim = FadeRightArea.GetComponent<Animator>();
        fadePopUpGuideAreaanim = FadePopUpGuideArea.GetComponent<Animator>();
       
    }

    public void Update()
    {
    }

    public void StartDialogue(Dialog_GamePlay dialogue)
    {
        dialogueBox.SetActive(true);
        //ToturialCutSceneCollection.SetActive(true);

        OfficerName.text = dialogue.Name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        dialogueCount = 0; // intro dialogue
        DisplayNextSentence();
        _levelGameplayManagerScript.StartReputationBar(false);
    }
    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();

        dialogueCount++;
       
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
      
        
        //Debug.Log(sentence);
        
        DialogIsDone();    
        StopAllCoroutines();


        
        if (PlayerPrefs.GetInt("AnimatedTextToggle") == 1)
        {
            StartCoroutine(TypeSentence(sentence));
        }
        else
        {
            dialogueText.text = sentence;

        }

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        //Debug.Log("Empty Queue");
        dialogueBox.SetActive(false);
        isinToturialMode = false;
        ToturialCutSceneCollection.SetActive(false);
        _levelGameplayManagerScript.StartReputationBar(true);
        PlayerPrefs.SetInt("Reply", 1);
        PlayerPrefs.Save();


    }

    public void DialogIsDone() // toturial
    {
        
        
        


        //FollowUpCutscene / Set Active 
        x = dialogueCount;
        if (_dialogManager_GamePlay.IsDone == true) 
        {

            isinToturialMode = true;
            switch (x)
            {
                //intro
                case 1://intro
                    Restart();
                    
                    break;
                //leftbtn
                case 2:
                    LeftControl.SetActive(true);
                    
                    break;
                case 3:
                    FadeLeftArea.SetActive(true);
                    
                    break;
                case 4:
                    tapToContinueDialog.SetActive(false);
                    LeftControlTapHand.SetActive(true);
                    LeftControlTapTrigger.SetActive(true);
                    //autonext

                    break;
                //rightbtn
                case 5:
                    //dissable
                    LeftControlTapHand.SetActive(false);
                    LeftControlTapTrigger.SetActive(true);
                    LeftControl.SetActive(true);
                    
                    //LeftControl.color.a = 0;
                    //enable
                    RightControl.SetActive(true);
                    break;
                case 6:
                    FadeRightArea.SetActive(true);
                    break;
                case 7:
                    
                    tapToContinueDialog.SetActive(false);
                    RightControlTapHand.SetActive(true);
                    RightControlTapTrigger.SetActive(true);
                    break;
                //explore environment
                case 8:
                    FadeSeenPopUp.SetActive(true);
                    RightControl.SetActive(true);
                    LeftControl.SetActive(true);
                    tapToContinueDialog.SetActive(false);
                    RightControlTapTrigger.SetActive(true);
                    LeftControlTapTrigger.SetActive(true);
                    break;
                //Minipopup guide
                case 9:
                    FadePopUpGuideArea.SetActive(true);
                    FadePopUpGuideArea.GetComponent<BoxCollider2D>().enabled = false;
                    tapToContinueDialog.SetActive(true);
                    LeftControl.SetActive(true);
                    RightControlTapTrigger.SetActive(true);

                    break;
                case 10:
                    FadePopUpGuideArea.GetComponent<BoxCollider2D>().enabled = true;
                    FadeSeenPopUp.SetActive(false);
                    tapToContinueDialog.SetActive(false);
                    LeftControl.SetActive(true);
                    RightControlTapTrigger.SetActive(true);
                    break;
                case 11:
                    PopUp.SetActive(true);
                    break;
                //inspect button
                case 12:
                    InspectControl.SetActive(true);
                    PopUp.SetActive(false);
                    break;
                case 13:
                    FadeMiniGame.SetActive(true);
                    tapToContinueDialog.SetActive(false);
					break;
                //minigame
                case 14:
                    tapToContinueDialog.SetActive(true);
                    break;
                case 15:
                    Pause.SetActive(true);
                    tapToContinueDialog.SetActive(false);
                    break;
                case 16:
                    Pause.SetActive(false);
                    Resume.SetActive(true);
                    tapToContinueDialog.SetActive(false);
                    break;
                case 17:
                    Resume.SetActive(false);
                    Info.SetActive(true);
                    break;
                case 18:
                    Info.SetActive(false);
                    Okay.SetActive(true);
                    break;

                case 19:
                    Return.SetActive(true);
                    Okay.SetActive(false);
                    //tapToContinueDialog.SetActive(true);
                    break;
                //reputation bar
                case 20:
                    Return.SetActive(false);
                    RepBG.SetActive(true);
                    ReputationBar.SetActive(true);
                    tapToContinueDialog.SetActive(true);
                    break;
                //mission
                case 21:
                    ReputationBar.SetActive(false);
                    MissionTab.SetActive(true);
                    tapToContinueDialog.SetActive(true);
                    Return.SetActive(false);
                    break;
                //closing
                case 22:
                    MissionTab.SetActive(false);
                    tapToContinueDialog.SetActive(true);
                    
                    break;
                

            }

		}
        
    }


    public void Restart()
	{
        foreach (GameObject obj in SetTrue)
		{
            obj.SetActive(true);
		}
        foreach (GameObject _obj in SetFalse)
        {
            _obj.SetActive(false);
        }

        fadeleftanim.SetBool("IsFading", false);
        faderightanim.SetBool("IsFading", false);
        fadePopUpGuideAreaanim.SetBool("IsFading", false);
        FadeLeftArea.GetComponent<Collider2D>().enabled = true;
        FadeRightArea.GetComponent<Collider2D>().enabled = true;
        FadePopUpGuideArea.GetComponent<Collider2D>().enabled = true;
        FadeSeenPopUp.GetComponent<Collider2D>().enabled = true;
    }

  
}
