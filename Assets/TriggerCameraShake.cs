using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[DefaultExecutionOrder(-100)]
public class TriggerCameraShake : MonoBehaviour
{
	public bool shake;
	[SerializeField] CameraShake _cameraShake;
	public float shakeDuration ;
	public float shakeMagnitude ;
	public float DefaultDuration;
	public float DefaultMagnitude;
	
	public void Start()
	{
		DefaultDuration = shakeDuration;
		DefaultMagnitude = shakeMagnitude;
	}
	public void Update()
	{

		if (shake == true)
		{
			StartCoroutine(_cameraShake.Shake(shakeDuration, shakeMagnitude));
			shakeDuration--;

			if (shakeDuration > 0)
			{
				if (PlayerPrefs.GetInt("VibrationToggle") == 1)
				{
					Handheld.Vibrate();
					Debug.Log("vibrate");
				}
			}
			else
			{
				//Handheld.Vibrate();
			}

			if (shakeDuration <= 0)
			{
				shake = false;

				//shakeDuration = 15;
			}
		}


		
	}





	public void SetShakeDuration(float ShakeDuration)
	{
		ShakeDuration = shakeDuration;
	}

	public void SetShakeMagnitude(float ShakeMagnitude)
	{
		ShakeMagnitude = shakeMagnitude;
	}

	public void Shaking()
	{
		shake = true;
	}

	public void StopShaking()
	{
		shake = false;
	}

	private IEnumerator ShakeCoroutine()
	{
		float remainingShakeDuration = shakeDuration;

		while (remainingShakeDuration > 0)
		{
			yield return StartCoroutine(_cameraShake.Shake(Mathf.Min(remainingShakeDuration, shakeDuration), shakeMagnitude));

			remainingShakeDuration -= shakeDuration;

			// Optionally, add a delay before shaking the camera again
			float delay = 0.05f;
			yield return new WaitForSeconds(delay);
		}

		// Reset the shake flag when the shake duration is over
		shake = false;
		shakeDuration = DefaultDuration;
	}

	public void ResetShakeCam()
	{
		shakeDuration = DefaultDuration;
	}
}
