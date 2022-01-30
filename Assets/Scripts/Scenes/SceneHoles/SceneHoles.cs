using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneHoles : SceneBase
{
    [SerializeField] private TriggerHandler _footTriggerHandler;
    [SerializeField] private Image _fallUIAnimation;

    private bool _isRespawning = false;
    
    private void Start()
    {
        _footTriggerHandler.OnFall += Respawn;
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

    public void Respawn()
    {
        if (!_isRespawning)
        {
            StartCoroutine(BeginRespawn());
            _isRespawning = true;
        }
    }
    
    private IEnumerator BeginRespawn()
    {
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

        _isRespawning = false;
    }
}
