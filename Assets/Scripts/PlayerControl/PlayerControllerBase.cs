using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerControllerBase : MonoBehaviour
{
    [SerializeField] protected GameObject _character;
    [SerializeField] protected Joystick _joystick;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected float _speed;

    protected abstract void Update();
}
