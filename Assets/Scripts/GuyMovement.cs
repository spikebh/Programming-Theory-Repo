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
    private Animator guyAnimator;
    public bool rotateToLeft = false;
    private float rotation = 180.0f;
    private Vector3 rotationLeft;
    private Vector3 rotationRight;

    // Start is called before the first frame update
    void Start()
    {
        rotationLeft = new Vector3(x: 0f, y: rotation, z: 0f);
        rotationRight = new Vector3(x: 0f, y: -rotation, z: 0f);
        rbGuy = GameObject.FindWithTag("Guy").GetComponent<Rigidbody>();
        guyAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!MainManager.Instance.gameOver) GuyMotion();
    }

    public void GuyMotion()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded) rbGuy.AddForce(Vector3.up * guyJumpSpeed, ForceMode.Impulse);

        else if (Input.GetKey(KeyCode.D))
        {
            rbGuy.AddForce(Vector3.right * guySpeed, ForceMode.Force);
            guyAnimator.SetBool("isMoving", true);
            MovingRight();

        }
        else if (Input.GetKey(KeyCode.A))
        {
            rbGuy.AddForce(Vector3.left * guySpeed, ForceMode.Force);
            guyAnimator.SetBool("isMoving", true);
            MovingLeft();
        }
        else guyAnimator.SetBool("isMoving", false);

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void MovingRight()
    {

        //Debug.Log(rbGuy.transform.rotation.y);
        if (!rotateToLeft) return;
        else
        {
            rbGuy.transform.Rotate(rotationLeft);
            rotateToLeft = false;
        }
    }

    void MovingLeft()
    {

        //Debug.Log(rbGuy.transform.rotation.y);
        if (rotateToLeft) return;
        else
        {
            rbGuy.transform.Rotate(rotationRight);
            rotateToLeft = true;
        }

    }
}

