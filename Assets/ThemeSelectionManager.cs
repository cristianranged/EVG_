using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThemeSelectionManager : MonoBehaviour
{
    [SerializeField] private Button continueButton; // Botón para continuar al test
    private string selectedTheme = ""; // Inicializado como vacío

    private void Start()
    {
        if (continueButton != null)
        {
            continueButton.interactable = false; // Desactivado hasta seleccionar una temática
        }
        
    }

    public void SelectTheme(string theme)
    {
        selectedTheme = theme;
        UserData.Instance.selectedTheme = selectedTheme; // Guardar en el Singleton
        if (continueButton != null)
        {
            continueButton.interactable = true; // Activar el botón de continuar
        }

        Debug.Log($"📥 Temática seleccionada: {selectedTheme}");
    }

    public void ContinueToTest()
    {
        if (!string.IsNullOrEmpty(UserData.Instance.selectedTheme))
        {
            Debug.Log("Cambiando a la escena de Test...");
            SceneManager.LoadScene("Test"); // Cambia por el nombre de tu escena de test
        }
        else
        {
            Debug.LogError("⚠️ No se ha seleccionado ninguna temática.");
        }
    }
}
