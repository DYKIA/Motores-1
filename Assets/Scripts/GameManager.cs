using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //TP2 - Giuliano Acosta
    public Jugador player;  // Referencia al jugador
    private int killsWinCount;  // N�mero de enemigos que deben ser eliminados para ganar
    private int currentKills;  // Contador de eliminaciones actuales


    public static GameManager Instance;


    void Start()
    {
        currentKills = 0;
    }

    // M�todo para incrementar el contador de eliminaciones
    public void AddKill()
    {
        currentKills++;
        CheckWinCondition();
    }

    // M�todo para verificar la condici�n de victoria
    public void CheckWinCondition()
    {
        if (currentKills >= killsWinCount)
        {
            WinCondition();
        }
    }

    // M�todo para ejecutar la l�gica de victoria
    public void WinCondition()
    {
        Debug.Log("You Win!");
        
    }
}
