using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject spherePrefab;

    [SerializeField] float attackRange = 50f;
    [SerializeField] float attackCooldown = 0.8f;
    [SerializeField] float nextAttackTime = 0f;

    [SerializeField] Vector3 bulletRotation;

    [SerializeField] float projectileSpeed = 25f;
    [SerializeField] float projectileLifetime = 500f;

    [SerializeField] HealthController healthController;

    private Renderer objectRenderer;
    private Color originalColor;


    private void Start()
    {
        //objectRenderer = GetComponent<Renderer>();

        //originalColor = objectRenderer.material.color;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            AttackPlayer();
            nextAttackTime = Time.time + attackCooldown;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("ataque del player al enemigo");
            if (healthController != null)
            {
                ChangeColorToRed();

                if (healthController.GetHealth() <= 0.0f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void AttackPlayer()
    {
        Vector3 directionToPlayer = (player.transform.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(spherePrefab, firePoint.position, Quaternion.Euler(bulletRotation));

        Rigidbody rB = bullet.GetComponent<Rigidbody>();

        rB.velocity = directionToPlayer * projectileSpeed;

        Destroy(bullet, projectileLifetime);
    }

    public void ChangeColorToRed()
    {
        objectRenderer.material.color = Color.red;

        StartCoroutine(RestoreColorAfterDelay());
    }

    private IEnumerator RestoreColorAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);

        objectRenderer.material.color = originalColor;
    }
}