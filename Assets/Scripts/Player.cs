using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerSpeed = 500.0f;
    public float playerJumpSpeed = 50.0f;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void PlayerDash()
    {
        Debug.Log("player is dashing");
    }
}
