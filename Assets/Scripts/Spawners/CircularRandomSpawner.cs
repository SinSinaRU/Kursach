using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularRandomSpawner : Spawner
{
    public float RadiusSpawn = 40f;

    protected new void Start()
    {
        StartCoroutine(SpawnTime());
    }

    private new IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(TimeToSpawn);
        Vector3 generateSpawnPoint;
        float Angle = Random.Range(0, 360);
        float newX = RadiusSpawn * Mathf.Cos((Angle * Mathf.PI) / 180);
        float newZ = RadiusSpawn * Mathf.Sin((Angle * Mathf.PI) / 180);
        generateSpawnPoint = new Vector3(PositionToSpawn.position.x + newX, PositionToSpawn.position.y, PositionToSpawn.position.z + newZ);
        Instantiate(Enemy, generateSpawnPoint, Quaternion.identity);
        CountEnemy--;
        if (CountEnemy > 0)
            StartCoroutine(SpawnTime());
        else
            StopCoroutine(SpawnTime());
    }
}
