using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaCollided : MonoBehaviour
{
    [SerializeField] private GameObject standButton;
    [SerializeField] bool IsNotAMiniGame;
    [Header("OnHold")]
    [SerializeField] GameObject Player;
    [SerializeField] T3_DropCoverHold_AnimationAndController DCHController;
    [SerializeField] HealthBarDCH healthbar; // this is for minigame
    [SerializeField] HealthBarPlayer healthbarplayer; // this is for the player

    SpriteRenderer playerSprite;
    Color DefaultColor;
    Color OnHoldColor;
    public bool IsInSafe;

    public void Start()
	{
        if (IsNotAMiniGame)
		{

		}
		else { 
        playerSprite = Player.GetComponent<SpriteRenderer>();
        DefaultColor = playerSprite.color;
        OnHoldColor = new Color(0f, 1f, 1f);
        }
    }

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player entered safe area.");
            standButton.SetActive(false);
            IsInSafe = true;

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player is staying in safe area.");
            standButton.SetActive(false);
            Hold();
            IsInSafe = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player exited safe area.");
            standButton.SetActive(true);
            IsInSafe = false;
        }

    }

    void Hold()
	{
        if (DCHController.OnHold == true)
        {
            //Defense the character;
            if (IsNotAMiniGame) 
            {
                //healthbarplayer.DissableDamage =true;
            }
			else { playerSprite.color = OnHoldColor;
                healthbar.DissableDamage = true;
            }
           
           

        }
        else
		{
            if (IsNotAMiniGame) 
            {
                //healthbarplayer.DissableDamage = true;
            }
            else { playerSprite.color = DefaultColor;
                healthbar.DissableDamage = false;
            }
           
            
        }
    }
        
    
}

