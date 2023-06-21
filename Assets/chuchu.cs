using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class chuchu : MonoBehaviour
{
    //public string name;
    [SerializeField] Text txt;
    [SerializeField] TextMeshProUGUI txtmp;
    // Start is called before the first frame update
    void Start()
    {
        txtT();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void txtT()
	{
        txt.text = "dsadsaa";
	}

    public void TMPtext()
	{
        txtmp.text = "BB";
	}
}
