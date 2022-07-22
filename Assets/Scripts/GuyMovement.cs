using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float guySpeed = 500.0f;
    [SerializeField] private float guyJumpSpeed = 50.0f;
    [SerializeField] public Rigidbody rbGuy;
    [SerializeField] private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rbGuy = GameObject.FindWithTag("Guy").GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GuyMotion();
    }

    public void GuyMotion()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded) rbGuy.AddForce(Vector3.up * guyJumpSpeed, ForceMode.Impulse);

        if (Input.GetKey(KeyCode.D)) rbGuy.AddForce(Vector3.right * guySpeed);

        if (Input.GetKey(KeyCode.A)) rbGuy.AddForce(Vector3.left * guySpeed);


    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}

