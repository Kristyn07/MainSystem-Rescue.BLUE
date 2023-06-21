using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    public GameObject[] Players;
    public GameObject CameraFollow;
    public float XAxis;
    public float[] PosX;
    
    public float DefaultPosX = 0;
    public float DefaultPosY = 0;
    
    private void Start()
	{
        //DefaultPosX = 0;
       
        

    }
	private void Update()
	{
        
        GetPos();
       
	}
	
	void GetPos()
	{
        XAxis = CameraFollow.transform.position.x;
        float y = Players[0].transform.position.y;
        float z = Players[0].transform.position.z;

            PosX[0] = Players[0].transform.position.x;
            PosX[1] = Players[1].transform.position.x;
            PosX[2] = Players[2].transform.position.x;

       foreach (GameObject obj in Players)
		{
            obj.transform.position = new Vector3(XAxis, y, z);
        }
    }

    public void ResetPos()
	{
        //DefaultPosX = CameraFollow.transform.position.x;
        //float y = Players[0].transform.position.y;
        float z = Players[0].transform.position.z;
        CameraFollow.transform.position = new Vector3(DefaultPosX, DefaultPosY, z);

        foreach (GameObject obj in Players)
        {
            obj.transform.position = new Vector3(DefaultPosX, DefaultPosY, z);
        }
    }

}
