using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement : Player // INHERITANCE
{
    [SerializeField] private float playerSpeed = 2000.0f;
    [SerializeField] private float playerJumpSpeed = 25.0f;
    [SerializeField] public Rigidbody rbFox;
    [SerializeField] private bool isGrounded;
    private Animator foxAnimator;
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
        rbFox = GameObject.FindWithTag("Fox").GetComponent<Rigidbody>();
        foxAnimator = GetComponent<Animator>();
        dashSpeed = playerSpeed * 2f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) PlayerDash();
        else playerSpeed = 2000.0f;
    }

    void FixedUpdate()
    {
        if (!MainManager.Instance.gameOver) FoxMotion(); // ABSTRACTION
    }

    public void FoxMotion()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded) rbFox.AddForce(Vector3.up * playerJumpSpeed, ForceMode.Impulse);

        else if (Input.GetKey(KeyCode.D))
        {
            rbFox.AddForce(Vector3.right * playerSpeed, ForceMode.Force);
            foxAnimator.SetBool("isMoving", true);
            MovingRight(); // ABSTRACTION
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rbFox.AddForce(Vector3.left * playerSpeed, ForceMode.Force);
            foxAnimator.SetBool("isMoving", true);
            MovingLeft(); // ABSTRACTION
        }
        else foxAnimator.SetBool("isMoving", false);

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

    public override void PlayerDash()
    {
        base.PlayerDash(); // POLYMORPHISM
        playerSpeed = dashSpeed;
    }
}
