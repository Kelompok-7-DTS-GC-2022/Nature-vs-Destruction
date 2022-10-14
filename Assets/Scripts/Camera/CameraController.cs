using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.Speech;

public class CameraController : MonoBehaviour
{

    //movement
    float cameraSpeed;
    [SerializeField]
    private float cameraMovementMaxSpeed = 5;
    [SerializeField]
    private float cameraDamp = 15;
    [SerializeField]
    private float cameraAceleration = 10;
    //rotation
    [SerializeField]
    private float cameraRotationSpeed = 2;
    //zoom
    private Vector3 zoomPosition;
    [SerializeField]
    private float cameraZoomStep = 2;
    [SerializeField]
    private float cameraMaxHeight = 100;
    [SerializeField]
    private float cameraMinHeight = 10;
    [SerializeField]
    private Vector3 cameraZoomSpeed;
    [SerializeField]
    private Vector3 targetPosition;
    [SerializeField]
    private Vector3 lastPosition;
    [SerializeField]
    private Vector3 horizontalVelocity;
    private Quaternion newRotation;
    private CameraInput cameraInput;
    private Transform cameraTransform;
    private InputAction movementInputAction;

    #region CameraSetup
    //use this function for UI setting purpose, call in the awake functoin
    public void setCameraSetting(float cameraMovementSpeed, float cameraRotationSpeed)
    {
        this.cameraMovementMaxSpeed = cameraMovementSpeed;
        this.cameraRotationSpeed = cameraRotationSpeed;
    }

    private void Awake()
    {
        cameraInput = new CameraInput();
        cameraTransform = GetComponentInChildren<Camera>().transform;
        newRotation = transform.rotation;
        zoomPosition = cameraTransform.localPosition;
    }
    private void Update()
    {
        keyboardMovement();
        updateCameraVelocity();
        updateCamerPosition();
        updateCameraRotation();
        updateZoomPosition();
    }

    private void OnEnable()
    {
        lastPosition = this.transform.position;
        movementInputAction = cameraInput.Camera.Movement;
        cameraInput.Camera.Rotation.performed += cameraRotation;
        cameraInput.Camera.Zoom.performed += cameraZoom;
        cameraInput.Enable();
    }

    private void OnDisable()
    {
        cameraInput.Camera.Rotation.performed -= cameraRotation;
        cameraInput.Disable();
    }
    #endregion

    #region CameraHorizonalMovement
    void updateCameraVelocity()
    {
        horizontalVelocity = (this.transform.position - lastPosition) / Time.deltaTime;
        horizontalVelocity.y = 0;
        lastPosition = transform.position;
    }

    void keyboardMovement()
    {
        var inputValue = movementInputAction.ReadValue<Vector2>().x * getCameraRightPosition()
                            + movementInputAction.ReadValue<Vector2>().y * getCameraForwardPosition();
        inputValue = inputValue.normalized;
        if (inputValue.sqrMagnitude > 0.1f) targetPosition += inputValue;
    }

    Vector3 getCameraRightPosition()
    {
        var camPosition = cameraTransform.right;
        camPosition.y = 0;
        return camPosition;
    }

    Vector3 getCameraForwardPosition()
    {
        var camPosition = cameraTransform.forward;
        camPosition.y = 0;
        return camPosition;
    }

    void updateCamerPosition()
    {
        if (targetPosition.sqrMagnitude > 0.5f)
        {

            cameraSpeed = Mathf.Lerp(cameraSpeed, cameraMovementMaxSpeed, Time.deltaTime * cameraAceleration);
            this.transform.position += targetPosition * cameraSpeed * Time.deltaTime;
        }
        else
        {
            horizontalVelocity = Vector3.Lerp(horizontalVelocity, Vector3.zero, Time.deltaTime * cameraDamp);
            this.transform.position += horizontalVelocity * Time.deltaTime;
        }
        targetPosition = Vector3.zero;
    }
    #endregion

    #region CamerRotation
    private void cameraRotation(InputAction.CallbackContext inputAction)
    {
        if (!(Mouse.current.leftButton.isPressed && Mouse.current.rightButton.isPressed)) return;
        var inputValue = inputAction.ReadValue<Vector2>().x;

        newRotation *= Quaternion.Euler(Vector3.up * inputValue * cameraRotationSpeed);
    }
    void updateCameraRotation() => transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * cameraAceleration);
    #endregion

    #region CamerZoom

    private void cameraZoom(InputAction.CallbackContext inputValue)
    {
        var scrolInput = -inputValue.ReadValue<Vector2>();
        Vector2.ClampMagnitude(scrolInput, cameraMaxHeight);
        scrolInput /= 5;
        scrolInput.y = Mathf.Clamp(scrolInput.y, cameraMinHeight, cameraMaxHeight);
        zoomPosition.y = scrolInput.y;
        zoomPosition.z = -scrolInput.y;

    }
    void updateZoomPosition() => cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, zoomPosition, Time.deltaTime * cameraZoomStep);

    #endregion

}
