using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeFallingOBj : MonoBehaviour
{

    //private GameObject FallingObj;
    private Animator anim;
    private PolygonCollider2D PCollider;
    private Vector3 defaultPosition;
    private SpriteRenderer sprite;
    public void Start()
	{
            defaultPosition = transform.position;
            anim = GetComponent<Animator>();
            PCollider = GetComponent<PolygonCollider2D>();
            sprite = GetComponent<SpriteRenderer>();

    }
	public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tilemap") || other.CompareTag("DefenseObj"))
        {
            anim.enabled = true;
            PCollider.isTrigger = false;
        }
    }

    public void ResetPostion()
	{
        transform.position = defaultPosition;
        anim.enabled = false;
        PCollider.isTrigger = true;
        Color color = sprite.color;
        color.a = 1;
        sprite.color = color;
    }
}
