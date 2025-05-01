using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button MainMenu;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    void Start()
    {
        
        startButton = GameObject.Find("Jugar").GetComponent<Button>();
        optionsButton = GameObject.Find("Ajustes").GetComponent<Button>();
        quitButton = GameObject.Find("Quit").GetComponent<Button>();
        MainMenu = GameObject.Find("MenuPrincipal").GetComponent<Button>();

        startButton.onClick.AddListener(Jugar);
        optionsButton.onClick.AddListener(Settings);
        quitButton.onClick.AddListener(QuitGame);
        MainMenu.onClick.AddListener(Menu);
    }

    void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void Settings()
    {
        
        SceneManager.LoadScene("Settings");
        audioManager.PlaySFX(audioManager.BackGround);
    }

    void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("SALISTE DEL JUEG0");
    }
}