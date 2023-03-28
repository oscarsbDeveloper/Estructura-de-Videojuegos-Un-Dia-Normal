using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField]
    Vector3 rotation;

    [SerializeField]
    float speed = 50.0F;

    private void Start()
    {
        rotation = rotation.normalized;
    }

    private void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }

}
