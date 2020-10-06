using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public int damage = 1;
    public GameObject destroyEffect;

    public void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    public void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.GetComponent<SpaceShip>() || hitInfo.GetComponent<Bullet>()) return;
        HealthObjects health = hitInfo.GetComponent<HealthObjects>();
        if (health != null && health.isEnemy)
        {
            health.TakeDamage(damage);
        }
        Die();
    }

    public void Die()
    {
        if (destroyEffect != null) Instantiate(destroyEffect, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}
