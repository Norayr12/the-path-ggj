using UnityEngine;

public class SceneFalling : SceneBase
{
    [SerializeField] private BodySpawner _bodySpawner;

    public override void Initialize()
    {
        base.Initialize();
        
        _player.transform.position = _playerStartPosition.position;
        _player.transform.SetParent(_playerStartPosition);
        _bodySpawner.Play();
    }

    public override void Finalize()
    {
        base.Finalize();
        _bodySpawner.Stop();

        if (!SceneManager.Instance.CheckIfLast())
            SceneManager.Instance.NextLevel();
    }
}
