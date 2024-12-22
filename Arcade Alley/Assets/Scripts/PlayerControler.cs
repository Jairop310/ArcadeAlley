using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float rotationSpeed = 700f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        // Movimiento con teclas WASD
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical"); 

        Vector3 movement = transform.forward * moveVertical + transform.right * moveHorizontal;
        movement.Normalize();

        // Aplicar movimiento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        // Rotación con el ratón
        float mouseX = Input.GetAxis("Mouse X"); 
        Vector3 rotation = new Vector3(0f, mouseX * rotationSpeed * Time.deltaTime, 0f);

        // Aplicar rotación
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }
}
