using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    [Header("Control settings")]
    [SerializeField] private float _speed;

    private Animator _animator;
    private SpriteRenderer _rightWalkSprite;

    private const string JUMP = "Jump", WALK_UP = "WalkUp", WALK_DOWN = "WalkDown", WALK_RIGHT = "WalkRight";
    private bool _isWalkUp, _isWalkDown, _isWalkRight, _isWalkLeft;
    private bool _isStopped = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rightWalkSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_joystick.Vertical) > 0.3f || Mathf.Abs(_joystick.Horizontal) > 0.3f)
        {
            var v = transform.position;
            transform.position = new Vector2(v.x + (_joystick.Horizontal > 0.3f || _joystick.Horizontal < -0.3f ? Mathf.Sign(_joystick.Horizontal) : 0) * _speed / 100f,
                                                    v.y + (_joystick.Vertical > 0.3f || _joystick.Vertical < -0.3f ? Mathf.Sign(_joystick.Vertical) : 0) * _speed / 100f);

            _isStopped = false;
            _animator.SetBool("IsStopped", false);
            if ((_joystick.Horizontal > 0f && _joystick.Vertical < 0.3f && _joystick.Vertical > -0.3f) && !_isWalkRight)
            {
                _rightWalkSprite.flipX = true;
                print("WALKRIGHT");
                _animator.SetBool(WALK_RIGHT, true);
                _isWalkRight = true;
                _isWalkDown = false;
                _isWalkLeft = false;
                _isWalkUp = false;
                return;
            }
            else if ((_joystick.Horizontal < 0 && _joystick.Vertical < 0.3f && _joystick.Vertical > -0.3f) && !_isWalkLeft)
            {
                _rightWalkSprite.flipX = false;
                print("WALKRIGHT");
                _animator.SetBool(WALK_RIGHT, true);
                _isWalkLeft = true;
                _isWalkDown = false;
                _isWalkRight = false;
                _isWalkUp = false;
                return;
            }
            else if ((_joystick.Vertical < -0.3f) && !_isWalkDown)
            {
                print("WALKDOWN");
                _animator.SetBool(WALK_DOWN, true);
                _isWalkDown = true;
                _isWalkLeft = false;
                _isWalkRight = false;
                _isWalkUp = false;
                return;
            }
            else if (_joystick.Vertical > 0.3f && !_isWalkUp)
            {
                print("WALKUP");
                _animator.SetBool(WALK_UP, true);
                _isWalkUp = true;
                _isWalkLeft = false;
                _isWalkRight = false;
                _isWalkDown = false;
                return;
            }

        }
        else if (!_isStopped)
        {
            _isStopped = true;
            _isWalkLeft = false;
            _isWalkRight = false;
            _isWalkUp = false;
            _isWalkDown = false;
            _animator.SetBool("IsStopped", true);
        }
    }

}