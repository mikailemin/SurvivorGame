using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Hareket hızı
    public float rotationSpeed = 100.0f; // Dönme hızı

    void Update()
    {
        // Joystick girişlerini alın
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket vektörünü oluşturun
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        // Karakteri hareket ettirin
        transform.Translate(moveDirection * Time.deltaTime);

        // Joystick ile karakterin dönmesini sağlayın
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

