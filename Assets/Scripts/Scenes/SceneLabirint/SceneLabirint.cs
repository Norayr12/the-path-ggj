using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SceneLabirint : SceneBase
{
    [SerializeField] private LabirintTriggerHandler _groundTriggerHandler;
    [SerializeField] private float _rebornTime;
    [SerializeField] private Transform _rebornStartPos;
    [SerializeField] private Image _fallUIAnimation;

    [Header("Bottom reborn bound")]
    [SerializeField] private Transform _bottomBoundPos;
    [SerializeField] private float _bottomOffset;

    private bool _isReborning;

    private void Start()
    {
        _groundTriggerHandler.OnFall += Respawn;
    }

    public override void Initialize()
    {
        base.Initialize();
        _player.transform.position = _playerStartPosition.position;
        _player.transform.SetParent(_playerStartPosition);
    }

    public override void Finalize()
    {
        base.Finalize();
        if (!SceneManager.Instance.CheckIfLast())
            SceneManager.Instance.NextLevel();
    }

    protected override void CheckBoundaryCollision(Boundary boundary)
    {
        base.CheckBoundaryCollision(boundary);
    }

    private void Respawn()
    {
        if(!_isReborning)
            StartCoroutine(PlayerReborn());
    }

        private IEnumerator PlayerReborn()
    {
        _isReborning = true;
        float t = 0;

        while (t < 1)
        {
            var start = _playerStartPosition.position;
            var dest = start;
            start.y += 3;

            if (t > 0.4f)
            {
                _player.transform.position = Vector3.Lerp(start, dest, t);
            }

            _fallUIAnimation.color = new Color(_fallUIAnimation.color.r, _fallUIAnimation.color.g, _fallUIAnimation.color.b, Mathf.Sin(Mathf.PI * t));
            t += Time.deltaTime;
            yield return null;
        }

        _isReborning = false;
        /*
        _isReborning = true;
        Vector3 fallingStartPos = _player.transform.position;
        Vector3 fallingEndPos = _bottomBoundPos.position;
        fallingEndPos.y -= _bottomOffset;

        float t = 0;
        while (t < 1)
        {
            _player.transform.position = new Vector3(fallingStartPos.x, Mathf.Lerp(fallingStartPos.y, fallingEndPos.y, t), transform.position.z);
            t += 0.02f;
            yield return new WaitForFixedUpdate();
        }

        _player.transform.position = _rebornStartPos.position;

        t = 0;

        while (t < 1)
        {
            float x = Mathf.Lerp(_rebornStartPos.position.x, _playerStartPosition.position.x, t);
            float y = Mathf.Lerp(_rebornStartPos.position.y, _playerStartPosition.position.y, t);
            _player.transform.position = new Vector3(x, y, _player.transform.position.z);
            t += 0.02f;
            yield return new WaitForFixedUpdate();
        }

        //_groundTriggerHandler.EntityIsOnGround = true;
        _isReborning = false;
        */
    }
}
