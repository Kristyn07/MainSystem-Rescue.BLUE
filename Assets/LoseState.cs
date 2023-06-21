using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoseState : MonoBehaviour
{
    [SerializeField] Slider HealthBar;
    [SerializeField] GameObject RetryMG;
    [SerializeField] Image[] Buttons;
    private void Update()
    {
        if (HealthBar.value == 0)
        {
            RetryMG.SetActive(true);
            foreach (Image obj in Buttons)
			{
                obj.enabled = false;
			}
        }

    }

    public void TryAgain()
	{
        
        foreach (Image obj in Buttons)
        {
            obj.enabled = true;
        }
    }
}
