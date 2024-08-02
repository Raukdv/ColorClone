using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartScreen()
    {
        int activeIndexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeIndexScene+1);
        Debug.Log("C inicio el juego");
    }
}
