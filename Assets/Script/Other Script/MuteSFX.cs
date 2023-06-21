using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSFX : MonoBehaviour
{
    [Header("SFX Mute Manager")]

    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button button;
    //public MuteSFX_Manager _mutemanager;

   /* public void SwitchButton()
    {
        if (button.image.sprite == OnSprite)
        {
            _mutemanager.Mute_OnButtonPressed();
            button.image.sprite = OffSprite;
            button.image.color = Color.grey; // darken color


        }
        else if (button.image.sprite == OffSprite)
        {
            _mutemanager.Unmute_OnButtonPressed();
            button.image.sprite = OnSprite;
            button.image.color = Color.white; // reset color

        }
    }*/
}
