using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
	[SerializeField] Collider2D[] ColliderObj;
	[SerializeField] T3_DropCoverHold_AnimationAndController _t3_DropCoverHold_AnimationAndController;
	[SerializeField] GameObject StandButton;
	//[SerializeField] Standing

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("DefenseObj")) // if the player collides with an object tagged "Obstacle"
		{
			Debug.Log("UnderStuffs");
			foreach(Collider2D col in ColliderObj)
			{
				col.isTrigger = false;

			}
			//dissable standing
			StandButton.SetActive(false);
		}
	}
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("DefenseObj")) // if the player collides with an object tagged "Obstacle"
		{
			Debug.Log("IsUnderStuff");
			Debug.Log("UnderStuffs");
			foreach (Collider2D col in ColliderObj)
			{
				col.isTrigger = false;

			}
			//dissable standing
			_t3_DropCoverHold_AnimationAndController.IsStanding = false;
			
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		
	}
}

