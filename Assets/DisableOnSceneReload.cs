using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisableOnSceneReload : MonoBehaviour
{
    public GameObject[] objectsToDisable;
    [SerializeField] RelocatePlayer _relocatePlayer;
    public Button Btn;

	private void Start()
	{
        Btn.onClick.AddListener(ButtonClicked);
    }
    void ButtonClicked()
    {
        Debug.Log("Button Clicked");
    }

    private void OnEnable()
    {
        //SceneManager.activeSceneChanged += OnActiveSceneChanged;

    }

    private void OnDisable()
    {
        //SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }

    private void OnActiveSceneChanged(Scene current, Scene next)
    {
        foreach (var obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
        _relocatePlayer.TutorialMode();

    }
}
