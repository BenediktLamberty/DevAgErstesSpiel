using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PuzzleTestScene");
    }
   
    public void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
