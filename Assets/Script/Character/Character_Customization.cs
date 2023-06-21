using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Customization : MonoBehaviour
{
    //Randomized bodyparts
    public List<Outfitchanger> outfitchangers = new List<Outfitchanger>();
    public void RandomizeCharacter()
    {
        foreach (Outfitchanger changer in outfitchangers)
        {
            changer.Randomize();
        }
    }
}
