using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Animation : MonoBehaviour
{

    [SerializeField] Animator animator;
    public Animator Anim;
    public bool IsPaused;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Steps"))
		{
			Debug.Log("test");
		}*/

        /*if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            Debug.Log("test0");
        }*/

        /*if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("YourAnimationName"))
        {
            // Avoid any reload.
            this.InMyState = true;
        }
        else if (this.InMyState)
        {
            this.InMyState = false;
            // You have just leaved your state!
        }*/

        /*if (anim.IsPlaying("S1_F_ForeArm")) { 
            Debug.Log("test3");
            InMyState = true;

        }*/

        //m_CurrentClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        
        /*if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Steps"))
		{
            Debug.Log("Test2");
		}*/
    }
    
    
    
    void checkanimplay() //used
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Debug.Log("is not playing");
        }
        else
        {
            Debug.Log("is playing");
        }
    }
    public void PauseBandage()
    {
        Anim.speed = 0;
        IsPaused = true;
    }

    public void ResumeBandage()
    {
        Anim.speed = 1;
        IsPaused = false;
    }
}
