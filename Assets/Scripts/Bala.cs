using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Bala : MonoBehaviour
{
    GameObject Personaje;

    bool direccionPersonaje;

    public GameObject disparo;

    public float velocidadBala = 0.5f;

    float nacimiento;

    public float tiempoParaMorir = 1.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Personaje = GameObject.Find("Personaje");

        direccionPersonaje = Personaje.GetComponent<MovPersonaje>().direccionBalaDerecha;

        nacimiento = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,0.5f);

        if(direccionPersonaje)
        {
            disparo.transform.Translate(velocidadBala*Time.deltaTime,0,0);
        }
        else
        {
            disparo.transform.Translate(-1*velocidadBala*Time.deltaTime,0,0);
        }

        if (Time.time >= nacimiento + tiempoParaMorir)
        {
            Destroy(disparo);
        }

    
        

    }
}
