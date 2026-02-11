using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Configuración")]
    public string nombreEscenaDestino;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneLoader.nivelAntesDeGanar = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Win"); 
        }
    }
    
}
