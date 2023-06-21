using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainScene.Manager
{
    public class MainMenuManagerScript : MonoBehaviour //optimized
    {
        public int ContinueCount;
        [SerializeField]
        Button ContinueButton;
        [SerializeField] SceneLoader _loadScene;
        void Awake()
        {
            ContinueCount = PlayerPrefs.GetInt("Continue");
            //Debug.Log(PlayerPrefs.GetInt("Continue"));
            //ContinueFartestStage = PlayerPrefs.GetInt("StageSelection");
        }

		
		
        public void QuitButton()
        {
            Application.Quit();
        }
        public void ContiueButton()
        {
            //_loadScene.LoadContinueScene();
            SoundEffect();
            _loadScene.LoadScene(PlayerPrefs.GetInt("StageSelection") + 1);
            //SceneManager.LoadScene((PlayerPrefs.GetInt("StageSelection")+1));
            //SceneManager.LoadScene(ContinueCount);
        }

        public void HidePanel(GameObject gameObjectID)
        {
            SoundEffect();
            gameObjectID.gameObject.SetActive(false);
        }
        public void NSHidePanel(GameObject gameObjectID)
        {
            gameObjectID.gameObject.SetActive(false);
        }

        public void ShowPanel(GameObject gameObjectID)
        {
            SoundEffect();
            gameObjectID.gameObject.SetActive(true);

        }
        public void NSShowPanel(GameObject gameObjectID)
        {
            gameObjectID.gameObject.SetActive(true);

        }

        void SoundEffect()
        {
            SoundEffectScript.instance.Play(SoundEffectScript.instance.SoundButton);
        }
    }
}

