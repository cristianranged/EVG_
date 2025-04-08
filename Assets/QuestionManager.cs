using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class QuestionManager : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_Text ScoreText;
    public Text FinalScore;
    public Button[] replyButtons;
    public Qts_Data qtsData;
    public GameObject Win;
    public GameObject Wrong;
    public GameObject GameFinished;

    public Button RestartButton; // NUEVO: Botón para reiniciar el test
    public Button MainMenuButton; // NUEVO: Botón para ir al menú principal

    private int currentQuestion = 0;
    private static int score = 0;

    private void Start()
    {
        SetQuestion(currentQuestion);
        Win.gameObject.SetActive(false);
        Wrong.gameObject.SetActive(false);
        GameFinished.gameObject.SetActive(false);

        RestartButton.gameObject.SetActive(false); // 🔥 Ocultar botón de Reinicio al inicio
        MainMenuButton.gameObject.SetActive(false); // 🔥 Ocultar botón de Menú Principal al inicio
        RestartButton.onClick.AddListener(RestartTest); // NUEVO
        MainMenuButton.onClick.AddListener(GoToMainMenu); // NUEVO

        //Tema seleccionado
        string temaSeleccionado = UserData.Instance.selectedTheme;
        Debug.Log($"Temática actual: {temaSeleccionado}");

    }

    void SetQuestion(int questionIndex)
    {
        questionText.text = qtsData.questions[questionIndex].questionText;


        foreach (Button r in replyButtons)
        {
          
            r.onClick.RemoveAllListeners();
        }

        for (int i = 0; i < replyButtons.Length; i++)
        {
            replyButtons[i].GetComponentInChildren<Text>().text = qtsData.questions[questionIndex].replies[i];
            int replyIndex = i;
            replyButtons[i].onClick.AddListener(() =>
            {
                CheckReplay(replyIndex);
            });
        }
    }

    void CheckReplay(int replyIndex)
    {
        if (replyIndex == qtsData.questions[currentQuestion].correctReplyIndex)
        {
            score++;
            ScoreText.text = "" + score;

            Win.gameObject.SetActive(true);

            /*foreach (Button r in replyButtons)
            {
                r.interactable = false;
            }*/
            // Boton home restart
            DisableButtons();
            //
            StartCoroutine(Next());
        }

        else
        {
            Wrong.gameObject.SetActive(true);
            /*foreach (Button r in replyButtons)
            {
                r.interactable = false;
            }*/

            StartCoroutine(Next());
        }
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(1);

        currentQuestion++;

        if (currentQuestion < qtsData.questions.Length)
        {
            Reset();
        }
        else
        {
            //Game over
            GameFinished.SetActive(true);

            String playerName = UserData.Instance.playerName;
            int playerAge = UserData.Instance.playerAge;

            //Calculate the score percentage
            float scorePercentage = (float)score / qtsData.questions.Length * 100;

            //Display the score percentage
            FinalScore.text = "Nombre: " + playerName + "\nEdad: " + playerAge + "\nYour scored: " + scorePercentage.ToString("F0") + "%";

            //Display the appropriate message bases on the score percentage
            if (scorePercentage < 50)
            {
                FinalScore.text += "\nGame Over";
            }
            else if (scorePercentage < 60)
            {
                FinalScore.text += "\nKeep Trying";
            }
            else if (scorePercentage < 70)
            {
                FinalScore.text += "\nGood Job";
            }
            else if (scorePercentage < 80)
            {
                FinalScore.text += "\nWeel Done!";
            }
            else
            {
                FinalScore.text += "\nYou´re a genius!";
            }

            RestartButton.gameObject.SetActive(true); // Mostrar el botón de reinicio
            MainMenuButton.gameObject.SetActive(true); // Mostrar el botón de menú principal
        }
    }

    public void Reset()
    {
        //Hide boot the "Weel Done" and "Wrong" panels
        Win.SetActive(false);
        Wrong.SetActive(false);

        //Enable all reply buttons
        foreach (Button r in replyButtons)
        {
            r.interactable = true;
        }

        //Set the next question
        SetQuestion(currentQuestion);
    }


    // Boton de restart y/o home 
    private void DisableButtons()
    {
        foreach (Button r in replyButtons)
        {
            r.interactable = false;
        }
    }

    private void RestartTest()
    {
        currentQuestion = 0;
        score = 0;
        ScoreText.text = "0";
        GameFinished.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        MainMenuButton.gameObject.SetActive(false);
        Reset();
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Cambia esto al nombre exacto de tu escena del menú principal
    }

}