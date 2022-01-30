using System;
using UnityEngine;

public abstract class SceneBase : MonoBehaviour
{
    [SerializeField] protected GameObject _player;
    [SerializeField] protected Joystick _joystick;
    [SerializeField] protected Transform _playerStartPosition;
    [SerializeField] protected BoundaryManager _boundaryManager;
    [SerializeField] private Boundary _finishBoundary;    

    protected virtual void Awake()
    {
        _boundaryManager.OnTrigger += CheckBoundaryCollision;
    }

    public virtual void Initialize()
    {
        _joystick.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    public virtual void Finalize()
    {
        _joystick.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    protected virtual void CheckBoundaryCollision(Boundary boundary)
    {
        if (boundary == _finishBoundary)
            Finalize();
    }

}
