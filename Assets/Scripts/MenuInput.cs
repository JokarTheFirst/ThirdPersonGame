using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInput : MonoBehaviour
{
    bool canReset = false;
    public void QuitGame()
    {
        Debug.Log("I Quit!");
        Application.Quit();
    }
    public void AllowToReset()
    {
        canReset = true;
    }
    public void ResetTheLevel()
    {
        if (canReset) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
