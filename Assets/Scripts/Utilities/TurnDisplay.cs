using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnDisplay : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI turnText;
    public int turnNumber;

    private void Start()
    {
        turnNumber = 1;
    }

    //Display the number of the turn
    private void OnEnable()
    {
        turnNumber++;
        turnText.text = "Turn: "+ turnNumber.ToString();
    }
}
