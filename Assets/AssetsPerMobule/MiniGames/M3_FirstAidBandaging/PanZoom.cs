//Panning and Zoom 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 1; // scale
    public float zoomOutMax = 5; // scale
    public float panningSpeed = 3; // speed drag
    public GameObject injuryIndicator;

    public Button ZoomoutButton;
    public float scale;

    private Vector3 initialScale;

    //[SerializeField]
    //private float zoomSpeed = 0.1f;
    [SerializeField]
    //private float maxZoom = 5f;
    public GameObject Choices;
    public GameObject MainDummy;

    //Display Mission
    [SerializeField]
    GameObject DisplayMission;
    [SerializeField]
    GameObject HideDummy;
    [SerializeField]
    GameObject ShowStageSelection;

    [SerializeField]
    CheckTheAnswer CheckTheAnswer;

    [HideInInspector]public bool DonePanzoom;
    private void Awake()
    {
        initialScale = transform.localScale;
    }
    void Start()
    {
        ZoomoutButton.onClick.AddListener(ZoomOut);
        DonePanzoom = false;

    }
    //public void DisplayMission03()
    //{
    //    DisplayMission.gameObject.gameObject.SetActive(true);
    //    HideDummy.gameObject.SetActive(false);
    //}
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }*/ // doesn't need cause were building mobile andriod game not a destop
        if (DonePanzoom == false)
		{
            if (Input.touchCount == 2) // for zooming 2 touch/finger to use
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;//panningmovement
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;//panmovement

                float difference = currentMagnitude - prevMagnitude;

                zoom(difference * 0.01f);


            }

            /*else if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameObject.transform.position -= direction * panningSpeed; 

            }*/// removed because it cause jittery
            zoom(Input.GetAxis("Mouse ScrollWheel"));
        }

        
    }
    void zoom(float increment)
    {
        
        float factor = Mathf.Clamp(gameObject.transform.localScale.x + increment, zoomOutMin, zoomOutMax);
        gameObject.transform.localScale = new Vector3(factor, factor, 0);

        
        if (4 <= factor && factor <= 5) // range scale within 4-5 to activate the injured indicator
        {
            //activate a light indicator where the injury is located
            //a button to activate objects that is needed for bandaging
            Debug.Log("activate light indicator");

            injuryIndicator.SetActive(true);
            /*if (CheckTheAnswer.injurydetected == false)
            {
                //ShowStageSelection.gameObject.SetActive(true);
            }

            if (CheckTheAnswer.injurydetected == true)
            {
                //HideDummy.gameObject.SetActive(false);
                //ShowStageSelection.gameObject.SetActive(false);
            }*/



            /*if (Choices.activeSelf == false){
                Choices.SetActive(true);
            }*/
        }
        else if (!(4 <= factor && factor <= 5))
        {
            Debug.Log("unable to detect injury");
            injuryIndicator.SetActive(false);

            /*if (Choices.activeSelf == true)
            {
                Choices.SetActive(false);
            }*/
        }


      

    }

    private Vector3 ClampDesiredScale(Vector3 desiredScale)
    {
        desiredScale = Vector3.Max(initialScale, desiredScale);
        desiredScale = Vector3.Min(initialScale * zoomOutMax, desiredScale);
        return desiredScale;

    }

    //trying new code double tap tp zoom in and out
    public void ZoomOut()
	{
        MainDummy.transform.localScale = transform.localScale + new Vector3(-6, -6, 0);
	}

    public void DissablePanzoom(GameObject gameObject)
	{
        DonePanzoom = true;
        Destroy(gameObject,5);
    }


}