using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private LayerMask ground;
    public float speed, jumpSpeed;

    private Rigidbody2D rb;
    protected bool moveLeft;
    protected bool moveRight;
    private bool useAbility;
    protected float horizontalMovement;
    private Collider2D colider;

    public string ability;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<Collider2D>();

        moveLeft = false;
        moveRight = false;
        useAbility = false;
    }

    public void PointerDownAbility ()
    {
        useAbility = true;
    }
    public void PointerUpAbility ()
    {
        useAbility = false;
    }
    public void PointerDownLeft ()
    {
        moveLeft = true;
    }

    public void PointerUpLeft ()
    {
        moveLeft = false;
    }
    public void PointerDownRight ()
    {
        moveRight = true;
    }

    public void PointerUpRight ()
    {
        moveRight = false;
    }

    public void SlowCharacter ()
    {
        speed = 2;
        jumpSpeed = 4;
        ability = "slow";
    }
    public void MediumCharacter ()
    {
        speed = 4;
        jumpSpeed = 8;
        ability = "Medium";
    }
    public void FastCharacter ()
    {
        speed = 8;
        jumpSpeed = 16;
        ability = "fast";
    }

    public void Jump ()
    {
        if (IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }
    private bool IsGrounded ()
    {
        Vector2 feetPos = transform.position;
        feetPos.y -= colider.bounds.extents.y;
        return Physics2D.OverlapCircle(feetPos, .1f, ground);
    }
    void Update ()
    {
        MovePlayer();
        AbilityUsage();
    }

    private void MovePlayer ()
    {
        if (moveLeft)
        {
            horizontalMovement = -speed;
        }
        else if (moveRight)
        {
            horizontalMovement = speed;
        }
        else
        {
            horizontalMovement = 0;
        }
    }

    private void AbilityUsage ()
    {
        if (useAbility)
        {
            Debug.Log(ability);
        }
    }

    private void FixedUpdate ()
    {
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }
}