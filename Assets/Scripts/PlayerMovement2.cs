using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    //public Health hp;

    // pelaajan nopeus
    public float speed;

    public float groundDrag;

    // 'ground check'
    private float playerHeight = 2;
    public LayerMask ground;
    bool grounded;

    public Transform orientation;

    // näppäimistö input
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // jäädytetään rigidbody koska se kaatuu muute :D
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // tarkistetaan koskettaako maata
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

        MyInput();
        //SpeedContol();

        // handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    // itse movement
    private void PlayerMove()
    {
        // laskee liikkumisen suunnan
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // kun pelaaja on maassa
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        }
        // pelaaja pystyy liikkumaan ilmassa hypyn ajan
        /*else
        {
            rb.AddForce(moveDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
        }*/

    }

    // turha aka ei käytössä atm :D
    // rajoittaa pelaajan nopeutta
    private void SpeedContol()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // rajoittaa velocity:a jos tarpeen
        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}