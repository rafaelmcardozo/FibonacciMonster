using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;

    private void Awake()
    {
        Instance = this;
    }

    //Starts the game in the setting up state
    private void Start()
    {
        UpdateGameState(GameState.SettingRoundUp);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.StartGame:
                break;
            case GameState.SettingRoundUp:
                HandleSettingRoundUp();
                break;
            case GameState.SpawningRound:
                HandleSpawningRound();
                break;
            case GameState.ContinueRound:
                HandleContinueRound();
                break;
            case GameState.EndRound:
                HandleEndRound();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleSettingRoundUp()
    {
        StartCoroutine(CountdownToStart());
    }

    private void HandleSpawningRound()
    {
    
    }

    private void HandleEndRound()
    {

    }

    private void HandleContinueRound()
    {

    }

    //countdown to start the spawning round
    IEnumerator CountdownToStart()
    {
        countdownTime = 3;
        countdownDisplay.gameObject.SetActive(true);
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "Start";

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);

        GameManager.Instance.UpdateGameState(GameState.SpawningRound);
    }

public enum GameState
    {
        StartGame,
        SettingRoundUp,
        SpawningRound,
        ContinueRound,
        EndRound,
    }
}
