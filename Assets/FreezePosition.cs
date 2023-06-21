using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePosition : MonoBehaviour
{
    [SerializeField] Collider2D Table;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbodyConnector;
    public float radius = 1f;
    private void Start()
	{
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbodyConnector = GetComponent<Rigidbody2D>();

    }
	private void Update()
	{

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        if (colliders.Length == 1 && colliders[0] == boxCollider) // only overlaps with self
        {
            //Debug.Log("Collider doesn't have another collider");
            rigidbodyConnector.constraints = RigidbodyConstraints2D.None;
        }
		else
		{
            rigidbodyConnector.constraints = RigidbodyConstraints2D.FreezePosition;
        }

    }
	private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        BoxCollider2D otherBoxCollider = otherCollider.GetComponent<BoxCollider2D>();
        //Debug.Log(" has entered the trigger!");

        if (otherBoxCollider == Table)
        {
            // Compare the bounds of the UI Image and the other collider
            if (boxCollider.bounds.Intersects(otherBoxCollider.bounds))
            {
                rigidbodyConnector.constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
    }
    
}
