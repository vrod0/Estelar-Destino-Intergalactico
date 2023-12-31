using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] LayerMask whatIsEnemy;

    [SerializeField] float damage = 50.0f;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == (other.gameObject.layer | (1 << whatIsEnemy)) || other.gameObject.layer == (other.gameObject.layer | (1 << whatIsEnemy)))
        {
            HealthController controller = other.gameObject.GetComponent<HealthController>();
            if (controller != null)
            {
                controller.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
                //EnemyControllerOther enemyControllerOther = other.GetComponent<EnemyControllerOther>();

               // if (enemyControllerOther != null)
                //{
                    //enemyControllerOther.TakeDamage(35);
                //}
            Destroy(other.gameObject);
           // enemyControllerOther.TakeDamage(35);
        }
    }
}