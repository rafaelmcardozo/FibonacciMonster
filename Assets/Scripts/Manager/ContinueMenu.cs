using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class ContinueMenu : MonoBehaviour
{
    public static ContinueMenu Instance;
    public Button continueButton;
    public Button quitButton;
    public TextMeshProUGUI spawnedMonsters;

    private void OnEnable()
    {
        ShowButtons();

    }


    public void ShowButtons() //Show the Continue Menu on the screen
    {
        continueButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        spawnedMonsters.gameObject.SetActive(true);
    }
    public void ContinueGame()  //When clicked update state and deactivate buttons
    {
        GameManager.Instance.UpdateGameState(GameState.SettingRoundUp);
        continueButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        spawnedMonsters.gameObject.SetActive(false);

    }

    public void QuitGame() //quit the game
    {
        Application.Quit();
    }

}