using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSwim : PlayerControllerBase
{    
    [SerializeField] private Rigidbody2D _characterRb;

    private const float TOP_LEFT_ANGLE = 0.42f, BOTTOM_LEFT_ANGLE = 0.9f;


    private bool _isSwimming;
    private bool _isIdle = true;

    private void CheckOrientation()
    {
        float angle = _joystick.Vertical > 0 ? TOP_LEFT_ANGLE : BOTTOM_LEFT_ANGLE;

        _character.transform.rotation = new Quaternion(_character.transform.rotation.x, _character.transform.rotation.y, angle * -Mathf.Sign(_joystick.Horizontal), _character.transform.rotation.w);
    }
    
    protected override void Update()
    {
        if (Mathf.Abs(_joystick.Vertical) > 0.3f || Mathf.Abs(_joystick.Horizontal) > 0.3)
        {
            var v = _character.transform.position;

            _character.transform.position = new Vector2(v.x + (_joystick.Horizontal > 0.3f || _joystick.Horizontal < -0.3f ? Mathf.Sign(_joystick.Horizontal) : 0) * _speed * Time.deltaTime,
                                                    v.y + (_joystick.Vertical > 0.3f || _joystick.Vertical < -0.3f ? Mathf.Sign(_joystick.Vertical) : 0) * _speed * Time.deltaTime);

            _characterRb.velocity = new Vector2(_characterRb.velocity.x / 1.2f, _characterRb.velocity.y / 1.2f);
            
            CheckOrientation();

            if (!_isSwimming)
            {
                _animator.SetBool("Swim", true);
                _isSwimming = true;
            }

            _isIdle = false;
        }
        else
        {
            if (!_isIdle)
            {
                _animator.SetBool("Idle", true);
                _isIdle = true;
            }

            _isSwimming = false;
        }
    }
}
