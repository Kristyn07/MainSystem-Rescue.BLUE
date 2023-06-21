

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotateItem : MonoBehaviour
{
    [SerializeField] GameObject[] Item;
    [SerializeField] GameObject[] Tiles;
    [SerializeField] GridFillerColliders[] tileCollider;
    float RotationValue = 90;
    Quaternion currentRotation;
    void Start()
    {

    }


    public void RotateObject()
    {
        foreach (GameObject obj in Item)
        {
            obj.transform.Rotate(0, 0, 90);
        }
        RotateEachTileItem();


    }
    public void RotateEachTileItem()
    {
        
        for (int i = 0; i < tileCollider.Length; i++)
        {
            GridFillerColliders collider = tileCollider[i];

            // Check if the tile is filled and rotate it if it is
            if (collider.isFilled == false)
            {
                /*if (collider.isFilled)
                    {*/
                GameObject tile = collider.gameObject;
                tile.transform.Rotate(0, 0, RotationValue);
                currentRotation = tile.transform.rotation;
                /*}*/
                

            }
            else
            {

            }
        }
       
    }

    public void ResetRotation()
    {
        float currentRotation = Item[0].GetComponent<Transform>().rotation.eulerAngles.z;
        

                foreach (GameObject obj in Tiles)
                {
                    obj.transform.rotation = Quaternion.Euler(0, 0, currentRotation);
                    // Check if the rotation was actually reset to (0, 0, 0)
                }
           
        }

    
}