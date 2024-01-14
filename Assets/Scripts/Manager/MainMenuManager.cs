using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public Button playButton, instructionButton, quitButton, backButton;
    public GameObject instructionText;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void GameInstructions()  //Open Instructions
    {
        playButton.gameObject.SetActive(false);
        instructionButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);

    }

    public void BackToMenu() //Back to Main Menu
    {
        playButton.gameObject.SetActive(true);
        instructionButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        instructionText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

    }


    public void QuitGame()
    {
        Application.Quit();
    }
}

