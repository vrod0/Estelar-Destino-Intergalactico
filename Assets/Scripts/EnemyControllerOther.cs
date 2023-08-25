using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControllerOther : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int health = 100;

    int _currentHealth;

    public HealthBarControllerEnemy healthBarControllerEnemy;

    [SerializeField] HealthControllerEnemy healthControllerEnemy;



    private void Start()
    {
        _currentHealth = health;
        healthBarControllerEnemy.SetMaxHealth(health);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("inpacto al enemigo");
            TakeDamage(30);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= Mathf.Abs(damage);

        healthBarControllerEnemy.SetHealth(_currentHealth);

        healthControllerEnemy.TakeDamage(damage);

        if (_currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

}
