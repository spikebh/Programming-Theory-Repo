using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    public Transform cameraPos;
    public Transform backPos;
    private float xPos = 60.0f;
    private float currentPos;
    private float backSize;
    // Start is called before the first frame update
    void Awake()
    {
        cameraPos = GameObject.Find("MainCamera").GetComponent<Transform>();
        backPos = GameObject.Find("Background_Nature").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = cameraPos.transform.position.x;
        //backSize = backPos.transform.

        //if(cameraPos.transform.position.x >= )
    }
}
