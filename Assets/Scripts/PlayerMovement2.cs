using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    // pelaajan nopeus
    public float speed;

    public float groundDrag;

    // jump floats
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    //Ampuminen
    public GameObject bulletPrefab;
    public GameObject playerCamera;

    // 'ground check'
    private float playerHeight = 2;
    public LayerMask ground;
    bool grounded;

    public Transform orientation;

    // n‰pp‰imistˆ input
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // j‰‰dytet‰‰n rigidbody koska se kaatuu muute :D
        rb.freezeRotation = true;

        readyToJump = true;
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

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            bulletObject.transform.forward = playerCamera.transform.forward;
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

        // milloin hyp‰t‰:
        // jos painat space, on valmis hypp‰‰m‰‰n ja on maassa
        if (Input.GetKey("space") && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            // pystyt jatkuvasti hyppim‰‰n painamalla space pohjaan
            Invoke(nameof(ResetJump), jumpCooldown);
        }
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

    private void Jump()
    {
        // resettaa y:n velocityn, jotta pelaaja hypp‰‰ aina saman korkeuden verran
        //eiteemit‰‰n:D rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}