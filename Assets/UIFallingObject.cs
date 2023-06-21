using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFallingObject : MonoBehaviour
{
    [SerializeField] GameObject FallingObject;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float GravityOrSpeed;

	[SerializeField] Collider2D Player;
	[SerializeField] Collider2D FallingObject_Collider;
	[SerializeField] RectTransform PlayerTransformpos;

	[SerializeField] int count;
	[SerializeField] GameObject MainLayoutOFFallingObjects;


	[SerializeField] Slider SliderHealth;
	private void Start()
	{
		rb.gravityScale = GravityOrSpeed;
		for (int i = 0; i < count; i++)
		{
			GameObject newUI = Instantiate(FallingObject, FallingObject.transform.position, Quaternion.identity);
			newUI.transform.SetParent(MainLayoutOFFallingObjects.transform);
		}
	}

	private void Update()
	{
		if (FallingObject_Collider.IsTouching(Player))
		{
			Debug.Log("collided");
			
			SliderHealth.value =- 0.01f;
		}
	}






}
