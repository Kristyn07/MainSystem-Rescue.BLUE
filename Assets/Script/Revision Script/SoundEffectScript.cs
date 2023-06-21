using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectScript : MonoBehaviour
{
    public static SoundEffectScript instance = null;

    public AudioClip SoundButton;

    private AudioSource soundEffectAudio;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource[] sources = GetComponents<AudioSource>();

        foreach(AudioSource source in sources)
        {
            if(source.clip == null)
            {
                soundEffectAudio = source;
            }
        }
    }

    public void Play(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }

    
}
