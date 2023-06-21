using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDCH : MonoBehaviour
{
	public bool DissableDamage;
    [SerializeField] Slider HealthBar;
	[SerializeField] GameObject[] FallingObj;
	[SerializeField] float maxHealth = 100f;
	[SerializeField] float currentHealth;
	[Header("MiniGame")]
	[SerializeField] float ReduceHealth;//minigame

	
	private void Start()
	{
			HealthBar.maxValue = maxHealth;
			HealthBar.value = currentHealth;
		
		
	}
	public void Damage()
	{
		if(DissableDamage == false) { 
			
				currentHealth -= ReduceHealth; // subtract the damage amount from the current health

				if (currentHealth <= 0f) // if the current health is less than or equal to zero
				{
					currentHealth = 0f; // set the current health to zero
					Debug.Log("Player is dead"); // display a message in the console
				}
			
			HealthBar.value = currentHealth; // update the HealthBar UI element to reflect the current health
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (DissableDamage == false)
		{
			
				if (collision.gameObject.CompareTag("FallingObj")) // if the player collides with an object tagged "FallingObj"
				{
					//Debug.Log("ReduceHealth");
					Damage(); // reduce the player's health by 10
				}
			
		}
	}

	public void Replay()
	{
		currentHealth = maxHealth;
		HealthBar.value = currentHealth;
			
	}


}
