using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPrompt : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("DisableGO", 10.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DisableGO()
    {
        gameObject.SetActive(false);
    }
}
