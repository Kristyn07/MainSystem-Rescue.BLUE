using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;

namespace Stage05.Animation
{
    public class CentralizeLevel05AnimationScript : MonoBehaviour
    {
        CentralizeLevel05GameplayManagerScript Level05Main;
        Animator FireExtinguisherAnimator;
        [SerializeField]
        bool ActivateFireExtinguisherAnimator;
        // Start is called before the first frame update
        void Start()
        {
            Level05Main = GameObject.FindObjectOfType<CentralizeLevel05GameplayManagerScript>();

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
            if (AnimationID == Level05Main.FireExtingiusherAnimCount)
            {
                FireExtinguisherAnimator.SetInteger("FE Step", Level05Main.FireExtingiusherAnimCount);
            }
        }

        public void CallEnd()
        {
            Level05Main.FinishStage();
        }


    }
}

