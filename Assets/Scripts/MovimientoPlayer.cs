using UnityEngine;
using System.Collections;

public class MovimientoChef : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    
    [Header("Ajustes del Power-Up")]
    public float aumentoVelocidad = 3f;
    public float duracionEfecto = 5f;
    
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator; // <--- 1. Referencia al cerebro de animaciones

    void Start()
    {
        // Obtenemos los componentes físicos
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // <--- 2. Lo conectamos al empezar
    }

    void Update()
    {
        // 1. MOVIMIENTO HORIZONTAL
        float moverX = Input.GetAxisRaw("Horizontal");
        
        // Aplicamos la velocidad al Rigidbody2D (Compatible con Unity 6)
        rb.linearVelocity = new Vector2(moverX * velocidad, rb.linearVelocity.y);

        // --- 3
        // Si moverX es 0, enviamos 0. Si es -1 o 1, enviamos 1.
        animator.SetFloat("Velocidad", Mathf.Abs(moverX));
        // ------------------------------------

        // 2. GIRAR EL DIBUJO (Flip)
        if (moverX > 0) 
        {
            sprite.flipX = false; // Mira a la derecha
        }
        else if (moverX < 0) 
        {
            sprite.flipX = true; // Mira a la izquierda
        }

        // 3. SALTAR
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    // 4. DETECCIÓN DEL POWER-UP
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUPSandia"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ActivarSuperVelocidad());
        }
    }

    IEnumerator ActivarSuperVelocidad()
    {
        velocidad += aumentoVelocidad;
        sprite.color = new Color(1f, 0.5f, 0.5f);
        yield return new WaitForSeconds(duracionEfecto);
        velocidad -= aumentoVelocidad;
        sprite.color = Color.white;
    }
}
