using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]private Button MainMenu, Skins, Level1, Level2, Level3;
    


    public void MainMenuLoad()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Level1Load()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SkinsSceneLoad()
    {
        SceneManager.LoadScene("SkinSelection");
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
