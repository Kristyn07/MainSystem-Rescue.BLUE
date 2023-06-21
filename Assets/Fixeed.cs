using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixeed : MonoBehaviour
{
    public GameObject[] Todeact;
    public GameObject Main;

    // Update is called once per frame
    void Update()
    {
        Activatavle();
    }

    void Activatavle()
    {
        if (Main.activeInHierarchy == true)
        {
            foreach (GameObject obj in Todeact)
            {
                obj.SetActive(false);
            }
        }
        else if (Main.activeInHierarchy == false){
            foreach (GameObject obj in Todeact)
            {
                obj.SetActive(true);
            }
        }
    }
}
