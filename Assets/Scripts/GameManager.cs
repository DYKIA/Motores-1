using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Jugador player;
    public CollectibleSystem collectibleSystem;  
    public int pointsToWin;

    void Update()
    {
        CheckWinCondition();
        CheckLoseCondition();
    }

    public void CheckWinCondition()
    {
        if (collectibleSystem.playerPoints >= pointsToWin)
        {
            WinCondition();
        }
    }
    public void CheckLoseCondition()
    {
        if (player.life <= 0)
        {
            LoseCondition();
        }
    }


    public void WinCondition()
    {
        SceneManager.LoadSceneAsync("victoria");
        Debug.Log("You Win!");
    }

    public void LoseCondition()
    {
        SceneManager.LoadSceneAsync("derrota");
        Debug.Log("You Lose!");
    }
}
