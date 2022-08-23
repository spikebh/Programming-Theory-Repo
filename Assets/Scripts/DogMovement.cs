using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : Player // INHERITANCE
{
    [SerializeField] private float playerSpeed = 4000.0f;
    [SerializeField] private float playerJumpSpeed = 55.0f;
    [SerializeField] public Rigidbody rbDog;
    [SerializeField] private bool isGrounded;
    private Animator dogAnimation;

    public bool rotateToLeft = false;
    private float rotation = 180.0f;
    private Vector3 rotationLeft;
    private Vector3 rotationRight;
    private float dashSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rotationLeft = new Vector3(x: 0f, y: rotation, z: 0f);
        rotationRight = new Vector3(x: 0f, y: -rotation, z: 0f);
        dogAnimation = GetComponent<Animator>();
        rbDog = GameObject.FindWithTag("Dog").GetComponent<Rigidbody>();
        dashSpeed = playerSpeed * 1.8f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) PlayerDash();
        else playerSpeed = 4000.0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!MainManager.Instance.gameOver) DogMotion(); // ABSTRACTION
    }

    public void DogMotion()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded) rbDog.AddForce(Vector3.up * playerJumpSpeed, ForceMode.Impulse);

        else if (Input.GetKey(KeyCode.D))
        {
            rbDog.AddForce(Vector3.right * playerSpeed, ForceMode.Force);
            dogAnimation.SetBool("isMoving", true);
            MovingRight(); // ABSTRACTION
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rbDog.AddForce(Vector3.left * playerSpeed, ForceMode.Force);
            dogAnimation.SetBool("isMoving", true);
            MovingLeft(); // ABSTRACTION

        }
        else dogAnimation.SetBool("isMoving", false);
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

    public override void PlayerDash()
    {
        base.PlayerDash(); // POLYMORPHISM
        playerSpeed = dashSpeed;
    }
}

