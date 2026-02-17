using UnityEngine;

public class LluviaFrutas : MonoBehaviour
{
    public GameObject[] frutasPrefabs; 
    public float intervaloCreacion = 0.1f; 
    public float rangoX = 10f;
    public float duracionLluvia = 5f; // X tiempo que dura la lluvia

    private bool estaLloviendo = false;

    // Esta es la función que conectaremos al BOTÓN
    public void ActivarEasterEgg()
    {
        if (!estaLloviendo)
        {
            estaLloviendo = true;
            // Empieza a crear frutas
            InvokeRepeating("CrearFruta", 0f, intervaloCreacion);
            // Programa el apagado automático después de X segundos
            Invoke("DetenerLluvia", duracionLluvia);
        }
    }

    void CrearFruta()
    {
        if (frutasPrefabs != null && frutasPrefabs.Length > 0)
        {
            int indiceAleatorio = Random.Range(0, frutasPrefabs.Length);
            
            if (frutasPrefabs[indiceAleatorio] != null)
            {
                Vector3 posicion = new Vector3(Random.Range(-rangoX, rangoX), transform.position.y, 0);
                GameObject nuevaFruta = Instantiate(frutasPrefabs[indiceAleatorio], posicion, Quaternion.identity);
                
                // Buscamos el renderizador y lo ponemos en una capa visible
                SpriteRenderer sr = nuevaFruta.GetComponent<SpriteRenderer>();
                if (sr != null) {
                    sr.sortingOrder = 10; // Un número alto para que esté al frente
                }

                Destroy(nuevaFruta, 5f); 
            }
        }
    }

    void DetenerLluvia()
    {
        CancelInvoke("CrearFruta");
        estaLloviendo = false;
        Debug.Log("El Easter Egg ha terminado");
    }
}