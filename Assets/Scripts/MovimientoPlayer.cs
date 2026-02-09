using UnityEngine;
using System.Collections; // Necesario para que el temporizador funcione

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

    void Start()
    {
        // Obtenemos los componentes físicos
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 1. MOVIMIENTO HORIZONTAL
        float moverX = Input.GetAxisRaw("Horizontal");
        
        // Aplicamos la velocidad al Rigidbody2D (Compatible con Unity 6)
        rb.linearVelocity = new Vector2(moverX * velocidad, rb.linearVelocity.y);

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
        // Comprobamos si el objeto tiene el tag específico
        if (other.CompareTag("PowerUPSandia"))
        {
            Destroy(other.gameObject); // La sandía desaparece
            StartCoroutine(ActivarSuperVelocidad()); // Iniciamos el temporizador
        }
    }

    // Corrutina para manejar el tiempo del efecto
    IEnumerator ActivarSuperVelocidad()
    {
        velocidad += aumentoVelocidad; // Subimos la velocidad
        sprite.color = new Color(1f, 0.5f, 0.5f); // Cambiamos el color a un tono rojizo/picante

        yield return new WaitForSeconds(duracionEfecto); // Esperamos los segundos indicados

        velocidad -= aumentoVelocidad; // Devolvemos la velocidad a la normalidad
        sprite.color = Color.white; // Restauramos el color original del sprite
    }
}