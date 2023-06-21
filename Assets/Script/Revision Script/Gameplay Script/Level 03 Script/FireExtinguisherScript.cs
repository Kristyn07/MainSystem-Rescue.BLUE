using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;
using Score.System;
namespace MiniGame.Manager
{
    public class FireExtinguisherScript : MonoBehaviour
    {
        [Header("CompleteState")]
        public bool Completed;
        [SerializeField] GameObject CompleteAnim;

        [SerializeField]
        Animator Anim;
        public int AnimationCount;

        [SerializeField]
        GameObject MiniGameFireExtinguisher;
        [SerializeField]
        BoxCollider2D MiniGameFireExtinguisherCol;

        [SerializeField]
        Canvas PlayerCanvas;
        [SerializeField]
        Canvas MiniGameCanvas;

        [SerializeField]
        Stage03Complete MainStage;
        [SerializeField]
        Level02GameplayManagerScript MainControl;
        //[SerializeField]
        //ScoreManagerScript MainScore;

        //Stage 03
        [SerializeField]
        int StageCount;
        // Start is called before the first frame update

        
        void Start()
        {
            AnimationCount = 1;

        }

      
        public void EndResultAnimation()
        {
            Completed = true;
            CompleteAnim.SetActive(true);
            StartCoroutine(MiniGameComplete());

            if (StageCount == 3)
			{
            MainStage.CheckCompletion();
            }

        }

        IEnumerator MiniGameComplete()
		{
            yield return new WaitForSeconds(2.8f);
            PlayerCanvas.enabled = true;
            MiniGameCanvas.enabled = false;
            MiniGameFireExtinguisher.gameObject.SetActive(false);
            MiniGameFireExtinguisherCol.enabled = false;
        }


       
        public void FireExtinguisherButton(int AnimationID)
        {
            if (AnimationID == AnimationCount)
            {
                
                    Anim.SetInteger("FE Step", AnimationCount);
                    //return AnimationID;
                
            }


        }



       


       
    }
}

