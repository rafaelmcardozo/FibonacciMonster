using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Monster : MonoBehaviour
{
    [SerializeField] private float physicsMonsterSpeed = 0.8f;
    [SerializeField] private float destroyTime = 1f;

    private ObjectPool<Monster> _pool;
    [SerializeField] string tagFilter;

    public Coroutine deactivateMonsterAfterBound;

    void Update()
    {
        SetPhysicsVelocity();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //is the end of screen boundaries
        if (collision.gameObject.tag == "Bound")
        {
            deactivateMonsterAfterBound = StartCoroutine(DeactivateMonsterAfterBound());
         
        }
    }

    public void SetPool(ObjectPool<Monster> pool)
    {
        _pool = pool;
    }

    public IEnumerator DeactivateMonsterAfterBound()
    {
        float elapsedTime = 0f;
        while (elapsedTime < destroyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //after time spend out of boundaries
        _pool.Release(this);
    }

    //set velocity randomly
    private void SetPhysicsVelocity()
    {
        transform.Translate(Vector2.right * physicsMonsterSpeed * (Random.Range(0.01f, 5.0f)));

    }


}
