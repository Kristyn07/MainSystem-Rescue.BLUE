using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShakeCameraCollider : MonoBehaviour
{
    [SerializeField] BoxCollider2D Player;
    [SerializeField] TriggerCameraShake _triggerCameraShake;
	[SerializeField] BoxCollider2D TriggerSpot;
    
    [Header("Falling Object")]
    [SerializeField] Rigidbody2D[] FallingObjRB;
    [SerializeField] float FallingObjGravityScale;
    [SerializeField] Collider2D[] ColFallingObj;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _triggerCameraShake.shake = true;
            foreach (Rigidbody2D rb in FallingObjRB)
			{
                rb.gravityScale = FallingObjGravityScale;
			}
            foreach (Rigidbody2D rb in FallingObjRB)
            {
                rb.gravityScale = 1;
            }
        }
        else if (other.CompareTag("Main Player"))
		{
            _triggerCameraShake.shake = true;
            foreach(Collider2D col in ColFallingObj)
			{
                col.enabled = true;
                col.isTrigger = false;
			}
            foreach (Rigidbody2D rb in FallingObjRB)
            {
                rb.gravityScale = FallingObjGravityScale;
            }
            foreach (Rigidbody2D rb in FallingObjRB)
            {
                rb.gravityScale = 1;
            }
        }
    }

    public void resetTrigger()
	{
        foreach (Rigidbody2D rb in FallingObjRB)
        {
            rb.gravityScale = 0;
        }
    }
}
