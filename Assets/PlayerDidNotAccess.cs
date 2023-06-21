using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDidNotAccess : MonoBehaviour
{
    [SerializeField] bool animationBool;
    public Animator animator; // reference to the animator component
    public string animationName;
    [SerializeField] Animator UIAnim;
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Main Player")) // check if the object that exited the collider is the player
        {
            animationBool = animator.GetBool(animationName);
            if (animationBool == true)
            {
                animator.SetBool(animationName, false);
                UIAnim.SetBool("Button", false);
                //animationBool = false;
            }
        }
    }

    
}
