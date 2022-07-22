using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField] private float dogSpeed = 500.0f;
    [SerializeField] private float dogJumpSpeed = 50.0f;
    [SerializeField] public Rigidbody rbDog;

    [SerializeField] private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rbDog = GameObject.FindWithTag("Dog").GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DogMotion();
    }

    public void DogMotion()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded) rbDog.AddForce(Vector3.up * dogJumpSpeed, ForceMode.Impulse);

        if (Input.GetKey(KeyCode.D)) rbDog.AddForce(Vector3.right * dogSpeed);

        if (Input.GetKey(KeyCode.A)) rbDog.AddForce(Vector3.left * dogSpeed);


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
