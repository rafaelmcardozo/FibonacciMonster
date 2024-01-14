using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using static GameManager;
using TMPro;

public class Spawner : MonoBehaviour
{
    public Monster monster;
    public Transform monsterSpawnPoint;
    public float spawnCounter;
    public float spawnTime = 0.5f;
    public float spawnDelay;
    public long turnNumber = 0;
    public long numberOfSpawns = 1;
    public TextMeshProUGUI turnText;

    private SpawnTurn monsterSpawner;

    //Start to spawn monsters everytime the Spawner is enabled and count the number that was spawned
    void OnEnable()
    {
        monsterSpawner = GetComponent<SpawnTurn>();
        GenerateFibonacci();
        InvokeRepeating("HandleSpawnMonster", spawnTime, spawnDelay);
        turnText.text = "Number of Spawns: " + numberOfSpawns.ToString();
    }

    private void HandleSpawnMonster()
    {

        //Spawn Monster from the pool based on Fibonacci sequence

        //NumberOfSpawns is equal to the result of the Fibonacci sequence
        if (spawnCounter < numberOfSpawns)
        {
            monsterSpawner._pool.Get();

            spawnCounter++;
            print("Numero de Spawn:"+numberOfSpawns);

        }
        else if (monsterSpawner._pool.CountAll == monsterSpawner._pool.CountInactive) //Checks if the poll is inactive
        {
            GameManager.Instance.UpdateGameState(GameState.ContinueRound);
            print("Passando Round");
            spawnCounter = 0;
            CancelInvoke();
        }

    }
    //Fibonacci sequence logic
    public void GenerateFibonacci()
    {
        turnNumber++;

        numberOfSpawns = GetFibonacci(turnNumber, numberOfSpawns);
    }

    private long GetFibonacci(long turnNumber, long numberOfSpawns)
    {
        long term1 = 0;
        long term2 = 1;
        long nextTerm = 0;
        print("Fibonacci turn:" + turnNumber);

        for (int i = 1; i < turnNumber; i++)
        {
            if (i == 1)
            {
                numberOfSpawns += term1;
            }
            else if (i == 2)
            {
                numberOfSpawns += term2;
            }
            else
            {
                nextTerm = term1 + term2;
                term1 = term2;
                term2 = nextTerm;

                numberOfSpawns = nextTerm;
            }

        }
        return numberOfSpawns;
    }
}

