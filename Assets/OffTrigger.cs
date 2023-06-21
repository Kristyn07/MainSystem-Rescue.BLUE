using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OffTrigger : MonoBehaviour
{
	[SerializeField] Collider2D[] FallingObjectColliders;
	[SerializeField] Collider2D[] FallingObjectAdjusment;
	[SerializeField] Collider2D[] Shaking;
	public void Awake()
	{
		OffColliderAtStart();
	}

	public void Start()
	{
		//OffColliderAtStart();
		//Invoke("OnStart", 3f);
		//OnStart();
	}
	public void OffColliderAtStart()
	{
		foreach(Collider2D col in FallingObjectColliders)
		{
			col.enabled = false;
			col.isTrigger = true;
		}
	}
	public void OnColliderTrigger()
	{
		foreach (Collider2D col in FallingObjectColliders)
		{
			col.enabled = true;
		}

		foreach (Collider2D col in FallingObjectAdjusment)
		{
			col.enabled = false;
		}

	}

	public void OnStart()
	{
		gameObject.SetActive(false);
	}

	public void OnCollider2d()
	{
		foreach (Collider2D col in Shaking)
		{
			col.enabled = true;
		}
	}
}
