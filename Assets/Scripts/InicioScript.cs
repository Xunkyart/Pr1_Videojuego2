using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelSettings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelSettings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Escena");
    }


    public void showSettings()
    {
        panelSettings.SetActive(true);
        panelInicio.SetActive(false);
    }

    public void exit()
    {
        panelSettings.SetActive(false);
        panelInicio.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }


}
