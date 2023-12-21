using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] MainCharacterController charController = null;

    public event Action<float> OnForwardAxis = null;
    public event Action<float> OnRightAxis = null;
    public event Action<bool> OnJumpInput = null;
    public event Action<bool> OnSprintInput = null;
    public event Action<bool> OnCrouchInput = null;

    [SerializeField] bool isJumping = false;
    [SerializeField] bool isSprinting = false;
    [SerializeField] bool isCrouching = false;
    void Start()
    {
        InitCharacterMovement();
    }

    void Update()
    {
        CharacterMove();
        CharacterTurn();
        charController.CharAnimation.UpdateSpeedParam(isSprinting ? 2 : isCrouching ? .5f : 1);
    }
    void InitCharacterMovement()
    {
        charController = GetComponent<MainCharacterController>();
        if (charController == null ) Debug.LogError("MainCharacterController is missing!");
        charController.JumpInput.performed += CharacterJump;
        charController.SprintInput.performed += CharacterSprint;
        charController.CrouchInput.performed += CharacterCrouch;
    }
    public void CharacterMove()
    {
        float _value = charController.MoveInput.ReadValue<float>();
        OnForwardAxis?.Invoke(_value);
    }
    public void CharacterTurn()
    {
        float _value = charController.TurnInput.ReadValue<float>();
        OnRightAxis?.Invoke(_value);

    }
    public void CharacterJump(InputAction.CallbackContext _context)
    {
        isJumping = _context.ReadValueAsButton();
        OnJumpInput?.Invoke(isJumping);
    }
    public void CharacterSprint(InputAction.CallbackContext _context)
    {
        isSprinting = _context.ReadValueAsButton();
        OnSprintInput?.Invoke(isSprinting);
    }
    public void CharacterCrouch(InputAction.CallbackContext _context)
    {
        isCrouching = _context.ReadValueAsButton();
        OnCrouchInput?.Invoke(isCrouching);
    }
}
