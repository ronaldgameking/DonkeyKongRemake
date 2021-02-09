using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private float inputX;
    private Rigidbody2D rb;

    private bool onGround;
    private bool canClimb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onGround = true;
    }

    void FixedUpdate()
    {
        inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(inputX, 0);
        rb.AddForce(movement * speed);

        if (inputX < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }

        }

        else if (inputX > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
        else { rb.velocity = new Vector2(0, rb.velocity.y); }

        
    }

    private void Update()
    {

        //if (!onGround && rb.velocity.y == 0)
        //{
        //    onGround = true;
        //}


        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            rb.AddForce(transform.up * jumpPower);
            //onGround = false;
        }
    }
}
