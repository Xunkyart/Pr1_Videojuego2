using UnityEngine;

public class MovPersonaje : MonoBehaviour
{

    public Vector3 inicioPersonaje = new Vector3(-3.5f, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

      this.transform.position = inicioPersonaje;
      
    }
    // Update is called once per frame
    void Update()
    {
/*
      Esto mueve solo al personaje 0.01 en x cada frame. Ambas límeas de código hacen lo mismo.

      this.transform.position = new Vector3(this.transform.position.x + 0.01f, this.transform.position.y,0);

      this.transform.Translate(0.01f,0,0);
*/


      

    
    }



    







}
