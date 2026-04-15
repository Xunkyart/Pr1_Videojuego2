using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int valor = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //coin
      if(col.gameObject.name =="Personaje")
      {
        GameManager.puntos += valor;

        gameObject.GetComponent<Animator>().SetBool("Obtener_coin", true);

        Destroy(this.gameObject, 1.0f);

      }
    }
}
