using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playercontroller : MonoBehaviour
{
    private const bool V = true;
    public float speed = 0;
    public Vector3 jump;
    public float jumpForce = 10.0f;
    public bool isGrounded;

    public GameObject[] shells;
    //needs an array to store projectiles


    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        jump = new Vector3(0.0f, 10.0f, 0.0f);

        //need to initialize shells
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        //Can use this for player hit
        //make a tag for projectile
        if (other.gameObject.CompareTag("Projectile"))
        {
           //put knockback in here

        }
    
    }


    void OnCollisionStay()
    {
        isGrounded = V;
    }


    void OnJump(InputValue MovementValue)
    {
        Debug.Log("working");
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
}