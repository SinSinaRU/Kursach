using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject Enemy;
    public float TimeToSpawn;


    protected void Start()
    {
        StartCoroutine(SpawnTime());
    }

    protected void Repeat()
    {
        StartCoroutine(SpawnTime());
    }

    protected IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(TimeToSpawn);
        Instantiate(Enemy, transform.position, Quaternion.identity);
        Repeat();
    }

    public override void Die()
    {
        base.Die();
    }
}
