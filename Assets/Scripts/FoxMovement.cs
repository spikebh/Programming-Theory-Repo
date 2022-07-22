using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    [SerializeField] private float foxSpeed = 500.0f;
    [SerializeField] private float foxJumpSpeed = 50.0f;
    [SerializeField] public Rigidbody rbFox;
    [SerializeField] private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rbFox = GameObject.FindWithTag("Fox").GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FoxMotion();
    }

    public void FoxMotion()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded) rbFox.AddForce(Vector3.up * foxJumpSpeed, ForceMode.Impulse);

        if (Input.GetKey(KeyCode.D)) rbFox.AddForce(Vector3.right * foxSpeed);

        if (Input.GetKey(KeyCode.A)) rbFox.AddForce(Vector3.left * foxSpeed);


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
