using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : Singleton<GameInput>
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;

    private PlayerControls playerInput;

    private void Awake()
    {
        playerInput = new PlayerControls();
        playerInput.Player.Enable();

        playerInput.Player.Interact.performed += Interact_Performed;
        playerInput.Player.InteractAlternate.performed += InteractAlternate_Performed;
    }

    private void InteractAlternate_Performed(InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_Performed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }


    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
