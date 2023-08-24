using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] Vector3 rotation;

    [SerializeField] float speed = 50.0f;

    void Start()
    {
        // Para marcar la direccion en x, y, z con valor magnitud -1, 0, 1 
        rotation = rotation.normalized;
    }

    void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
