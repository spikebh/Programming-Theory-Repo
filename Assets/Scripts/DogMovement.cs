using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    [SerializeField] private float dogSpeed = 500.0f;
    [SerializeField] private float dogJumpSpeed = 50.0f;
    [SerializeField] public Rigidbody rbDog;
    [SerializeField] private bool isGrounded;
    private Animator dogAnimation;

    public bool rotateToLeft = false;
    private float rotation = 180.0f;
    private Vector3 rotationLeft;
    private Vector3 rotationRight;



    // Start is called before the first frame update
    void Start()
    {
        rotationLeft = new Vector3(x: 0f, y: rotation, z: 0f);
        rotationRight = new Vector3(x: 0f, y: -rotation, z: 0f);
        dogAnimation = GetComponent<Animator>();
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

        else if (Input.GetKey(KeyCode.D))
        {
            rbDog.AddForce(Vector3.right * dogSpeed, ForceMode.Force);
            dogAnimation.SetBool("isMoving", true);
            MovingRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rbDog.AddForce(Vector3.left * dogSpeed, ForceMode.Force);
            dogAnimation.SetBool("isMoving", true);
            MovingLeft();

        }
        else dogAnimation.SetBool("isMoving", false);
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

        //Debug.Log(rbDog.transform.rotation.y);
        if (!rotateToLeft) return;
        else
        {
            rbDog.transform.Rotate(rotationLeft);
            rotateToLeft = false;
        }
    }

    void MovingLeft()
    {

        //Debug.Log(rbDog.transform.rotation.y);
        if (rotateToLeft) return;
        else
        {
            rbDog.transform.Rotate(rotationRight);
            rotateToLeft = true;
        }

    }
}

