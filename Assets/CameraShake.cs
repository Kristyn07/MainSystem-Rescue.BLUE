using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
        private Vector3 originalPos;


        public IEnumerator Shake(float duration, float magnitude)
        {
        Debug.Log("isShaking");
            originalPos = transform.localPosition;
            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;
                float z = 0f; // no need to shake on z-axis

                // add some randomness to the shake effect
                magnitude = Mathf.Lerp(magnitude, 0f, elapsed / duration);

                transform.localPosition = originalPos + new Vector3(x, y, z);

                elapsed += Time.deltaTime;

                yield return null;
            }
            transform.localPosition = originalPos;
        Debug.Log("test");
            
        }
    }


    /*[SerializeField] Vector3 originalPos;
    [SerializeField] GameObject MainCamPos;

	private void Update()
	{
        originalPos = MainCamPos.transform.localPosition;
    }
	public IEnumerator Shake(float duration, float magnitude)
    {

          Vector3 originalPos = transform.localPosition;

          float elapsed = 0.0f;

          while (elapsed < duration) {
           float x = Random.Range(-1f,1f) * magnitude;
           float y = Random.Range(-1f,1f) * magnitude;
           float z = Random.Range(-1f,1f) * magnitude;

           //transform.localPosition = new Vector3 (x, y, z);
           transform.localPosition = new Vector3 (originalPos.x + x, originalPos.y + y, originalPos.z + z);

           elapsed += Time.deltaTime;

           yield return null;
          }

          transform.localPosition = originalPos;
    }*/
