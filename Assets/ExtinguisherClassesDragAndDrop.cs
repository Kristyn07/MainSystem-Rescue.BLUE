using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtinguisherClassesDragAndDrop : MonoBehaviour
{
	[Header("Complete")]
	public bool Completed;
	[SerializeField] GameObject CompletedAnim;
	[SerializeField] Stage03Complete MainStage;

	[Header("CheckPerClass")]
	[SerializeField] bool Class_A;
	[SerializeField] bool Class_B;
	[SerializeField] bool Class_C;
	[SerializeField] bool Class_D;
	[SerializeField] bool Class_K;

	[Header("SlotItem")]
	[SerializeField] Transform[] Slot_ParentObjectClass;
	[SerializeField] Transform[] Item_ChildObjectClass;

	[Header("RelocateItem")]
	[SerializeField] GameObject[] Items;
	[SerializeField] GameObject[] Item_ParentObjectClass;

	[Header("GamePlay")]
	[SerializeField] Canvas PlayerCanvas;
	[SerializeField] Canvas MiniGameCanvas;
	[SerializeField] GameObject MiniGameDragAndDrop;
	[SerializeField] Collider2D MiniGameDragAndDropCol;
	[Header("Configuration")]
	[SerializeField] bool Stage10;
	[SerializeField] GridLayoutRandomizer randompos;
	[SerializeField] GameObject[] Slots;
	[SerializeField] GameObject AnimationRetry;
	//[SerializeField] Vector3[] Position;

	public void CheckTheLoc()
	{
		//CLASS A
		if (Item_ChildObjectClass[0].IsChildOf(Slot_ParentObjectClass[0]) && Item_ChildObjectClass[5].IsChildOf(Slot_ParentObjectClass[5]))
		{
			Class_A = true;
		}
		else
		{
			Class_A = false;
		}

		//CLASS B
		if (Item_ChildObjectClass[1].IsChildOf(Slot_ParentObjectClass[1]) && Item_ChildObjectClass[6].IsChildOf(Slot_ParentObjectClass[6]))
		{
			Class_B = true;
		}
		else
		{
			Class_B = false;
		}

		//CLASS C
		if (Item_ChildObjectClass[2].IsChildOf(Slot_ParentObjectClass[2]) && Item_ChildObjectClass[7].IsChildOf(Slot_ParentObjectClass[7]))
		{
			Class_C = true;
		}
		else
		{
			Class_C = false;
		}

		//CLASS D
		if (Item_ChildObjectClass[3].IsChildOf(Slot_ParentObjectClass[3]) && Item_ChildObjectClass[8].IsChildOf(Slot_ParentObjectClass[8]))
		{
			Class_D = true;
		}
		else
		{
			Class_D = false;
		}

		//CLASS K
		if (Item_ChildObjectClass[4].IsChildOf(Slot_ParentObjectClass[4]) && Item_ChildObjectClass[9].IsChildOf(Slot_ParentObjectClass[9]))
		{
			Class_K = true;
		}
		else
		{
			Class_K = false;
		}


		//complete objective
		if (Class_A == true && Class_B == true && Class_C == true && Class_D == true && Class_K == true)
		{
			Completed = true;
			CompletedAnim.SetActive(true);
			StartCoroutine(MiniGameComplete());
			if (!Stage10) {
				MainStage.CheckCompletion();
			}
			
		}
		else
		{
			Completed = false;
			if (Stage10)
			{
				bool allSlotsFilled = true;

				foreach (GameObject obj in Slots)
				{
					if (obj.transform.childCount != 1)
					{
						allSlotsFilled = false;
						break;
					}
				}

				if (allSlotsFilled)
				{
					AnimationRetry.SetActive(true);
					Retry();
					randompos.RandomizeGridLayout();
				}
			}
		}
	}

		public void RelocateItems(GameObject ItemObj)
		{
			//Debug.Log("pressed");
			for (int i = 0; i < Item_ParentObjectClass.Length; i++)
			{
				if (Item_ParentObjectClass[i].transform.childCount == 0)
				{
					ItemObj.transform.SetParent(Item_ParentObjectClass[i].transform);
				}
				else
				{
					i++;
				}
			}

		}

		public void Retry()
		{

			foreach (Transform parent in Slot_ParentObjectClass)
			{
				for (int i = 0; i < parent.transform.childCount; i++)
				{
					Transform child = parent.transform.GetChild(i);
					RelocateItems(child.gameObject);
				}
			}
		}

		IEnumerator MiniGameComplete()
		{
			if (Stage10)
			{
				yield return new WaitForSeconds(2.7f);
			}
			else
			{
				yield return new WaitForSeconds(2.8f);
			}
			PlayerCanvas.enabled = true;
			MiniGameCanvas.enabled = false;
			MiniGameDragAndDrop.gameObject.SetActive(false);
			MiniGameDragAndDropCol.enabled = false;
		}
	}
