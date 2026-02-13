using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Sin esto, dará error

public class TimerNivel : MonoBehaviour
{
    public float tiempoRestante = 30f;
    public string escenaADondeIr = "Lose";
    
    // Esta línea es la que CREA el hueco en el Inspector
    public TextMeshProUGUI textoCronometro; 

    void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            
            // Si ya arrastraste el texto, lo actualiza
            if (textoCronometro != null)
            {
                textoCronometro.text = Mathf.Ceil(tiempoRestante).ToString();
            }
        }
        else
        {
            SceneManager.LoadScene(escenaADondeIr);
        }
    }
}