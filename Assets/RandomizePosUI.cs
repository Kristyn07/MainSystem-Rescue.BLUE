using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class RandomizePosUI : MonoBehaviour
{
  
    public GameObject[] gameObjects;
    public Transform[] positions;

    void Start()
    {

        /* for (int i = 0; i < positions.Length; i++)
         {
             int randomIndex = Random.Range(i, positions.Length);
             Transform temp = positions[randomIndex];
             positions[randomIndex] = positions[i];
             positions[i] = temp;
         }
         gameObjects[0].transform.position = positions[0].position;
         gameObjects[1].transform.position = positions[1].position;
         gameObjects[2].transform.position = positions[2].position;
         gameObjects[3].transform.position = positions[3].position;
         gameObjects[4].transform.position = positions[4].position;
         gameObjects[5].transform.position = positions[5].position;*/

        // Create a HashSet to store unique positions
        HashSet<Vector3> uniquePositions = new HashSet<Vector3>();

        // Add the initial positions to the HashSet
        for (int i = 0; i < positions.Length; i++)
        {
            uniquePositions.Add(positions[i].position);
        }

        // Shuffle the unique positions
        Vector3[] shuffledPositions = uniquePositions.ToArray();
        for (int i = 0; i < shuffledPositions.Length; i++)
        {
            int randomIndex = Random.Range(i, shuffledPositions.Length);
            Vector3 temp = shuffledPositions[randomIndex];
            shuffledPositions[randomIndex] = shuffledPositions[i];
            shuffledPositions[i] = temp;
        }

        // Set the positions of the game objects using the shuffled positions
        gameObjects[0].transform.position = shuffledPositions[0];
        gameObjects[1].transform.position = shuffledPositions[1];
        gameObjects[2].transform.position = shuffledPositions[2];
        gameObjects[3].transform.position = shuffledPositions[3];
        gameObjects[4].transform.position = shuffledPositions[4];
        gameObjects[5].transform.position = shuffledPositions[5];

    }
}
   

