using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public void CloseGame()
    {   
        Application.Quit(); //This just work if the app is exported.
        Debug.Log("C Wolsom el juego");
    }
}
