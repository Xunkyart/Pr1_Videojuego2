using UnityEngine;

using UnityEngine.InputSystem;

public class MovPersonaje : MonoBehaviour
{

 public float velocidad = 0.05f;

    public Vector3 inicioPersonaje = new Vector3(-3.5f, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

      this.transform.position = inicioPersonaje;
      
    }
    // Update is called once per frame
    void Update()
    {

      Vector2 moveInput =  (InputSystem.actions["Move"].ReadValue<Vector2>());

       this.transform.Translate(moveInput.x*velocidad, moveInput.y*velocidad, 0);

     


      








/*
      Esto mueve solo al personaje 0.01 en x cada frame. Ambas límeas de código hacen lo mismo.

      this.transform.position = new Vector3(this.transform.position.x + 0.01f, this.transform.position.y,0);

     
*/

    
    }



    







}
