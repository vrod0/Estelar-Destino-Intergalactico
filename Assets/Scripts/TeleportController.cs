using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public Transform target;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = target.transform.position;
    }
}
