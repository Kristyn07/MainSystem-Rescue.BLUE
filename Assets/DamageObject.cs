using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
	public float DamageReduce;
	public bool EnableDamage;
	[SerializeField] bool AdjustDamageStage6;
	public void Start()
	{
		if (AdjustDamageStage6) // multiple by 1.6;
		{
			DamageReduce *= 1.6f;
		}
	}
	public void Update()
	{
		if (gameObject.CompareTag("DoneFalling"))
		{
			EnableDamage = false;
		}
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Main Player")) // if the player collides with an object tagged "Obstacle"
		{
			EnableDamage = true;
			
		}

	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Main Player")) // if the player collides with an object tagged "Obstacle"
		{
			EnableDamage = false;
			


		}



	}
}
