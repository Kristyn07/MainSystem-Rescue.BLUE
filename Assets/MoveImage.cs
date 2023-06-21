using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour
{
	[SerializeField] UIMovementScript L_UIMovementScript;
	[SerializeField] UIMovementScript R_UIMovementScript;
    public float moveSpeed = 10.0f;
    public float smoothing = 5.0f;
    public Vector3 movementLimit = new Vector3(5.0f, 0, 0);

    private RectTransform rectTransform;
    private Vector3 targetPos;

	private void Start()
	{
        rectTransform = GetComponent<RectTransform>();
        targetPos = rectTransform.localPosition;
    }

	private void Update()
	{
        if (L_UIMovementScript.buttonPressed == true )
        {
            MoveLeft();
        }
        if (R_UIMovementScript.buttonPressed == true)
        {
            MoveRight();
        }
    }

    public void MoveLeft()
    {
        targetPos.x = Mathf.Max(targetPos.x - moveSpeed, -movementLimit.x);
    }

    public void MoveRight()
    {
        targetPos.x = Mathf.Min(targetPos.x + moveSpeed, movementLimit.x);
    }

}
