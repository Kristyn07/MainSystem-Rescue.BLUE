using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesFirstAid : MonoBehaviour
{
    public GridArray gridArray;
    public Objectives completeIt;
    public List<int> objectiveCounts;
    public GameObject activeWindow;
    public GameObject currentWindow;
    public GridFillerColliders[] colliders;
    [Header("Default sprite for Grid")]
    public Sprite mySprite;

    [SerializeField] Canvas PlayerCanvas;
    [SerializeField] Canvas MiniGameCanvas;
    [SerializeField] GameObject CompleteAnim;
    [SerializeField] float DelaySec;
   /* [SerializeField] GameObject CompleteAnim1;
    [SerializeField] Animator completeAnim1;*/
    //[SerializeField] CompletedAnimationCall _completedAnimationCall;



    void Update()
    {




        foreach (GridFillerColliders a in colliders)
        {
            gridArray.boxFilled = true;
            if (a.isFilled == true)
            {
                gridArray.boxFilled = true;
            }
            else if (a.isFilled == false)
            {
                gridArray.boxFilled = false;
                break;
            }
        }
        if (gridArray.boxFilled && !completeIt.isComplete)
        {
            gridArray.CheckCompletion();
            //Complete();
            //Invoke("CloseWindow", DelaySec);
        }
            //CompleteAnimation();


        }

	
	public void Complete()
    {
        completeIt.isComplete = true; 
        completeIt.AutoComplete();
        CompleteAnimation();
        Invoke("CloseWindow", DelaySec);
        //CloseWindow();
        //_completedAnimationCall.MiniGameCompletedPromt();

    }

    public void CloseWindow()
    {
        currentWindow.SetActive(false);
        activeWindow.SetActive(true);
        Debug.Log("CloseWindow");
        PlayerCanvas.enabled = true;
        MiniGameCanvas.enabled = false;

    }


	void CompleteAnimation()
	{ // call before completing



		if (completeIt.isComplete == true)
		{
            CompleteAnim.SetActive(true);
            
			if (CompleteAnim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
			{
                //CompleteAnim.GetComponent<Animator>().SetBool("Completed", false);
                CompleteAnim.SetActive(false);
                //currentWindow.SetActive(false);
                Debug.Log("not playing");
				//MyFunctionCalled = true;
			}
			else
			{
				Debug.Log("playing");
			}
		}
		else
		{
            //ompleteAnim.GetComponent<Animator>().Stop();
        }


	}
}


