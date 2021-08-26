using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playercontroller : MonoBehaviour
{
    private const bool V = true;
    public float speed = 0;
    public TextMeshProUGUI CountText;
    public GameObject winTextObject;
    public Vector3 jump;
    public float jumpForce = 10.0f;
    public bool isGrounded;


    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

        winTextObject.SetActive(false);

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 10.0f, 0.0f);

    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if(count >= 8)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            speed = speed * 1.5f;
            gameObject.transform.localScale += new Vector3(.5f, .5f, .5f);

            SetCountText();

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

    void Update()
    {
       

    }
    }
