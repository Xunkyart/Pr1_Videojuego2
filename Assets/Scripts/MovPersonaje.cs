using UnityEngine;

using UnityEngine.InputSystem;

public class MovPersonaje : MonoBehaviour
{

 public float velocidad = 0.05f;

 public GameObject senyal;

 Rigidbody2D rb;
 public float impulsoSalto = 1.0f;
   bool puedoSaltar = false;

  bool estoySaltando = false;

    public Vector3 inicioPersonaje = new Vector3(-3.5f, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

      rb = GetComponent<Rigidbody2D>();

      this.transform.position = inicioPersonaje;

    
      senyal = GameObject.Find("sign");
      
      
    }
    // Update is called once per frame
    void Update()
    {

      Vector2 moveInput =  (InputSystem.actions["Move"].ReadValue<Vector2>()); //Esto nos da [-1,1] , [0,1], ... lo que corresponda. Aquí resumimos todo el codigo de la línea en moveInput para no repetirlo todo

       this.transform.Translate(moveInput.x*velocidad, 0, 0);
       
       if (moveInput.x < 0)
       {
        this.GetComponent<SpriteRenderer>().flipX = true;
       }else if (moveInput.x>0){
          this.GetComponent<SpriteRenderer>().flipX = false;
        }



     //SALTO

      RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
      Debug.DrawRay(transform.position, Vector2.down*0.5f, Color.red);
      if(hit.collider == true)
      {
        Debug.Log(hit.collider.name);
        puedoSaltar = true;
      
      }else{
        puedoSaltar = false;
      }
      Debug.Log(puedoSaltar);

      if(puedoSaltar == true)
      {
        this.GetComponent<SpriteRenderer>().color = Color.red;


      }else
      {
        this.GetComponent<SpriteRenderer>().color = Color.white;


      }

     bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();
     
      if(salto==true && puedoSaltar == true)
      {
        rb.AddForce(transform.up*impulsoSalto*5,ForceMode2D.Impulse);

      }

      //DISPARO
      bool disparo = InputSystem.actions["Attack"].WasPressedThisFrame();

      if(disparo)
      {
        Instantiate(senyal, new Vector3(0,0,0), Quaternion.identity);
      }

    //La cámara nos sigue
    
     
     
      










    
    }



    







}
