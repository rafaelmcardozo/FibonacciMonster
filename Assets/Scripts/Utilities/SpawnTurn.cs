using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnTurn : MonoBehaviour
{
    public ObjectPool<Monster> _pool;

    private Spawner spawner;


    // Creating pool of monsters
    void Start()
    {
        spawner = GetComponent<Spawner>();
        _pool = new ObjectPool<Monster>(CreateMonster, OnTakeMonsterFromPool, OnReturnMonsterToPool, OnDestroyMonster, true, 30, 100);
    }


    private Monster CreateMonster()
    {
        //spawn a monster if not exist
        Monster monster = Instantiate(spawner.monster, spawner.monsterSpawnPoint);
        monster.name = monster.name.Replace("(Clone)", "");

        //assign the monster's pool
        monster.SetPool(_pool);

        return monster;
    }

    //Take the monster from the monster pool
    private void OnTakeMonsterFromPool(Monster monster)
    {
        //set the place of spawn
        monster.transform.position = spawner.monsterSpawnPoint.position;
        //activate
        monster.gameObject.SetActive(true);

    }

    //Returning a monster to the monster pool
    private void OnReturnMonsterToPool(Monster monster)
    {
        monster.gameObject.SetActive(false);
    }

    //Using when wanting to destroy a monster instead of returning
    private void OnDestroyMonster(Monster monster)
    {
        Destroy(monster.gameObject);
    }


}
