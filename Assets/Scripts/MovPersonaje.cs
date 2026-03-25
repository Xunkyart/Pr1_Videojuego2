using UnityEngine;

public class MovPersonaje : MonoBehaviour
{

    int miNumero = 3;

    float miNumeroFlotante = 0.8f;

    string miCadenaDeTexto = "Hola, esto es una cadena de texto";

    bool miBoolean = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float sumaEntreDecenas = Sumar(10,20,3.8f);

        Debug.Log("inicio");
        Debug.Log(sumaEntreDecenas);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hola");
    }


    float Sumar (int num1, int num2, float num3)
    {

        float suma = num1 + num2 + num3;

        return suma;
    
    }


/*
&& a y b obligatorias
|| a o b, una de las dos
|| numa + numb = true then pasan cosas

Contador 
for (int i = 0; i <=10; i++)
{
    Debug.log(i+"veces");
}




*/

    //Esto es un comentario. uwu. 

    /*
    jsahbsadbdsaj
    akjshdkjashd
    ajshgdasd 
    */
    







}
