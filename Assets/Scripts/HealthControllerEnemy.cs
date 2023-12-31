using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControllerEnemy : MonoBehaviour
{
    [SerializeField] float health = 100.0f;

    public void TakeDamage(float damage)
    {
        health -= Mathf.Abs(damage);

        if (health <= 0) Destroy(gameObject);
    }

    public float GetHealth()
    {
        return health;
    }
}
