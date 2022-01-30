using UnityEngine;

public class SceneWhiteIntro : SceneBase
{

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
        else
            SceneManager.Instance.StartEndScene();
    }

    protected override void CheckBoundaryCollision(Boundary boundary)
    {
        base.CheckBoundaryCollision(boundary);
    }
}
