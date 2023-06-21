using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPRefsDeleteAll : MonoBehaviour
{
    [SerializeField] bool DeleteAllPre;
    void Start()
    {
        if (DeleteAllPre)
		{
            //detele all
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("Deleted All");
		}
    }

    
}
