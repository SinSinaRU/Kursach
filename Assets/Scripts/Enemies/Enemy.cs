using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HealthObjects
{
    public int damage = 1;
    public int score = 1;

    private void Start()
    {
        isEnemy = true;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        HealthObjects health = hitInfo.GetComponent<HealthObjects>();
        if (health != null && !health.isEnemy)
        {
            health.TakeDamage(damage);
            Die();
        }
    }

    public override void Die()
    {
        if (this.GetDestroyedBySomeone()) DataHolder.score += score;
        base.Die();
    }
}
