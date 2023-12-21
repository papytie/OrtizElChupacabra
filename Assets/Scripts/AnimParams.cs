using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimParams
{
    public const string FORWARD_AXIS = "forward";
    public const string RIGHT_AXIS = "right";
    public const string ANIM_SPEED = "speed";
    public const string JUMP_TRIGGER = "jump";
    public const string SPRINT_BOOL = "sprint";
    public const string CROUCH_BOOL = "crouch";
    public const string LEFT_ATTACK_BOOL = "leftAttack";
    public const string RIGHT_ATTACK_BOOL = "rightAttack";

    public static readonly int ForwardAxis = Animator.StringToHash(FORWARD_AXIS);
    public static readonly int RightAxis = Animator.StringToHash(RIGHT_AXIS);
    public static readonly int AnimSpeed = Animator.StringToHash(ANIM_SPEED);
    public static readonly int JumpBool = Animator.StringToHash(JUMP_TRIGGER);
    public static readonly int SprintBool = Animator.StringToHash(SPRINT_BOOL);
    public static readonly int CrouchBool = Animator.StringToHash(CROUCH_BOOL);
    public static readonly int LeftAttackBool = Animator.StringToHash(LEFT_ATTACK_BOOL);
    public static readonly int RightAttackBool = Animator.StringToHash(RIGHT_ATTACK_BOOL);
}
