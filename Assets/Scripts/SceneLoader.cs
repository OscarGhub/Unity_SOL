using UnityEngine;
using UnityEngine.SceneManagement; //Librería para el manejo de escenas


public class SceneLoader : MonoBehaviour
{
    public void ReloadCurrentScene(){
        //Reanudamos la partida
        Time.timeScale = 1;
        //Recargamos la escena que tenemos actualmente activa
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}