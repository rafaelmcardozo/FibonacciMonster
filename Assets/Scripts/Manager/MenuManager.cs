using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _countdownDisplay, _continueDisplay, _monsterPooling;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    //Change between states what is shown to the player
    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        _countdownDisplay.SetActive(state == GameState.SettingRoundUp);

        _monsterPooling.SetActive(state == GameState.SpawningRound);

        _continueDisplay.SetActive(state == GameState.ContinueRound);
    }

}
