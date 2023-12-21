using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAction : MonoBehaviour
{
    [SerializeField] MainCharacterController charController = null;

    public event Action<bool> OnLeftAttackInput = null;
    public event Action<bool> OnRightAttackInput = null;

    [SerializeField] bool isLeftAttacking = false;
    [SerializeField] bool isRightAttacking = false;
    void Start()
    {
        InitCharacterAction();
    }

    void Update()
    {
        
    }
    void InitCharacterAction()
    {
        charController = GetComponent<MainCharacterController>();
        if (charController == null) Debug.LogError("MainCharacterController is missing!");

        charController.LeftAttackInput.performed += CharacterLeftAttack;
        charController.RightAttackInput.performed += CharacterRightAttack;
    }

    public void CharacterLeftAttack(InputAction.CallbackContext _context)
    {
        isLeftAttacking = _context.ReadValueAsButton();
        OnLeftAttackInput?.Invoke(isLeftAttacking);
    } 
    public void CharacterRightAttack(InputAction.CallbackContext _context)
    {
        isRightAttacking = _context.ReadValueAsButton();
        OnRightAttackInput?.Invoke(isRightAttacking);
    }
}
