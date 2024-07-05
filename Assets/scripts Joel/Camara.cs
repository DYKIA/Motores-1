using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    //TP2 - Giuliano Acosta

    public Transform player; // Referencia al transform del jugador
    public Vector3 offset; // Desplazamiento de la cámara respecto al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public float rotationSpeed = 5.0f; // Velocidad de rotación
    public float minYAngle = -20f; // Ángulo mínimo en el eje Y
    public float maxYAngle = 80f; // Ángulo máximo en el eje Y

    private float currentRotationX;
    private float currentRotationY;


    

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        currentRotationX = angles.y; // Obtiene el ángulo de rotación actual en el eje X
        currentRotationY = angles.x; // Obtiene el ángulo de rotación actual en el eje Y
    }

    void LateUpdate()
    {
        // Obtiene el movimiento del mouse
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        float verticalInput = -Input.GetAxis("Mouse Y") * rotationSpeed;

        // Actualiza los ángulos de rotación
        currentRotationX += horizontalInput;
        currentRotationY += verticalInput;

        // Limita el ángulo de rotación en el eje Y
        currentRotationY = Mathf.Clamp(currentRotationY, minYAngle, maxYAngle);

        // Aplica las rotaciones
        Quaternion rotation = Quaternion.Euler(currentRotationY, currentRotationX, 0);
        Vector3 desiredPosition = player.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualiza la posición y rotación de la cámara
        transform.position = smoothedPosition;
        transform.LookAt(player);
    }
}
