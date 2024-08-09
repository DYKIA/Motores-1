using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour //TP-Final Fernando Nogueira
{
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync("as");
    }
}
