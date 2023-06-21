using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogQueue : MonoBehaviour
{
    Queue<string> sentences;

	void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue _dialogue)
	{
		Debug.Log("Stating Dialog Conversation");
	}
}
