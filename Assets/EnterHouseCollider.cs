using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class EnterHouseCollider : MonoBehaviour
{
    public bool isTouching;
    public Rigidbody2D player;
    [SerializeField] Collider2D Player;
    //[SerializeField] Tilemap2D tilemap;
    //[SerializeField] BoxCollider2D boxCollider;
    public GameObject OutsideHouseView;
    public Animator Anim;


    private void Start()
	{
      
    }

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Tilemap"))
		{
            Debug.Log("In range of House");
            isTouching = true;

            Anim.SetBool("FadeOut", true);

        }   
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Tilemap"))
        {
            isTouching = true;

            Anim.SetBool("FadeOut", true);
        }
    }

    
    void OnTriggerExit2D(Collider2D collider)
    {

        isTouching = false;

        Anim.SetBool("FadeOut", false);

    }

}
