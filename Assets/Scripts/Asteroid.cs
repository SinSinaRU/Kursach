using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy
{
    public GameObject AsteroidAfter;
    public int Count; // Количество новоых астероидов после уничтожения предыдущего
    public float Radius; // Радиус разлета новых астероидов
    public float StartRadius; // Радиус начала движения

    private void Start()
    {
        isEnemy = true;
    }

    override public void Die()
    {
        int angle = Random.Range(0, 360);
        for (int count = 1; count <= Count; count++)
        {
            GameObject newAsteroid = Instantiate(AsteroidAfter, transform.position, transform.rotation);
            AsteroidAI newAI = newAsteroid.GetComponent<AsteroidAI>();
            newAI.PushObject(angle, Radius, StartRadius);
            angle += 360 / Count;
        }
        base.Die();
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        HealthObjects health = hitInfo.GetComponent<HealthObjects>();
        if (health != null && !health.isEnemy)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
