using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inpect_Info : MonoBehaviour
{
    public bool isTouching;
    public Button inspectInfoButton;
    public Rigidbody2D player;
    public BoxCollider2D Educ_TriangularBandageInfoDesk;
    public GameObject ActiveInteractable;
    public List<GameObject> info_windows = new List<GameObject>();

    void Start()
    {
        inspectInfoButton.onClick.AddListener(InspectInfo_TriangularBandage);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("In range of infomartion.");

        if (collider == Educ_TriangularBandageInfoDesk)
        {
            Debug.Log("TriangularBandage");
        }
        
    }
    void OnTriggerStay2D(Collider2D collider)
    {   
        isTouching = true;
        if (collider == Educ_TriangularBandageInfoDesk)
        {
            ActiveInteractable = info_windows[2];
            inspectInfoButton.gameObject.SetActive(true);
        }          
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Not in range of informations");
        isTouching = false;   
        inspectInfoButton.gameObject.SetActive(false); 
    }
    public void InspectInfo_TriangularBandage()
    {

        if (isTouching == true && ActiveInteractable == info_windows[2])//&& objs[0].isComplete == false
        { 
            ActiveInteractable.SetActive(true);
            info_windows[2].SetActive(true);
            info_windows[0].SetActive(false); // deact canvas main overworld btn's  
        }
        
    }
}
