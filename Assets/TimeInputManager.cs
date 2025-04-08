using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeInputManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField ageInput;
    public TMP_InputField timeInput;

    public void GetData()
    {
        if (nameInput == null || ageInput == null || timeInput == null)
        {
            Debug.LogError("⚠️ Asegúrate de que todos los campos de entrada estén asignados.");
            return;
        }

        if (UserData.Instance == null)
        {
            Debug.LogError("⚠️ No se ha encontrado UserData. Asegúrate de que exista en la escena inicial y no se destruya.");
            return;
        }

        // Validar y guardar el nombre
        string playerName = nameInput.text;
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogError("⚠️ Ingrese un nombre válido.");
            return;
        }

        // Validar y guardar la edad
        if (!int.TryParse(ageInput.text, out int playerAge) || playerAge <= 0)
        {
            Debug.LogError("⚠️ Ingrese una edad válida.");
            return;
        }

        // Validar y guardar el tiempo de juego
        if (!int.TryParse(timeInput.text, out int gameTime) || gameTime <= 0)
        {
            Debug.LogError("⚠️ Ingrese un tiempo de juego válido (en minutos).");
            return;
        }

        // Guardar datos en el UserData singleton
        UserData.Instance.playerName = playerName;
        UserData.Instance.playerAge = playerAge;
        UserData.Instance.gameTime = gameTime;

        Debug.Log($"📥 Datos guardados: Nombre = {playerName}, Edad = {playerAge}, Tiempo = {gameTime} minutos");

        // Cambiar a la escena de juego
        SceneManager.LoadScene("SelectTematic"); // Cambia por el nombre real de tu escena de juego
    }

}