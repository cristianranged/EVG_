using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText; // Referencia al texto que mostrará el tiempo
    private float timeRemaining;
    private bool isRunning = false;

    void Start()
    {
        int savedTime = PlayerPrefs.GetInt("GameTime", 0); // Recupera el tiempo guardado

        if (savedTime > 0)
        {
            timeRemaining = savedTime * 60; // Convierte minutos a segundos
            isRunning = true;
        }
        else
        {
            Debug.LogError("⚠️ No hay un tiempo válido guardado. Asigna un tiempo antes de iniciar.");
        }
    }

    void Update()
    {
        if (isRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else if (timeRemaining <= 0 && isRunning)
        {
            isRunning = false;
            TimeUp();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimeUp()
    {
        timerText.text = "00:00";
        Debug.Log("⏳ ¡Tiempo terminado! Bloqueando el juego...");
        // Aquí puedes bloquear el juego, mostrar un mensaje o cambiar de escena
    }
}