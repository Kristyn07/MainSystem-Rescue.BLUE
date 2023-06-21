using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeSpriteBTN : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button button;
    public MuteManager _mutemanager;

    public void ChangeImage()
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
    }
}
