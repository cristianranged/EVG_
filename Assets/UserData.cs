using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData Instance; // Singleton

    public string playerName;
    public int playerAge;
    public int gameTime; // En minutos
    public int score; // Se puede usar para registrar puntaje

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cargar nuevas escenas
            Debug.Log("✅ UserData creado y marcado como DontDestroyOnLoad.");
        }
        else
        {
            Debug.Log("❌ UserData duplicado encontrado y destruido.");
            Destroy(gameObject); // Evita duplicados
        }
    }

    private void OnDestroy()
    {
        Debug.Log("🔥 UserData ha sido destruido.");
    }
}