using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissableDamage : MonoBehaviour
{
	
	PolygonCollider2D DamageCol;
	//Collider2D 
	Rigidbody2D DamageRb;
	public bool IsDoneFalling;
	//[SerializeField] HealthBarDCH healthBarDCH;
	//[SerializeField] Collider2D TriggerShakeCam;
	public void Start()
	{
		DamageCol = GetComponent<PolygonCollider2D>();
		DamageRb = GetComponent<Rigidbody2D>();
		
		
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{

			if (collision.gameObject.CompareTag("Tilemap")) // if the player collides with an object tagged "Obstacle"
			{	
					DamageCol.isTrigger = true;	
					DamageRb.gravityScale = 0;
					IsDoneFalling = true;
					/*if (IsDoneFalling)
					{
						healthBarDCH.DissableDamage = true;
					}*/
					//TriggerShakeCam.enabled = false;
			}

			if (collision.gameObject.CompareTag("Main Player"))
			{
					DamageCol.isTrigger = false;	

			}

			
	}
	/*private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Tilemap")) // if the player collides with an object tagged "Obstacle"
		{
			DamageCol.isTrigger = true;
			DamageRb.gravityScale = 0;
			DamageRb.constraints = RigidbodyConstraints2D.FreezePositionY;
			IsDoneFalling = true;
			*//*if (IsDoneFalling)
			{
				healthBarDCH.DissableDamage = false;
			}*//*
			//TriggerShakeCam.enabled = false;
		}

		if (collision.gameObject.CompareTag("Main Player"))
		{

			DamageCol.isTrigger = false;

		}
	}*/
}
