using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP-Final Fernando Nogueira
public class Camara : MonoBehaviour
{

    public Transform player; 
    public Vector3 offset; 
    public float smoothSpeed = 0.125f; 
    public float rotationSpeed = 5.0f; 
    public float minYAngle = -20f; 
    public float maxYAngle = 80f; 

    private float currentRotationX;
    private float currentRotationY;



    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        currentRotationX = angles.y; 
        currentRotationY = angles.x; 
    }

    void LateUpdate()
    {
   
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed; 

       
        currentRotationX += horizontalInput;
        currentRotationY += verticalInput; 

        
        currentRotationY = Mathf.Clamp(currentRotationY, minYAngle, maxYAngle);

        
        Quaternion rotation = Quaternion.Euler(currentRotationY, currentRotationX, 0);
        Vector3 desiredPosition = player.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

       
        transform.position = smoothedPosition;
        transform.LookAt(player);
    }

}
