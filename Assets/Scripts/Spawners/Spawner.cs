using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform PositionToSpawn;
    public GameObject Enemy;
    public float TimeToSpawn;
    public int CountEnemy;


    protected void Start()
    {
        StartCoroutine(SpawnTime());
    }

    protected void Repeat()
    {
        StartCoroutine(SpawnTime());
    }

    protected void Stop()
    {
        StopCoroutine(SpawnTime());
    }

    protected IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(TimeToSpawn);
        Instantiate(Enemy, PositionToSpawn.position, Quaternion.identity);
        CountEnemy--;
        if (CountEnemy > 0)
            Repeat();
        else
            Stop();
    }

}