using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("ConfiguracionInicial"); 
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }


}