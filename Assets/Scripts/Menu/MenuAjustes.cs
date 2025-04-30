using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAjustes : MonoBehaviour
{
    public void Jugar() 
    {
        SceneManager.LoadScene("SampleScene");
    
    }public void MenuPrincipal() 
    {
        SceneManager.LoadScene("Menu");
    
    }
}
