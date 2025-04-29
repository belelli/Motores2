using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.ComponentModel.Design;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] int cannonsToHit = 3;
    [SerializeField] int playerInitialLives = 3;

    [Header("UI References")]
    [SerializeField] TextMeshProUGUI objectivesText;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    public static GameManager Instance { get; private set; }

    private int cannonsHit = 0;
    private int playerLives;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            playerLives = playerInitialLives;
        }
        else
        {
            Destroy(gameObject);
            return;
        }





    }

    void Start()
    {
        FindUIReferences();
        UpdateUI();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Clear previous references
        //objectivesText = null;
        //winPanel = null;
        //losePanel = null;


        // Find new references
        FindUIReferences();

        // Reset UI state
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);


        UpdateUI();
    }

    void FindUIReferences()
    {
        GameObject objTextGO = GameObject.FindGameObjectWithTag("ObjectivesText");
        if (objTextGO != null)
        {
            objectivesText = objTextGO.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            //Debug.LogError("No se encontró GameObject");
        }

        // Buscar los paneles
        winPanel = GameObject.FindGameObjectWithTag("WinPanel");
        losePanel = GameObject.FindGameObjectWithTag("LosePanel");

        // Verificar que se encontraron
        //if (objectivesText == null) Debug.LogError("TextMeshProUGUI no encontrado");
        //if (winPanel == null) Debug.LogError("WinPanel no encontrado");
        //if (losePanel == null) Debug.LogError("LosePanel no encontrado");
    }

    public void CannonHit()
    {
        cannonsHit++;
        Debug.Log($"Cañones golpeados: {cannonsHit}/{cannonsToHit}");
        UpdateUI();

        if (cannonsHit >= cannonsToHit)
        {
            Debug.Log("¡Todos los cañones alcanzados!");
            WinGame();
        }
    }

    public void PlayerFailed()
    {
        playerLives--;
        Debug.Log($"Vidas restantes: {playerLives}");
        UpdateUI();

        if (playerLives <= 0)
        {
            Debug.Log("¡Game Over!");
            LoseGame();
            playerLives = playerInitialLives;
            cannonsHit = 0;
        }
        else
        {
            Debug.Log("Reiniciando escena...");
            cannonsHit = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateUI()
    {
        if (objectivesText != null)
        {
            objectivesText.text = $"Cannons: {cannonsHit}/{cannonsToHit}\nLives: {playerLives}";
            Debug.Log("UI actualizada: " + objectivesText.text);
        }
        else
        {
            Debug.LogWarning("objectivesText es null en UpdateUI()");
        }
    }

    void WinGame()
    {
        Debug.Log("Intentando activar winPanel");
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("winPanel activado correctamente");
        }
        else
        {
            Debug.LogError("winPanel es null en WinGame()");
        }
    }

    void LoseGame()
    {
        Debug.Log("Intentando activar losePanel");
        if (losePanel != null)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("losePanel activado correctamente");
        }
        else
        {
            //Debug.LogError("losePanel es null en LoseGame()");
        }
    }

    public void RestartGame()
    {
        playerLives = playerInitialLives;
        cannonsHit = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}






// Un Canvas para win
//un canvas para loose

// los serializas, 
// si tocas el flag pole, ganas, winCanvas.setActive(true)
// perdes una vida : te manda a un Spawn Point. 