using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObjects : MonoBehaviour
{
    public int health;
    public bool isEnemy;
    public GameObject destroyEffect;
    private bool destrouyedBySomeone;

    virtual public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            destrouyedBySomeone = true;
            this.Die();
        }
    }

    virtual public void Die()
    {
        if (destroyEffect != null) Instantiate(destroyEffect, this.transform.position, new Quaternion());
        Destroy(gameObject);
    }

    public bool GetDestroyedBySomeone()
    {
        return destrouyedBySomeone;
    }
}
