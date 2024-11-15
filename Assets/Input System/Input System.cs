using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }
    private InputMap inputActions;

    public static event Action<Vector2> OnMove;
    public static event Action<Vector2> OnRotate;
    public static event Action OnResetRotation;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        inputActions = new InputMap();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Basic.Movement.performed += OnMovementPerformed;
        inputActions.Basic.Movement.canceled += OnMovementCanceled;
        inputActions.Basic.Rotate.performed += OnRotatePerformed;
        inputActions.Basic.Rotate.canceled += OnRotateCanceled;
        inputActions.Basic.ResetRotation.started += OnResetRotationStarted;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Basic.Movement.performed -= OnMovementPerformed;
        inputActions.Basic.Movement.canceled -= OnMovementCanceled;
        inputActions.Basic.Rotate.performed -= OnRotatePerformed;
        inputActions.Basic.Rotate.canceled -= OnRotateCanceled;
        inputActions.Basic.ResetRotation.started -= OnResetRotationStarted;

    }
    
    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(Vector2.zero);
    }
    
    private void OnRotatePerformed(InputAction.CallbackContext context)
    {
        OnRotate?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void OnRotateCanceled(InputAction.CallbackContext context)
    {
        OnRotate?.Invoke(Vector2.zero);
    }
    private void OnResetRotationStarted(InputAction.CallbackContext context)
    {
        OnResetRotation?.Invoke();
    }
}