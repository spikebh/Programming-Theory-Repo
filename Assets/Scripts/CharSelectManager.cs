using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private int selectedCharacter;
    // Start is called before the first frame update

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }


    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);

    }


    public void StartGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        MainManager.Instance.playerSelected = selectedCharacter;
    }

    private void Awake()
    {
        selectedCharacter = 0;
        characters[selectedCharacter].SetActive(true);
    }
}
