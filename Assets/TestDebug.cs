using UnityEngine;

public class TestDebug : MonoBehaviour
{
    void Start()
    {
        if (UserData.Instance != null)
        {
            Debug.Log($"📊 Datos recibidos: Nombre = {UserData.Instance.playerName}, Edad = {UserData.Instance.playerAge}, Tiempo = {UserData.Instance.gameTime} minutos.");
        }
        else
        {
            Debug.LogError("❌ No se encontró UserData en la escena de Test.");
        }
    }
}
