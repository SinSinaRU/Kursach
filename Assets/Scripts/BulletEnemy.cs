using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    public new void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    public new void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.GetComponent<Enemy>() || hitInfo.GetComponent<BulletEnemy>()) return;
        HealthObjects health = hitInfo.GetComponent<HealthObjects>();
        if (health != null && !health.isEnemy)
        {
            health.TakeDamage(damage);
        }
        base.Die();
    }
}
