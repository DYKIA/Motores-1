using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

public class Jugador : Controller, IMovement
{
    public float life;
    
    //implementacion interface IMovement
    public float jumpForce { get; set; }
    public Rigidbody rb { get; set; }
    public float move { get; set; }

    private PowerUp[] powerUps;
    private int selectedPowerUpIndex = 0;

    public delegate void PowerUpActivatedHandler(PowerUpType powerUpType);
    public event PowerUpActivatedHandler OnPowerUpActivated;

    public Collider feetCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        feetCollider = GetComponentInChildren<Collider>();
        jumpForce = 5.0f;

        powerUps = GetComponentsInChildren<PowerUp>();
        foreach (var powerUp in powerUps)
        {
            powerUp.Initialize(this);
        }

        mainCamera = Camera.main;
    }

    private void Update()
    {
        InputController();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

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
        return Physics.Raycast(feetCollider.bounds.center, Vector3.down, feetCollider.bounds.extents.y + 0.1f);
    }

    public void ActivatePowerUp(PowerUpType powerUpType)
    {
        OnPowerUpActivated?.Invoke(powerUpType);
    }

    protected override void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        Debug.Log("pj recibio damage, quedan " + life + " de vida");
    }
}
