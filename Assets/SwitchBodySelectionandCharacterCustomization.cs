using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchBodySelectionandCharacterCustomization : MonoBehaviour
{
    [SerializeField] GameObject Body;
    [SerializeField] GameObject SelectSkin;
    [SerializeField] Animator Anim;
    [SerializeField] bool IsInBody;
    [SerializeField] bool IsInSelectSkin;
   

  
    public void BodyState()
	{
        IsInBody = true;
        if (IsInBody == true)
		{
            IsInSelectSkin = false;
            Body.SetActive(true);
            SelectSkin.SetActive(false);
            //Anim.SetBool("isCustomizingBodyParts", true);
        }
		
    }

    public void SelectSkinState ()
    {
        IsInSelectSkin = true;
        if (IsInSelectSkin == true)
        {
            IsInBody = false;
            SelectSkin.SetActive(true);
            Body.SetActive(false);
            Anim.SetBool("isCustomizingBodyParts", false);
        }
		
    }

    public void CurrentState()
	{
        if (IsInBody == true)
		{
            BodyState();
        }

        else if (IsInSelectSkin == true)
		{
            SelectSkinState();
		}

    }



}
