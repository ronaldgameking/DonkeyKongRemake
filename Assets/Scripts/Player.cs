using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private GameObject powerZone;

    private float inputX;
    private float inputY;
    private float powerUpTime = 0f;
    private Rigidbody2D rb;

    public bool onGround { get; private set; }
    public bool canClimb { get; private set; }
    public bool hasJumped { get; private set; }
    public bool hasPowerUp { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powerZone.SetActive(false);
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

        if (powerUpTime > 0f)
        {
            powerUpTime = powerUpTime - Time.deltaTime;
            hasPowerUp = true;
        }
        else
        {
            powerUpTime = 0f;
            hasPowerUp = false;
        }

        if (hasPowerUp == true)
        {
            powerZone.SetActive(true);
        }
        else
        {
            powerZone.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onGround = false;
        }
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

    public void SetHasPowerUp(bool powerUpState)
    {
        hasPowerUp = powerUpState;
    }

    public void SetPowerUpTime(float powerTime)
    {
        powerUpTime = powerTime;
    }
}
