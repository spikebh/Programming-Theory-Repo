using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    public Transform cameraPos;
    public Transform backPos;
    private float xPos = 125.2f;
    private float currentBackPos;
    private float currentCameraPos;
    private float result;
    private Vector3 newPos;

    void Awake()
    {
        cameraPos = GameObject.Find("Main Camera").GetComponent<Transform>();
        backPos = GameObject.Find("Background_Nature").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        result = ComputeResult();
        Debug.Log("result: " + result + "\nCameraPos: " + currentCameraPos + "\nBackPos: " + currentBackPos);
        if (result >= 86f)
        {
            //newPos = new Vector3(currentBackPos + 69.0f, 0f, 0f); // I will leave this here to remind myself, how I can be so dumb sometimes.
            backPos.transform.Translate(Vector3.right * xPos, Space.World);

        }
        else if (result <= -74f) backPos.transform.Translate(Vector3.left * xPos, Space.World);
    }

    private float ComputeResult()
    {
        currentCameraPos = cameraPos.transform.position.x;
        currentBackPos = backPos.transform.position.x;
        return currentCameraPos - currentBackPos;
    }


}
