using UnityEngine;
using UnityEngine.EventSystems;
using GameplayManager.Level;
using UnityEngine.UI;
using System.Collections;
/*public class ButtonScript : MonoBehaviour, IPointerClickHandler
{
[SerializeField] ExtinguisherClassesDragAndDrop _extinguisherClassesDragAndDrop;
[SerializeField] HiddenPaperObj _hiddenPaperObj;

[SerializeField] GameObject ClassA_Symbol;
[SerializeField] GameObject ClassA_Paper;
[SerializeField] GameObject ClassA_Info;
[SerializeField] GameObject ClassA_OnBoard;


public void OnPointerClick(PointerEventData eventData)
{
_extinguisherClassesDragAndDrop.RelocateItems(ClassA_Symbol);
_hiddenPaperObj.FoundObject(ClassA_Paper);
_hiddenPaperObj.ClassesFound(ClassA_Info);
_hiddenPaperObj.ActivateLetter(ClassA_OnBoard);

}*/

public class ButtonScript : MonoBehaviour
{
    private Renderer rend;
    public Color touchColor;

    [SerializeField] ExtinguisherClassesDragAndDrop _extinguisherClassesDragAndDrop;
    [SerializeField] HiddenPaperObj _hiddenPaperObj;

    [SerializeField] GameObject Class_Symbol;
    [SerializeField] GameObject Class_Letter;
    [SerializeField] GameObject Class_Paper;
    [SerializeField] GameObject Class_Info;
    [SerializeField] GameObject Class_OnBoard;

    /*private void Start()
    {
        rend = GetComponent<Renderer>();
    }
*/
    /* public void Update()
     {
         Debug.Log("update");
         // Check if the player has touched the screen
         if (Input.touchCount > 0)
         {
             Touch touch = Input.GetTouch(0);
             Debug.Log("touch");
            //Debug.Log(touch.position);
             //Debug.DrawLine(Camera.main.ScreenToWorldPoint(touch.position), Camera.main.ScreenToWorldPoint(touch.position) + Vector3.up, Color.red);

             // Check if the touch is within the bounds of the game object
             if (rend.bounds.Contains(Camera.main.ScreenToWorldPoint(touch.position)))
             {
                 Debug.Log("bounds");
                 // Check if the touch has ended
                 if (touch.phase == TouchPhase.Ended)
                 {
                     Debug.Log("end");
                     // Change the color of the game object
                     rend.material.color = touchColor;

                     _extinguisherClassesDragAndDrop.RelocateItems(Class_Symbol);
                     _hiddenPaperObj.FoundObject(Class_Paper);
                     _hiddenPaperObj.ClassesFound(Class_Info);
                     _hiddenPaperObj.ActivateLetter(Class_OnBoard);
                 }
             }
         }
     }*/

    /*private void Update()
	{
		// Check if the player has touched the screen
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == gameObject)
				{
					// Change the color of the game object
					rend.material.color = touchColor;
				}
			}
		}
	}*/

    // Reference to the collider component of the game object
    // Reference to the collider component of the game object
    private new Collider2D collider;
    [SerializeField] Camera cam;
    [SerializeField] RaycastHit2D hit;

    [SerializeField] bool Stage08;
    [SerializeField] GameObject Panel;
    [SerializeField] LevelGameplayManagerScript MainLevelPlay;

    [SerializeField] bool Stage09;
    [SerializeField] GameObject ItemPanel;
    [SerializeField] Image ItemImage;
    public Sprite ItemSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] TyphoonGamePlayStage09 _typhoonGamePlay;
    [SerializeField] GameObject ItemObj;
    //[SerializeField]  ItemImage;

    [SerializeField] bool Stage10;
    [SerializeField] GameObject ClassPanel;
    [SerializeField] Canvas ClassesOfFire;
    private void Start()
    {
        collider = GetComponent<Collider2D>();
        if (Stage09)
		{
            spriteRenderer = GetComponent<SpriteRenderer>(); // Get a reference to the SpriteRenderer component on this GameObject
            ItemSprite = spriteRenderer.sprite;
		}
        
    }

    private void Update()
    {
        // Check if the player has touched the screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //Debug.Log("Touch");
            // Cast a ray from the touch position to the scene
            Vector2 touchPos = cam.ScreenToWorldPoint(touch.position);
            hit = Physics2D.Raycast(touchPos, Vector2.zero);

            // Check if the ray intersects with the collider
            if (hit.collider == collider)
            {
                //Debug.Log("collide");
                // Check if the touch has ended
                if (touch.phase == TouchPhase.Ended)
                {
                    // Execute the button action
                    if (Stage08)
					{
                        MajorCausesOfFlooding();

                    }
                    else if (Stage09)
					{
                        InverntorySystem();
                    }
                    else if (Stage10)
					{
                        FireClassType();

                    }
					else
					{
                        ButtonAction(); // stage 03
                    }
                    
                    //Debug.Log("TouchEnd");
                }
            }
        }
    }

    public void ButtonAction()
    {
        _extinguisherClassesDragAndDrop.RelocateItems(Class_Symbol);
        _extinguisherClassesDragAndDrop.RelocateItems(Class_Letter);
        _hiddenPaperObj.FoundObject(Class_Paper);
        _hiddenPaperObj.ClassesFound(Class_Info);
        _hiddenPaperObj.ActivateLetter(Class_OnBoard);
    }

    public void MajorCausesOfFlooding()
	{
        Panel.SetActive(true);
        MainLevelPlay._Show_InspectMission();

    }//stage09

    public void InverntorySystem()
	{

        ItemImage.sprite = ItemSprite;
        ItemImage.SetNativeSize();
        ItemPanel.SetActive(true);
        _typhoonGamePlay.RelocateItems(ItemObj);
        StartCoroutine(DothisWhenDone());
        
        //MainLevelPlay._Show_InspectMission();
    }//stage09

    IEnumerator DothisWhenDone()
	{
        yield return new WaitForSeconds(2f);
        ItemPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    public void FireClassType()
	{
        ClassesOfFire.enabled = true;
        ClassPanel.SetActive(false);

    }
    public void CloseFireClassType()
    {
        ClassesOfFire.enabled = false;
        ClassPanel.SetActive(false);

    }
}
    

