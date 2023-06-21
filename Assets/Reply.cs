using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reply : MonoBehaviour
{
    //this is for tutorial mode in scene 1 
	public void SetIntReply(int SceneReply_)//set 1 when reply and 0 where restart new game
	{
        if (SceneReply_ == 1)
		{
            int SceneReply = SceneReply_;
            //ReplyScene = 1;
            PlayerPrefs.SetInt("Reply", SceneReply);
            PlayerPrefs.Save();
        }
        else if (SceneReply_ == 0)
		{
            int SceneReply = SceneReply_;
            //ReplyScene = 0;
            PlayerPrefs.SetInt("Reply", SceneReply);
            PlayerPrefs.Save();
        }
    } 
}
