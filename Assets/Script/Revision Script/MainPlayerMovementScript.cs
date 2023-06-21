using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovementScript : MonoBehaviour
{
    public
     float moveSpeed = 10f;
    Rigidbody2D rb;
    bool facingRight = true;
    Vector3 localScale;
    public
    float dirX;
    [SerializeField]
    Animator animator;

    bool MoveRight;
    bool MoveLeft;

   
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(dirX));
       
    }
    void FixedUpdate()
    {
        if (MoveRight == true)
        {
            rb.velocity = transform.right * moveSpeed;
        }

        if (MoveLeft == true)
        {
            rb.velocity = -transform.right * moveSpeed;
        }
        if (MoveRight == false && MoveLeft == false)
        {
            rb.velocity = Vector2.zero;
        }

    }
    void LateUpdate()
    {
        CheckWhereToFace();
    }
    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
    public void RightButton()
    {
        dirX = 1;
        MoveRight = true;
        MoveLeft = false;
    }

    public void LeftButton()
    {
        dirX = -1;
        MoveRight = false;
        MoveLeft = true;

    }

    public void IdleButton()
    {
        dirX = 0;
        MoveRight = false;
        MoveLeft = false;

    }
}
