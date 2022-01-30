using System;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public event Action OnFall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hole"))
            OnFall?.Invoke();
    }

    private void Update()
    {
        transform.localPosition = new Vector3(0, -1, 0);
    }

}
