using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerCamera : MonoBehaviour
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

    public bool canMoveCamera = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        initialRotation = transform.localRotation;
    }

    void LateUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            //canMoveCamera = true;
        }
        if (canMoveCamera)  
        {
            MoveCamera();
        }
    }

    public void canMoveCameraVoid()
    {
        canMoveCamera = true;
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