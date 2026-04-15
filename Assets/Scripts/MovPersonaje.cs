using UnityEngine;

using UnityEngine.InputSystem;

public class MovPersonaje : MonoBehaviour
{

 public float velocidad = 0.05f;

 public GameObject senyal;

 Rigidbody2D rb;

 Animator controlAnimación;

 GameObject respawn;
 GameObject coin;

 public float impulsoSalto = 1.0f;
   bool puedoSaltar = false;

  bool estoySaltando = false;

  public bool direccionBalaDerecha = true;

    public Vector3 inicioPersonaje = new Vector3(-3.5f, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

      rb = GetComponent<Rigidbody2D>();
    
      senyal = GameObject.Find("sign");
      
      controlAnimación = GetComponent<Animator>();

      respawn = GameObject.Find("Respawn");

      coin = GameObject.Find("Coin");

      transform.position = respawn.transform.position;
      
    }
    // Update is called once per frame
    void Update()
    {

      //MOVIMIENTO

      Vector2 moveInput =  (InputSystem.actions["Move"].ReadValue<Vector2>()); //Esto nos da [-1,1] , [0,1], ... lo que corresponda. Aquí resumimos todo el codigo de la línea en moveInput para no repetirlo todo

       this.transform.Translate(moveInput.x*velocidad, 0, 0);
       
       if (moveInput.x < 0)
       {
        direccionBalaDerecha = false;
        this.GetComponent<SpriteRenderer>().flipX = true;
       }else if (moveInput.x>0){
        direccionBalaDerecha = true;
          this.GetComponent<SpriteRenderer>().flipX = false;
        }

      //LA ANIMACIÓN CAMBIA ENTRE IDLE Y CAMINANDO

      if (moveInput.x !=0)
      {
        controlAnimación.SetBool("activaCamina", true);
      }else{
        controlAnimación.SetBool("activaCamina", false);
      }

     //SALTO

      RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
      //Debug.DrawRay(transform.position, Vector2.down*0.5f, Color.red);
      if(hit.collider == true)
      {
        //Debug.Log(hit.collider.name);
        puedoSaltar = true;
      
      }else{
        puedoSaltar = false;
      }
      Debug.Log(puedoSaltar);

      /*if(puedoSaltar == true)
      {
        this.GetComponent<SpriteRenderer>().color = Color.red;


      }else
      {
        this.GetComponent<SpriteRenderer>().color = Color.white;


      }*/

     bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();
     
      if(salto==true && puedoSaltar == true)
      {
        rb.AddForce(transform.up*impulsoSalto*5,ForceMode2D.Impulse);

      }

      /*DISPARO
      bool disparo = InputSystem.actions["Attack"].WasPressedThisFrame();

      if(disparo)
      {
        Instantiate(senyal, new Vector3(0,0,0), Quaternion.identity);
      }
*/   
    /*void OnTriggerEnter2D(Collider2D otroObjeto)
    {
      if(otroObjeto.gameObject.name == "Coin")
      {
        otroObjeto.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
      }
    }*/


    
    }


    void OnTriggerEnter2D(Collider2D col)
    {
      Debug.Log("Trigger con: " + col.gameObject.name);

      if(col.gameObject.name == "pinxo")
      {
        GameManager.vidas = GameManager.vidas - 1;

        transform.position = respawn.transform.position;
      }

      //Checkpoint

      if(col.gameObject.name == "Checkpoint")
      {
        respawn.transform.position = new Vector3(3,-2,0);
      }


    }
    
   


    







}
