using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRendererModeScript : MonoBehaviour
{
    [Header("MiniGames")]
    [SerializeField] GameObject FirstAidMN;
    [SerializeField] GameObject BandagingMN;
    [SerializeField] GameObject FireExtinguisher;
    [SerializeField] Canvas MiniGameCanvas;

    [Header("MiniGameCamera")]
    [SerializeField] GameObject MNCam;
    public void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //FirstAidMini Game 
        
        if (FirstAidMN.activeInHierarchy)
        {
            MiniGameCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            //Debug.Log("The game object is active.");
        }

        if (BandagingMN.activeInHierarchy)
        {

            MiniGameCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            //Debug.Log("The game object is active.");
        }

        if (FireExtinguisher.activeInHierarchy)
        {

            MiniGameCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            //MiniGameCanvas.renderMode = RenderMode.ScreenSpaceOverla
            //Debug.Log("The game object is active.");
        }


    }
}
