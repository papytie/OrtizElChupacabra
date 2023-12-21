using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    //[SerializeField] MainCharacterController charController = null;
    [SerializeField] Animator charAnimator = null;

    [SerializeField] float fwdDamping = .2f;
    [SerializeField] float rgtDamping = .2f;
    [SerializeField] float speedDamping = .5f;
    void Start()
    {
        InitCharacterAnimation();
    }

    void Update()
    {
        
    }
    void InitCharacterAnimation()
    {
        /*charController = GetComponent<MainCharacterController>();
        if (charController == null) Debug.LogError("MainCharacterController is missing!");*/
        charAnimator = GetComponent<Animator>();
        if (charAnimator == null) Debug.LogError("Animator is missing!");
    }

    public void UpdateForwardParam(float _value) => charAnimator.SetFloat(AnimParams.ForwardAxis, _value, fwdDamping, Time.deltaTime);
    public void UpdateRightParam(float _value) => charAnimator.SetFloat(AnimParams.RightAxis, _value, rgtDamping, Time.deltaTime);
    public void UpdateSpeedParam(float _value) => charAnimator.SetFloat(AnimParams.AnimSpeed, Mathf.Abs(_value), speedDamping, Time.deltaTime);
    public void UpdateJumpParam(bool _value) => charAnimator.SetBool(AnimParams.JumpBool, _value);
    public void UpdateSprintParam(bool _value) => charAnimator.SetBool(AnimParams.SprintBool, _value);
    public void UpdateCrouchParam(bool _value) => charAnimator.SetBool(AnimParams.CrouchBool, _value);
    public void UpdateLeftAttackParam(bool _value) => charAnimator.SetBool(AnimParams.LeftAttackBool, _value);
    public void UpdateRightAttackParam(bool _value) => charAnimator.SetBool(AnimParams.RightAttackBool, _value);
}
