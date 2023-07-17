using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que maneja los movimientos del personaje en la PC.
/// </summary>
public class PcMovimientos : MonoBehaviour
{
     /// <summary>
    /// Velocidad de movimiento horizontal.
    /// </summary>
    public float runSpeedHorizontal = 2;

    /// <summary>
    /// Velocidad de movimiento.
    /// </summary>
    public float runSpeed = 2;

    /// <summary>
    /// Velocidad de salto.
    /// </summary>
    public float JumpSpeed = 5;

    /// <summary>
    /// Velocidad de doble salto.
    /// </summary>
    public float DobleSalto = 5f;

    /// <summary>
    /// Bandera que indica si se puede realizar un doble salto.
    /// </summary>
    private bool ContSaltodoble;

    /// <summary>
    /// Componente Rigidbody2D del personaje.
    /// </summary>
    Rigidbody2D rigidbody2d;

    /// <summary>
    /// Componente SpriteRenderer del personaje.
    /// </summary>
    public SpriteRenderer spriteRender;

    /// <summary>
    /// Componente Animator del personaje.
    /// </summary>
    public Animator animator;

    /// <summary>
    /// Inicializa el componente Rigidbody2D del personaje.
    /// </summary>
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Maneja las acciones de movimiento del personaje.
    /// </summary>
    void FixedUpdate()
    {
        animator.SetBool("Run", false);

        if (Input.GetKey("right"))
        {
            spriteRender.flipX = false;
            animator.SetBool("Run", true);
            rigidbody2d.velocity = new Vector2(runSpeed, rigidbody2d.velocity.y);
        }
        else if (Input.GetKey("left"))
        {
            spriteRender.flipX = true;
            animator.SetBool("Run", true);
            rigidbody2d.velocity = new Vector2(-runSpeed, rigidbody2d.velocity.y);
        }
        else
        {
            animator.SetBool("Run", false);
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }

        if (Input.GetKey("space") && IsGround.isGround)
        {
            animator.SetBool("Run", false);
            ContSaltodoble = true;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, JumpSpeed);
        }
        if (IsGround.isGround == false){
            animator.SetBool("Salto",  true);
            animator.SetBool("Run",  false);
        }
        if (IsGround.isGround == true){
            animator.SetBool("Salto",  false);
            
        }
        else
        {
            if (ContSaltodoble)
            {
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, DobleSalto);
                ContSaltodoble = false;
            }
        }
    }
}