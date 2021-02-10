using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private float inputX;
    private float inputY;
    private Rigidbody2D rb;

    private bool onGround;
    private bool canClimb;
    public bool hasJumped { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onGround = true;
        canClimb = false;
    }

    void FixedUpdate()
    {
        inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(inputX, 0);
        rb.AddForce(movement * speed);

        if (inputX < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

        }
        else if (inputX > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else 
        { 
            rb.velocity = new Vector2(0, rb.velocity.y);         
        }

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            rb.AddForce(transform.up * jumpPower);
            hasJumped = true;
        }

        if (canClimb == true && Input.GetKey(KeyCode.W))
        {
            inputY = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.position.x, inputY + speed);
            hasJumped = false;
        }
        else if (canClimb == true && Input.GetKey(KeyCode.S))
        {
            inputY = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.position.x, inputY - speed);
            hasJumped = false;
        }

        if (canClimb == true && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = 0;
            hasJumped = false;
        }
        else
        {
            rb.gravityScale = 1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }

        if (canClimb == true && !Input.GetKey(KeyCode.W))
        {
            if (!Input.GetKey(KeyCode.S) && hasJumped == false)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
        else
        {
            rb.isKinematic = false;
        }
    }

    public bool GetCanClimb()
    {
        return canClimb;
    }

    public bool GetOnGround()
    {
        return onGround;
    }

    public bool GetHasJumped()
    {
        return hasJumped;
    }

    public void SetCanClimb(bool climbState)
    {
        canClimb = climbState;
    }

    public void SetOnGround(bool groundState)
    {
        onGround = groundState;
    }

    public void SetHasJumped(bool jumpedState)
    {
        hasJumped = jumpedState;
    }
}
