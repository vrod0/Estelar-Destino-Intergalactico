using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class EnemyFollowController : MonoBehaviour
{
    public Animator ani;

    public float alertRange;

    public float attackRange;

    public LayerMask capaPlayer;

    public Transform Player;

    public float velocidad;

    bool inAlert;
    bool inAttack;

    public float pushPower = 2.0f;


    void Start()
    {
       ani =  GetComponent<Animator>();
    }

    void Update()
    {
        inAlert= Physics.CheckSphere(transform.position, alertRange, capaPlayer);
        inAttack = Physics.CheckSphere(transform.position, attackRange, capaPlayer);

        if (inAlert == true)
        {
            Vector3 posPlayer = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(posPlayer);
            ani.SetBool("Walk", true);
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, velocidad * Time.deltaTime);

            if (inAttack == true)
            {
                velocidad = 0f;
                transform.position = Vector3.MoveTowards(transform.position, posPlayer, velocidad * Time.deltaTime);
                inAlert = false;
                ani.SetBool("Walk", false);
                ani.SetBool("Attack", true);
            }
            else
            {
                velocidad = 7f;
                ani.SetBool("Attack", false);
            }

        }
        else
        {
            ani.SetBool("Walk", false);
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}
