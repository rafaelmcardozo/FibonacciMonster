using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class PreRoundSetup : MonoBehaviour
{

    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;
    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

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
}

