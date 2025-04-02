using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderGameManager : MonoBehaviour
{
    public void LoadScene()
    {
        Debug.Log("Cargando escena: " + 1);
        SceneManager.LoadScene(1);
    }
}