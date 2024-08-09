using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Slider healthBar; 
    public Jugador player;
    public CollectibleSystem collectibleSystem;
    public Text scoreText;
    public GameManager gameManager;

    private void Start()
    {   
        if (healthBar == null || player == null)
        {
            Debug.LogError("Faltan referencias en el UI_Manager.");
            return;
        }

        healthBar.maxValue = player.life; 
    }

    private void Update()
    {
        scoreText.text = "Score: " + collectibleSystem.playerPoints + "/" + gameManager.pointsToWin;
        healthBar.value = player.life;
    }
}
