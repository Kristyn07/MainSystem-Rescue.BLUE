using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;

namespace Stage04.Animation
{
    public class CentralizeLevel04AnimationScript : MonoBehaviour
    {
        CentralizeLevel04GameplayManagerScript Level04Main;
        Animator FireExtinguisherAnimator;
        [SerializeField]
        bool ActivateFireExtinguisherAnimator;
        // Start is called before the first frame update
        void Start()
        {
            Level04Main = GameObject.FindObjectOfType<CentralizeLevel04GameplayManagerScript>();

            if (ActivateFireExtinguisherAnimator == true)
            {
                FireExtinguisherAnimator = GetComponent<Animator>();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void FireExtinguisherButton(int AnimationID)
        {
            if (AnimationID == Level04Main.FireExtingiusherAnimCount)
            {
                FireExtinguisherAnimator.SetInteger("FE Step", Level04Main.FireExtingiusherAnimCount);
            }
        }

        public void CallEnd()
        {
            Level04Main.FinishStage();
        }


    }
}

