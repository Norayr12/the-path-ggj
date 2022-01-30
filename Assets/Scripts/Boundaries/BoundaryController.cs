using System;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    public event Action<Boundary> OnTrigger;

    [SerializeField] private Boundary _boundary;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            OnTrigger?.Invoke(_boundary);
    }
}