using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;

    void Start()
    {
        startButton = GameObject.Find("Jugar").GetComponent<Button>();
        optionsButton = GameObject.Find("Ajustes").GetComponent<Button>();
        quitButton = GameObject.Find("Quit").GetComponent<Button>();

        startButton.onClick.AddListener(Jugar);
        optionsButton.onClick.AddListener(Settings);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Jugar()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    void Settings()
    {
        SceneManager.LoadScene("Settings");
        
        // AudioManager.Instance.PlaySFX(AudioManager.Instance.BackGround);
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("SALISTE DEL JUEGO");
    }
}