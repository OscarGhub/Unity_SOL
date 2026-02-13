using UnityEngine;

public class FlechaAnimada : MonoBehaviour
{
    public float velocidad = 5f;
    public float amplitud = 0.5f;
    Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.localPosition;
    }

    void Update()
    {
        float nuevoY = Mathf.Sin(Time.time * velocidad) * amplitud;
        
        transform.localPosition = posicionInicial + new Vector3(0, nuevoY, 0);
    }
}
