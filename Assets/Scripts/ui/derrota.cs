using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class derrota : MonoBehaviour
{
  public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("menu");
    }
}
