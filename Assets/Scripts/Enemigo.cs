using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    String estado = "patrulla";
    public float distanciaPatrulla = 3.0f;

    public float velocidadPatrulla = 0.05f;
    public float velocidadAtaque = 0.01f;

    public float distanciaEvitar =3.0f;

    Vector3 posicionInicial;
    bool dirPatruDrcha = true;

    public float distanciaAtaque = 3.0f;

    GameObject Personaje;

    Vector3 posicionLimitIzq, posicionLimitDrcha;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position;
        posicionLimitIzq = new Vector3(posicionInicial.x - distanciaPatrulla, posicionInicial.y, posicionInicial.z);
        posicionLimitDrcha = new Vector3(posicionInicial.x + distanciaPatrulla, posicionInicial.y, posicionInicial.z);
        Personaje = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, Personaje.transform.position);
        if(distancia <= distanciaAtaque)
        {
            estado = "ataque";
        }
        if(distancia > distanciaEvitar&&estado=="ataque")
        {
            estado="regreso";
        }

        //PATRULLA

        if(estado == "patrulla")
        {

            if(transform.position.x >= posicionLimitDrcha.x)
            {
                dirPatruDrcha = false;
             
            }
            else if (transform.position.x <= posicionLimitIzq.x)
            {
               dirPatruDrcha = true;
            }
            if (dirPatruDrcha == true)
            {
                transform.Translate(velocidadPatrulla, 0, 0);
                this.GetComponent<SpriteRenderer>().flipX = true;
                this.GetComponent<CapsuleCollider2D>().offset = new Vector2(0.07f,-0.01515288f);
            }
            else
            {
                transform.Translate(velocidadPatrulla*-1,0,0);
                this.GetComponent<SpriteRenderer>().flipX = false;
                this.GetComponent<CapsuleCollider2D>().offset = new Vector2(-0.07f,-0.01515288f);
            }
        }

        //ATAQUE

        if (estado == "ataque")
        {
            transform.position = Vector3.MoveTowards(transform.position, Personaje.transform.position, velocidadAtaque);
        }

        //REGRESO

        if (estado == "regreso")
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadPatrulla);
            if (transform.position == posicionInicial){
                estado="patrulla";
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("MUERTE");
            GameManager.vidas-=1;
            Personaje.GetComponent<MovPersonaje>().Muerte();
        }

        if(col.gameObject.name == "Bala")
        {
            Destroy(col.gameObject, 0.5f);
            Destroy(this.gameObject,0.5f);
        }

    }
    


}
