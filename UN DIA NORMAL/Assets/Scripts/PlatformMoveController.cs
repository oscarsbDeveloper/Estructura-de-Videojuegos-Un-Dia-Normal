using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveController : MonoBehaviour
{
    [SerializeField]
    Vector2 displacement;

    [SerializeField]
    float speed;

    Vector2 originPoint;

    private void Awake()
    {
        originPoint = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(originPoint, originPoint + displacement, Mathf.PingPong(Time.time * speed, 1));
    }

}
