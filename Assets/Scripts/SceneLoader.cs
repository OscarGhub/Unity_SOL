using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void CambiarEscena(string nombreDeLaEscena)
    {
        if (nombreDeLaEscena == "Win" || nombreDeLaEscena == "Lose") 
        {
            nivelAntesDeGanar = SceneManager.GetActiveScene().name;
        }
        
        SceneManager.LoadScene(nombreDeLaEscena);
    }

    public void ReloadCurrentScene(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public static string nivelAntesDeGanar;

    public void VolverAlNivel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(!string.IsNullOrEmpty(nivelAntesDeGanar) ? nivelAntesDeGanar : SceneManager.GetActiveScene().name);
        }
}
