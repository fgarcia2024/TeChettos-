using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que controla el movimiento y las acciones del jugador.
/// </summary>
public class MovimientosPlayer : MonoBehaviour
{
    public bool sePuedeMover = true;

    [SerializeField] private Vector2 velocidadRebote;

    /// <summary>
    /// Valor del movimiento horizontal.
    /// </summary>
    private float horizontaMove = 0f;

    /// <summary>
    /// Valor del movimiento vertical.
    /// </summary>
    private float verticalMove = 0f;

    /// <summary>
    /// Velocidad de movimiento horizontal.
    /// </summary>
    public float runSpeedHorizontal = 2;

    /// <summary>
    /// Velocidad de movimiento general.
    /// </summary>
    public float runSpeed = 2;

    /// <summary>
    /// Velocidad de salto.
    /// </summary>
    public float JumpSpeed = 5;

    /// <summary>
    /// Velocidad de salto adicional para el doble salto.
    /// </summary>
    public float DobleSalto = 4f;

    /// <summary>
    /// Booleano que indica si se puede realizar un doble salto.
    /// </summary>
    private bool ContSaltodoble;

    /// <summary>
    /// Componente Rigidbody2D utilizado para el movimiento.
    /// </summary>
    Rigidbody2D rigidbody2d;

    /// <summary>
    /// Joystick utilizado para el control del movimiento.
    /// </summary>
    public Joystick joystick;

    /// <summary>
    /// Componente SpriteRenderer utilizado para controlar el sprite del jugador.
    /// </summary>
    public SpriteRenderer spriteRender;

    /// <summary>
    /// Animator utilizado para controlar las animaciones del jugador.
    /// </summary>
    public Animator animator;


    /// <summary>
    /// Método invocado al inicio del objeto.
    /// </summary>
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Método invocado en cada fotograma.
    /// </summary>
    void Update()
    {
        animator.SetBool("Run", false);
        // animator.SetBool("Salto", false);

        if (horizontaMove > 0)
        {
            spriteRender.flipX = false;
            animator.SetBool("Run", true);
            animator.SetBool("Salto", true);
        }

        if (horizontaMove < 0)
        {
            spriteRender.flipX = true;
            animator.SetBool("Run", true);

        }
        if (IsGround.isGround == false){
            animator.SetBool("Salto",  true);
            animator.SetBool("Run",  false);
        }
        if (IsGround.isGround == true){
            animator.SetBool("Salto",  false);
            
        }
    }

    /// <summary>
    /// Método invocado en intervalos regulares de tiempo.
    /// Controla el movimiento horizontal del jugador.
    /// </summary>
    void FixedUpdate()
    {
        if (sePuedeMover)
        {
            horizontaMove = joystick.Horizontal * runSpeedHorizontal;
            transform.position += new Vector3(horizontaMove, 0, 0) * Time.deltaTime * runSpeed;
        }
    }

    /// <summary>
    /// Realiza un salto, teniendo en cuenta si el jugador está en el suelo o en el aire.
    /// </summary>
    public void Salto()
    {
        if (IsGround.isGround)
        {
        
            ContSaltodoble = true;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, JumpSpeed);
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

    public void Rebote(Vector2 puntoGolpe)
    {
        rigidbody2d.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }
}