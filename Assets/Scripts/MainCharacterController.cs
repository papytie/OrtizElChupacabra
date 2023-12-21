using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterMovement), typeof(CharacterAction), typeof(CharacterAnimation))]

public class MainCharacterController : MonoBehaviour
{
    [SerializeField] CharacterMovement charMovement = null;
    [SerializeField] CharacterAction charAction = null;
    [SerializeField] CharacterAnimation charAnimation = null;
    public CharacterMovement CharMovement => charMovement;
    public CharacterAction CharAction => charAction;
    public CharacterAnimation CharAnimation => charAnimation;

    [SerializeField] Inputs charInputs = null;
    [SerializeField] InputAction moveInput = null;
    [SerializeField] InputAction turnInput = null;
    [SerializeField] InputAction jumpInput = null;
    [SerializeField] InputAction sprintInput = null;
    [SerializeField] InputAction crouchInput = null;
    [SerializeField] InputAction leftAttackInput = null;
    [SerializeField] InputAction rightAttackInput = null;
    public Inputs CharInputs => charInputs;
    public InputAction MoveInput => moveInput;
    public InputAction TurnInput => turnInput;
    public InputAction JumpInput => jumpInput;
    public InputAction SprintInput => sprintInput;
    public InputAction CrouchInput => crouchInput;
    public InputAction LeftAttackInput => leftAttackInput;
    public InputAction RightAttackInput => rightAttackInput;


    private void Awake()
    {
        InitMainCharacterController();
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void InitMainCharacterController()
    {
        //Cursor.lockState = CursorLockMode.Locked; //Lock the cursor of the mouse in the screen
        charMovement = GetComponent<CharacterMovement>();
        if (charMovement == null) Debug.LogError("CharacterMovement is missing!");
        charAction = GetComponent<CharacterAction>();
        if (charAction == null) Debug.LogError("CharacterAction is missing!");
        charAnimation = GetComponent<CharacterAnimation>();
        if (charAnimation == null) Debug.LogError("CharacterAnimation is missing!");
        charInputs = new Inputs();
        if (charInputs == null) Debug.LogError("IAA Inputs is missing!");

        charMovement.OnForwardAxis += charAnimation.UpdateForwardParam;
        charMovement.OnRightAxis += charAnimation.UpdateRightParam;
        charMovement.OnJumpInput += charAnimation.UpdateJumpParam;
        charMovement.OnSprintInput += charAnimation.UpdateSprintParam;
        charMovement.OnCrouchInput += charAnimation.UpdateCrouchParam;

        charAction.OnLeftAttackInput += charAnimation.UpdateLeftAttackParam;
        charAction.OnRightAttackInput += charAnimation.UpdateRightAttackParam;

    }



    private void OnEnable()
    {
        moveInput = charInputs.Character.Move;
        moveInput.Enable();
        turnInput = charInputs.Character.Turn;
        turnInput.Enable();
        jumpInput = charInputs.Character.Jump;
        jumpInput.Enable();
        sprintInput = charInputs.Character.Sprint;
        sprintInput.Enable();
        crouchInput = charInputs.Character.Crouch;
        crouchInput.Enable();
        leftAttackInput = charInputs.Character.LeftAttack;
        leftAttackInput.Enable();
        rightAttackInput = charInputs.Character.RightAttack;
        rightAttackInput.Enable();
    }
}
