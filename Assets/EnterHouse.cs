using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnterHouse : MonoBehaviour
{ 
    public bool isTouching;
    public Rigidbody2D player;
    public BoxCollider2D House;
    public GameObject OutsideHouseView;
    public Animator Anim;


    void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log("In range of House");
        isTouching = true;
        if (collider == House)
        {
            Anim.SetBool("FadeOut", true);
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        isTouching = true;
        if (collider == House)
        {
            Anim.SetBool("FadeOut", true);
        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {
       
        isTouching = false;
        if (collider == House)
        {
            
            //OutsideHouseView.SetActive(true);
            Anim.SetBool("FadeOut", false);
        }
    }

    public void CollideToHouseWithMission()
	{

	}

    
}

