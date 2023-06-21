using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager.Level;

public class DialogManager_GamePlay : MonoBehaviour
{
    [SerializeField] Text OfficerName;
    [SerializeField] Text dialogueText;
    [SerializeField] int dialogueCount = 1;
    private Queue<string> sentences;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject DialogCollection;
    public bool isInStrory;
    public bool IsDone;
    [SerializeField] bool HasAFollowUpCutScene;
    
    [SerializeField] GameObject Tutorial;
    [SerializeField]
    int value;

    [Header("Start Reputation After Dialog Story")]
    
    public bool StartRepuAfterStory;
    [SerializeField] int Stage;

    [Header("Get Script Start Reputation 1 ")]
    [Tooltip("Stage 1")]
    [SerializeField] LevelGameplayManagerScript _levelGameplayManagerScript;
    [SerializeField] DialogManager_Toturial _dialogManager_Toturial;

    [Header("Get Script Start Reputation 2 - 10 ")]
    [Tooltip("Stage 2")]
    [SerializeField] Level02GameplayManagerScript _level02GameplayManagerScript;
    [Tooltip("Stage 3")]
    [SerializeField] Level02GameplayManagerScript _3_level02GameplayManagerScript;
    [Tooltip("Stage 4")]
    [SerializeField] LevelGameplayManagerScript _4_levelGameplayManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        FindObjectOfType<DialogTrigger_GamePlay>().TriggerDialogue(); // start dialog

        
    }

	public void Update()
	{
        value = PlayerPrefs.GetInt("Reply");

    }

	public void StartDialogue(Dialog_GamePlay dialogue)
    {
        isInStrory = true;
        DialogCollection.SetActive(true);
        dialogueBox.SetActive(true);
        IsDone = false;
        OfficerName.text = dialogue.Name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        dialogueCount++;
        if (sentences.Count == 0)
        {
            
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        
        
        //Debug.Log(sentence);
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
        DialogCollection.SetActive(false);
        
        switch (Stage)
		{
            case 1: // with tutorial and stuff
                    if (StartRepuAfterStory == true)//for stage 2- 10
                    {
                        IsDone = true;
                        _levelGameplayManagerScript.StartReputationBar(true);

                    }
                    else
                    {
                        if (value == 1)
                        {
                            IsDone = false;
                            Tutorial.SetActive(false);

                            _levelGameplayManagerScript.StartReputationBar(true);
                        }

                        else if (value == 0)
                        {
                            if (HasAFollowUpCutScene == true)
                            {
                                IsDone = true;
                                _dialogManager_Toturial.DialogIsDone();
                                _levelGameplayManagerScript.StartReputationBar(false);
                            }
                            else
                            {
                                //proceed to game
                            }
                        }
                    }
                break;
            case 2:
                if (StartRepuAfterStory == true)//for stage 2- 10
                {
                    IsDone = true;
                    _level02GameplayManagerScript.startGame();

                }
                break;
            case 3:
                if (StartRepuAfterStory == true)//for stage 2- 10
                {
                    IsDone = true;
                    _3_level02GameplayManagerScript.StartGameplay = true;
                }
                break;
            case 4:
                if (StartRepuAfterStory == true)//for stage 2- 10
                {
                    IsDone = true;
                    _levelGameplayManagerScript.StartReputationBar(true);
                }
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;

        }



    }
}