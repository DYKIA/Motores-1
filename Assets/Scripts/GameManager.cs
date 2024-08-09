using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CollectibleSystem collectibleSystem;  
    public int pointsToWin;  

    void Update()
    {
        CheckWinCondition();
    }

    public void CheckWinCondition()
    {
        if (collectibleSystem.playerPoints >= pointsToWin)
        {
            WinCondition();
        }
    }

   
    public void WinCondition()
    {
        Debug.Log("You Win!");
       
    }
}
