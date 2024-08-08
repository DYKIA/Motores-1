using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

//TP2 - Joel Isaac Jim�nez
public class Jugador : Controller, IMovement
{
    public float life;

    private Transform target;

   

    // Implementaci�n de las propiedades de IMovement
    public float jumpForce { get; set; }
    public Rigidbody rb { get; set; }
    public float move { get; set; }

    private PowerUp[] powerUps;
    private int selectedPowerUpIndex = 0;

    // Delegate y evento para notificar la activaci�n de un PowerUp
    public delegate void PowerUpActivatedHandler(PowerUpType powerUpType);
    public event PowerUpActivatedHandler OnPowerUpActivated;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = 5.0f; // Salto


        //TP2 - Giuliano Acosta
        // Inicializa los power-ups
        powerUps = GetComponentsInChildren<PowerUp>();
        foreach (var powerUp in powerUps)
        {
            powerUp.Initialize(this); // Pasa una referencia del jugador al power-up
        }

       
    }




    private void Update()
    {
        InputController();


        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //TP2 - Giuliano Acosta
        // Selecci�n de power-up con teclas num�ricas
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedPowerUpIndex = 0;
            Debug.Log(" PowerUp 1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedPowerUpIndex = 1;
            Debug.Log("PowerUp 2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedPowerUpIndex = 2;
            Debug.Log(" PowerUp 3");
        }

        // Activaci�n de power-up con tecla F
        if (Input.GetKeyDown(KeyCode.F) && selectedPowerUpIndex != -1 && selectedPowerUpIndex < powerUps.Length)
        {
            powerUps[selectedPowerUpIndex].Activate();
        }

    }


    private void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // M�todo para verificar si el jugador est� en el suelo
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
   
    // M�todo para invocar el evento de activaci�n de PowerUp
    public void ActivatePowerUp(PowerUpType powerUpType)
    {
        OnPowerUpActivated?.Invoke(powerUpType);
    }




}


