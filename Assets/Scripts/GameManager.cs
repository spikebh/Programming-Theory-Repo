using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private int playerSelected;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerSelected = MainManager.Instance.playerSelected;
        EstablishModel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EstablishModel()
    {
        switch (playerSelected)
        {
            case 0:
                player.transform.GetChild(0).gameObject.SetActive(true);
                break;

            case 1:
                player.transform.GetChild(1).gameObject.SetActive(true);
                break;

            case 2:
                player.transform.GetChild(2).gameObject.SetActive(true);
                break;

            default:
                Debug.Log("Houston, we have a problem");
                player.transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }
}
