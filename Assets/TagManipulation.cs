using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManipulation : MonoBehaviour
{
    private GameObject Obj;
    private Rigidbody2D rb;
    private Collider2D collider;
    [SerializeField] TriggerCameraShake _triggerCameraShake;
   
    void Start()
    {
        Obj = gameObject;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        //Obj.tag = "DoneFalling";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DoneFalling"))
        {
            
            DissableColliderAndDamage();
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("DoneFalling"))
        {

            DissableColliderAndDamage();
        }

    }

    public void DissableColliderAndDamage()
	{
        if (_triggerCameraShake.shakeDuration <= 0) { 
            Obj.tag = "DoneFalling";
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            collider.isTrigger = true;
        }

    }


}
