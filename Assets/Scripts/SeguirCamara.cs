using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public GameObject Personaje;

    Vector3 dondePersonaje;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dondePersonaje = Personaje.transform.position;

        transform.position = new Vector3(dondePersonaje.x, dondePersonaje.y, -10.0f);
    }
}
