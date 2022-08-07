using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private int playerSelected;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool funcExect;
    [SerializeField] private GameObject[] gameOverMenu;

    public float lerpValue = 1.0f;


    // Start is called before the first frame update
    void Awake()
    {
        playerSelected = MainManager.Instance.playerSelected;
        Invoke("SelectedChar", 1);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (funcExect) transform.position = Vector3.Lerp(transform.position, playerTarget.position + offset, lerpValue);
    }

    void SelectedChar()
    {

        switch (playerSelected)
        {
            case 0:
                playerTarget = GameObject.FindWithTag("Dog").transform;
                break;

            case 1:
                playerTarget = GameObject.FindWithTag("Guy").transform;
                break;

            case 2:
                playerTarget = GameObject.FindWithTag("Fox").transform;
                break;

            default:
                Debug.Log("No player was selected????");
                break;

        }
        funcExect = true;

    }

    void Update()
    {

    }

}
