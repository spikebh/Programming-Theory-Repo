using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    [SerializeField] private float foxSpeed = 500.0f;
    [SerializeField] private float foxJumpSpeed = 50.0f;
    [SerializeField] public Rigidbody rbFox;
    [SerializeField] private bool isGrounded;
    private Animator foxAnimator;

    public bool rotateToLeft = false;
    private float rotation = 180.0f;
    private Vector3 rotationLeft;
    private Vector3 rotationRight;

    // Start is called before the first frame update
    void Start()
    {
        rotationLeft = new Vector3(x: 0f, y: rotation, z: 0f);
        rotationRight = new Vector3(x: 0f, y: -rotation, z: 0f);
        rbFox = GameObject.FindWithTag("Fox").GetComponent<Rigidbody>();
        foxAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FoxMotion();
    }

    public void FoxMotion()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded) rbFox.AddForce(Vector3.up * foxJumpSpeed, ForceMode.Impulse);

        else if (Input.GetKey(KeyCode.D))
        {
            rbFox.AddForce(Vector3.right * foxSpeed, ForceMode.Force);
            foxAnimator.SetBool("isMoving", true);
            MovingRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rbFox.AddForce(Vector3.left * foxSpeed, ForceMode.Force);
            foxAnimator.SetBool("isMoving", true);
            MovingLeft();
        }
        else foxAnimator.SetBool("isMoving", false);

        //MotionCheck();
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void MovingRight()
    {

        //Debug.Log(rbFox.transform.rotation.y);
        if (!rotateToLeft) return;
        else
        {
            rbFox.transform.Rotate(rotationLeft);
            rotateToLeft = false;
        }
    }

    void MovingLeft()
    {

        //Debug.Log(rbFox.transform.rotation.y);
        if (rotateToLeft) return;
        else
        {
            rbFox.transform.Rotate(rotationRight);
            rotateToLeft = true;
        }

    }
}
