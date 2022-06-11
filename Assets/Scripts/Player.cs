using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10.0f;
    [SerializeField] private float playerJumpSpeed = 80.0f;
    [SerializeField] public Rigidbody rbPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        rbPlayer = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMotion();
    }

    public void PlayerMotion()
    {
        if (Input.GetKeyDown(KeyCode.Space)) rbPlayer.AddForce(Vector3.up * playerJumpSpeed, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.D)) rbPlayer.AddForce(Vector3.right * playerSpeed, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.A)) rbPlayer.AddForce(Vector3.left * playerSpeed, ForceMode.Force);


    }
}
