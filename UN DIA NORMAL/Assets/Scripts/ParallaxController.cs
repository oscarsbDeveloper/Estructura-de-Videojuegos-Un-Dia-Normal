using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D target;

    [SerializeField]
    Vector2 speed;

    [SerializeField]
    Vector2 offset;

    Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = (target.velocity.x * 0.01F) * speed * Time.deltaTime;    
        material.mainTextureOffset += offset;
    }

}
