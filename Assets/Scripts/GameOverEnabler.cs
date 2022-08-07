using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverEnabler : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void Setup()
    {
        if (MainManager.Instance.gameOver)
        {
            Debug.Log("Menu Entered!!!");
            gameObject.SetActive(true);
        }
    }

    public void Yes_Button_Clicked()
    {
        MainManager.Instance.gameOver = false;
        MainManager.Instance.LoadCharacterSelect();
    }

    public void No_Button_Clicked()
    {
        MainManager.Instance.Exit();
    }


}
