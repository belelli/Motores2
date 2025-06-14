using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]private Button MainMenu, Level1, Level2, Level3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Level1Load()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2Load()
    {
        //SceneManager.LoadScene("Level2");
    }
    void Level3Load()
    {
        //SceneManager.LoadScene("Level3");
    }
    
    
}
