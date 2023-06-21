using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;

namespace CollisionCheck.Manager
{
    public class CentralizeCollisionCheckScript : MonoBehaviour
    {
        public int IDCollision;
        BoxCollider2D BoxCol;
        
        [SerializeField]
        bool OtherStage;

        [Header("Stage04")]
        [SerializeField] bool Stage04;
        CentralizeLevel04GameplayManagerScript MainLevel04;

        [Header("Stage05")]
        [SerializeField] bool Stage05;
        CentralizeLevel05GameplayManagerScript MainLevel05;

        [Header("Stage06")]
        [SerializeField] bool Stage06;
        CentralizeLevel06GameplayManagerScript MainLevel06;

        [Header("Stage07")]
        [SerializeField] bool Stage07;
        CentralizeLevel07GameplayManagerScript MainLevel07;

        [Header ("Stage08")] 
        [SerializeField] bool Stage08;
        CentralizeLevel08GameplayManagerScript MainLevel08;

        [Header("Stage09")]
        [SerializeField] bool Stage09;
        CentralizeLevel09GameplayManagerScript MainLevel09;

        [Header("Stage10")]
        [SerializeField] bool Stage10;
        CentralizeLevel10GamePlayManagerScript MainLevel10;
        void Start()
        {
            if (OtherStage == true)
            {
                if (Stage04 == true)
                {
                    MainLevel04 = GameObject.FindObjectOfType<CentralizeLevel04GameplayManagerScript>();
                    BoxCol = GetComponent<BoxCollider2D>();
                }
                if(Stage05 == true)
				{
                    MainLevel05 = GameObject.FindObjectOfType<CentralizeLevel05GameplayManagerScript>();
                    BoxCol = GetComponent<BoxCollider2D>();
                }
                if (Stage06)
				{
                    MainLevel06 = GameObject.FindObjectOfType<CentralizeLevel06GameplayManagerScript>();
                    BoxCol = GetComponent<BoxCollider2D>();
                }
				if (Stage07)
				{
                    MainLevel07 = GameObject.FindObjectOfType<CentralizeLevel07GameplayManagerScript>();
                    BoxCol = GetComponent<BoxCollider2D>();
                }
                if (Stage08)
				{
                    MainLevel08 = GameObject.FindObjectOfType<CentralizeLevel08GameplayManagerScript>();
                    BoxCol = GetComponent<BoxCollider2D>();
                }
                if (Stage09)
				{
                    MainLevel09 = GameObject.FindObjectOfType<CentralizeLevel09GameplayManagerScript>();
                    BoxCol = GetComponent<BoxCollider2D>();
                }
                if (Stage10)
				{
                    MainLevel10 = GameObject.FindObjectOfType<CentralizeLevel10GamePlayManagerScript>();
                    BoxCol = GetComponent<BoxCollider2D>();
                }
            }
           
        }
        public void CountControl()
        {
            if (Stage04 == true)
            {
                MainLevel04.CountControl = IDCollision;
            }
            if (Stage05 == true)
            {
                MainLevel05.CountControl = IDCollision;
            }
            if (Stage06 == true)
            {
                MainLevel06.CountControl = IDCollision;
            }
            if(Stage07 == true)
			{
                MainLevel07.CountControl = IDCollision;
            }
            if (Stage08 == true)
            {
                MainLevel08.CountControl = IDCollision;
            }
            if (Stage09 == true)
			{
                MainLevel09.CountControl = IDCollision;
			}
            if (Stage10 == true)
            {
                MainLevel10.CountControl = IDCollision;
            }
        }
               
       

    }
}

