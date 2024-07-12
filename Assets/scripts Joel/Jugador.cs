using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

//TP2 - Joel Isaac Jiménez
public class Jugador : Controller, IMovement
{
    public float life;

    private Transform target;

    /* public float jumpForce { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
     public Rigidbody rb { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
     public float move { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

     */

    // Implementación de las propiedades de IMovement
    public float jumpForce { get; set; }
    public Rigidbody rb { get; set; }
    public float move { get; set; }

    private PowerUp[] powerUps;
    private int selectedPowerUpIndex = 0;

    // Delegate y evento para notificar la activación de un PowerUp
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
        // Selección de power-up con teclas numéricas
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

        // Activación de power-up con tecla F
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
        // Método para verificar si el jugador está en el suelo
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
   
    // Método para invocar el evento de activación de PowerUp
    public void ActivatePowerUp(PowerUpType powerUpType)
    {
        OnPowerUpActivated?.Invoke(powerUpType);
    }




}


