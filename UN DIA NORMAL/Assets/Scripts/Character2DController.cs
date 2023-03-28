using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Character2DController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    float walkSpeed = 500f;

    [SerializeField]
    bool isFacingRight = true;

    [SerializeField]
    [Range(0.01F, 0.3F)]
    float smoothSpeed = 0.3F;

    [Header("Jump")]
    [SerializeField]
    float jumpForce = 2000;

    [SerializeField]
    float fallMultiplier = 15.0F;

    [SerializeField]
    float jumpGraceTime = 0.25F;

    [Header("Animation")]
    [SerializeField]
    Animator animator;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    LayerMask groundMask;

    Rigidbody2D rb;

    Vector2 gravity;
    Vector2 velocityZero = Vector2.zero;

    float inputX;
    float lastTimeJumpPressed;

    bool isMoving;
    bool isJumpPressed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = -Physics2D.gravity;
    }

    //Se ejecuta cadro por cuadro
    private void Update()
    {
        HandleInputs();
    }

    private void FixedUpdate()
    {
        HandleJump();
        HandleMove();
        HandleFlipX();
    }

    //Verifica las entradas del jugador por cuadro
    private void HandleInputs()
    {
        //Metodo para manipular el movimiento "GetAxis()"
        inputX = UnityEngine.Input.GetAxisRaw("Horizontal");
        isMoving = inputX != 0.0f;

        isJumpPressed = Input.GetButtonDown("Jump");
        if(isJumpPressed)
        {
            lastTimeJumpPressed = Time.time;
        }
    }

    void HandleMove()
    {
        //Calcula la velocidad en X
        float velocityX = inputX * walkSpeed * Time.fixedDeltaTime;
        animator.SetFloat("speed",Mathf.Abs(velocityX));

        //Crea el vector de direccion y asigna la velocidad
        Vector2 direction = new Vector2(velocityX, rb.velocity.y);

        //rb.velocity = direction;
        rb.velocity = Vector2.SmoothDamp(rb.velocity,direction,ref velocityZero,smoothSpeed);
    }

    void HandleFlipX()
    {
        if(isMoving)
        {
            //Calcula hacia donde esta mirando el personaje
            bool facingRight = inputX > 0.0f;
            if(isFacingRight != facingRight)
            {
                //Rota el personaje en el eje Y
                isFacingRight = facingRight;
                Vector2 localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;
            }
        }
    }

    void HandleJump()
    {
        if(lastTimeJumpPressed > 0.0F && Time.time - lastTimeJumpPressed <= jumpGraceTime)
        {
            isJumpPressed = true;
        }
        else
        {
            lastTimeJumpPressed = 0.0F;
        }

        if(isJumpPressed && IsGrounded())
        {
            rb.velocity += Vector2.up * jumpForce * Time.fixedDeltaTime;
        }

        if(rb.velocity.y < -0.01F)
        {
            rb.velocity -= gravity * fallMultiplier * Time.fixedDeltaTime;
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, 
                                        new Vector2(0.64f,0.04f),
                                        CapsuleDirection2D.Horizontal,0.0f,groundMask);
    }

}
