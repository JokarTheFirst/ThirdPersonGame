using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenUI : MonoBehaviour
{
    public void EnableGameOverScreen()
    {
        gameObject.SetActive(true);
    }
    public void ResetTheLevel()
    {
        if (gameObject.activeSelf) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
