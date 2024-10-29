using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float maxVerticalAngle = 30f;
    public float maxHorizontalAngle = 45f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private Quaternion initialRotation;

    [SerializeField] private GameObject player;
    [SerializeField] private Player playerController;
    [SerializeField] private Animator animator;

    private bool canMoveCamera = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        if (canMoveCamera)  
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -maxHorizontalAngle, maxHorizontalAngle);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxVerticalAngle, maxVerticalAngle);

        Quaternion horizontalRotation = Quaternion.Euler(0f, yRotation, 0f);
        Quaternion verticalRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.localRotation = initialRotation * horizontalRotation * verticalRotation;
    }
    public void EnableCameraMovement()
    {
        canMoveCamera = true;
    }
}
