using UnityEngine;
using UnityEngine.SceneManagement;

public class MuertePorSuelo : MonoBehaviour
{
    public string escenaAEnviar = "Lose";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneLoader.nivelAntesDeGanar = SceneManager.GetActiveScene().name;

            Time.timeScale = 1;
            SceneManager.LoadScene(escenaAEnviar);
        }
    }
}
