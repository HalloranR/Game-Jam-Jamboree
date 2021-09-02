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

    //public GameObject[] shellArray;
    public List<GameObject> sList = new List<GameObject>();
    public int shellCount = 4;
    public float radius = 5;
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
        GameObject referenceShell = (GameObject)Instantiate(Resources.Load("Projectile_Prefab"));

        for (int i = 0; i < shellCount; i++)
        {
            GameObject shell = (GameObject)Instantiate(referenceShell, transform);

            float posX = transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;

            if (i == 0) { posX += radius; }
            if (i == 1) { posX -= radius; }
            if (i == 2) { posY += radius; }
            if (i == 3) { posY -= radius; }

            shell.transform.position = new Vector3(posX, posY, posZ);

            sList.Add(shell);
        }
    }

    void fireShell()
    {
        GameObject launch = sList[0];

        sList.Remove(launch);

        //make the shell move
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

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            fireShell();
        }
    }
}