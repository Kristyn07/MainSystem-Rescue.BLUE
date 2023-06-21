using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayManager.Level3
{

	public class RandomizePosition : MonoBehaviour
	{
		[Header("Get position")]
		[SerializeField] GameObject[] GetTransformPosition;
		[SerializeField] Vector3[] Position;
		[Header("RandomizePosition")]
		//[SerializeField] float[] xPos, yPos, zPos;
		//[SerializeField] Vector3 randomX;
		[SerializeField] int randomIndexClassA;
		[SerializeField] int randomIndexClassB;
		[SerializeField] int randomIndexClassC;
		[SerializeField] int randomIndexClassD;
		[SerializeField] int randomIndexClassK;
		[SerializeField] Vector3[] randomPos;
		//[SerializeField] int[] randomIndexClass;
		[Header("HiddenPapers")]
		[SerializeField] GameObject[] HiddenPapers;

		

		public void Start()
		{
			GetVector();
			
		}
		public void GetVector()
		{
			Position = new Vector3[GetTransformPosition.Length];
			for (int i = 0; i < GetTransformPosition.Length; i++)
			{
				Position[i] = GetTransformPosition[i].transform.position;
			}
			RandomizePositionGameObj();
			RelocateGameObject();
		}

		public void RandomizePositionGameObj()
		{

			randomIndexClassA = Random.Range(0, Position.Length);
			randomIndexClassB = Random.Range(0, Position.Length);
			randomIndexClassC = Random.Range(0, Position.Length);
			randomIndexClassD = Random.Range(0, Position.Length);
			randomIndexClassK = Random.Range(0, Position.Length);

			//CLASSA
			while (randomIndexClassA == randomIndexClassB || randomIndexClassA == randomIndexClassC || randomIndexClassA == randomIndexClassD || randomIndexClassA == randomIndexClassK)
			{
				randomIndexClassB = Random.Range(0, Position.Length);
			}
			//CLASSB
			while (randomIndexClassB == randomIndexClassA || randomIndexClassB == randomIndexClassC || randomIndexClassB == randomIndexClassD || randomIndexClassB == randomIndexClassK)
			{
				randomIndexClassB = Random.Range(0, Position.Length);
			}

			//CLASSC
			while (randomIndexClassC == randomIndexClassA || randomIndexClassC == randomIndexClassB || randomIndexClassC == randomIndexClassD || randomIndexClassC == randomIndexClassK)
			{
				randomIndexClassC = Random.Range(0, Position.Length);

			}

			//CLASSD
			while (randomIndexClassD == randomIndexClassA || randomIndexClassD == randomIndexClassB || randomIndexClassD == randomIndexClassC || randomIndexClassD == randomIndexClassK)
			{
				randomIndexClassD = Random.Range(0, Position.Length);

			}
			
			//CLASSK
			while (randomIndexClassK == randomIndexClassA || randomIndexClassK == randomIndexClassB || randomIndexClassK == randomIndexClassC || randomIndexClassK == randomIndexClassD)
			{
				randomIndexClassK = Random.Range(0, Position.Length);
			}
			
			randomPos[0] = Position[randomIndexClassA];
			randomPos[1] = Position[randomIndexClassB];
			randomPos[2] = Position[randomIndexClassC];
			randomPos[3] = Position[randomIndexClassD];
			randomPos[4] = Position[randomIndexClassK];

			
		}
		public void RelocateGameObject()
		{
			HiddenPapers[0].transform.position = randomPos[0];
			HiddenPapers[1].transform.position = randomPos[1];
			HiddenPapers[2].transform.position = randomPos[2];
			HiddenPapers[3].transform.position = randomPos[3];
			HiddenPapers[4].transform.position = randomPos[4];
		}
	} 



}

