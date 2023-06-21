using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;

namespace Mission.Control
{
    public class Mission02ControlScript : MonoBehaviour
    {
        Level02GameplayManagerScript MainControl;

        [SerializeField]
        int MissionNumber;
        [SerializeField]
        bool PopUpInfoTraining;
        [SerializeField]
        bool MissionPopUpTarget;
        [SerializeField]
        bool HiddenPopUp;
        // Start is called before the first frame update
        void Start()
        {
            MainControl = GameObject.FindObjectOfType<Level02GameplayManagerScript>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        //private void OnCollisionEnter2D(Collision2D collision)
        //{

           
        //}

        //private void OnCollisionExit2D(Collision2D collision)
        //{
           
        //}
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Main Player")
            {
                MainControl.MissionTaskCount = MissionNumber;

                if (PopUpInfoTraining == true)
                {
                    MainControl.ShowMissionPopUpTraining();
                }

                if (MissionPopUpTarget == true)
                {
                    MainControl.ShowMissionPopUp();
                }

                if (HiddenPopUp == true)
                {
                    MainControl.ShowPopUpHidden();
                }

            }
        }

         void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Main Player")
            {
                MainControl.MissionTaskCount = MissionNumber;

                if (PopUpInfoTraining == true)
                {
                    MainControl.HideMissionPopUpTraining();
                }

                if (MissionPopUpTarget == true)
                {
                    MainControl.HideMissionPopUp();
                }
                if (HiddenPopUp == true)
                {
                    MainControl.HidePopUpHidden();
                }
            }
        }
    }

}
