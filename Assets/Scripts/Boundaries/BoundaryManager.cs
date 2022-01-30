using System;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    public event Action<Boundary> OnTrigger;

    [SerializeField] private BoundaryController[] _boundaries;

    private void Start()
    {
        foreach (var boundary in _boundaries)
            boundary.OnTrigger += Trigger;
    }

    private void Trigger(Boundary boundary) => OnTrigger?.Invoke(boundary);
}

public enum Boundary
{
    Top,
    Bottom,
    Left,
    Right
}
