using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outfitchanger : MonoBehaviour
{
    [Header("Sprite To Change")]
    public SpriteRenderer bodyParts;

    public List<Sprite> options = new List<Sprite>();

    private int currentOption = 0;

    public void NextOption()
    {
        currentOption++;
        if (currentOption >= options.Count)
        {
            currentOption = 0; // reset cycle
            
        }
        // Debug.Log("next " + currentOption); fixing out of range done edited line 19 and 40
        bodyParts.sprite = options[currentOption];
    }

    public void PreviousOption()
    {
        currentOption--;
        if (currentOption < 0)
        {
            currentOption = options.Count - 1; // reset id cycled through entire list   
        }
        // Debug.Log("Previous" + currentOption); fixing out of range done
        bodyParts.sprite = options[currentOption];

    }

    public void Randomize()
    {
        currentOption = Random.Range(0, options.Count ); // removed - 1 at next to options.Count
        bodyParts.sprite = options[currentOption];
    }

}