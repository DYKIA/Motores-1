using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //TP2 - Giuliano Acosta
    public Jugador player;  // Referencia al jugador
    private int killsWinCount;  // Número de enemigos que deben ser eliminados para ganar
    private int currentKills;  // Contador de eliminaciones actuales


    public static GameManager Instance;


    void Start()
    {
        currentKills = 0;
    }

    // Método para incrementar el contador de eliminaciones
    public void AddKill()
    {
        currentKills++;
        CheckWinCondition();
    }

    // Método para verificar la condición de victoria
    public void CheckWinCondition()
    {
        if (currentKills >= killsWinCount)
        {
            WinCondition();
        }
    }

    // Método para ejecutar la lógica de victoria
    public void WinCondition()
    {
        Debug.Log("You Win!");
        
    }
}
