using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceHealth : MonoBehaviour
{
	[SerializeField] TyphoonGamePlayStage09 _typhoonGamePlayStage09;
	[SerializeField] BoxCollider2D boxCollider;


	void OnTriggerEnter2D(Collider2D other)
	{
		// Check if the object has the "Player" tag and is within the box collider
		if (other.CompareTag("Main Player") && boxCollider.bounds.Contains(other.transform.position))
		{
			
			
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		// Check if the object has the "Player" tag and is within the box collider
		if (other.CompareTag("Main Player") && boxCollider.bounds.Contains(other.transform.position))
		{
			// Perform some action here
			_typhoonGamePlayStage09.ReduceHealthWhenGoOut();
			Debug.Log("Player is within box collider");
		}
	}
}
