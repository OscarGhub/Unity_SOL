using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class TimerNivel : MonoBehaviour
{
    public float tiempoRestante = 30f;
    public string escenaADondeIr = "Lose";
    public TextMeshProUGUI textoCronometro; 

    void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            
            if (textoCronometro != null)
            {
                textoCronometro.text = Mathf.Ceil(tiempoRestante).ToString();
            }
        }
        else 
        {
            SceneLoader.nivelAntesDeGanar = SceneManager.GetActiveScene().name; 
            
            Time.timeScale = 1; 
            
            SceneManager.LoadScene(escenaADondeIr);
        }
    }
}
