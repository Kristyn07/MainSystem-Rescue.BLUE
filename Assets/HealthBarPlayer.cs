using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarPlayer : MonoBehaviour
{
	public bool DissableDamage;
	[SerializeField] Slider HealthBar;
	[SerializeField] float MaximumHelth = 100;
	//[SerializeField] int CurrentHealth;
	[SerializeField] GameObject[] FallingObj;
	[SerializeField] float TotalDamageReduced;
	[SerializeField] float RemainingHealth;
	[SerializeField] DamageObject[] FallingObjDamage;
	[SerializeField] Rigidbody2D rb;
	[SerializeField] GameObject LoseState;
	//[SerializeField] Collider2D[] FallingObjCol;
	[SerializeField] TriggerCameraShake[] ShakinfOff;
	private void Start()
	{
		
		RemainingHealth = MaximumHelth;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (HealthBar.value != 0)
		{
			if (collision.gameObject.CompareTag("FallingObj")) // if the player collides with an object tagged "Obstacle"
			{
				rb.constraints = RigidbodyConstraints2D.FreezeAll;
				Damage();
				RemainingHealth = 100 - TotalDamageReduced;
				HealthBar.value = RemainingHealth;
			}
		}
		else
		{
			foreach (TriggerCameraShake shake in ShakinfOff)
			{
				shake.shake = false;
			}
			LoseState.SetActive(true);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("FallingObj")) // if the player collides with an object tagged "Obstacle"
		{
			
			rb.constraints = RigidbodyConstraints2D.FreezePositionY;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
		}
	}
			

	public void Damage() //calculate total damage
	{
		
		foreach (DamageObject script in FallingObjDamage)
		{
			if (script.EnableDamage == true)
			{
				float value = script.DamageReduce;
				TotalDamageReduced += value;
			}
		}
	}
}

