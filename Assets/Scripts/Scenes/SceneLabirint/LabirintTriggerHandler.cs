using System;
using System.Collections;
using UnityEngine;

public class LabirintTriggerHandler : MonoBehaviour
{
    public event Action OnFall;

    private int _isOnGround = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            _isOnGround++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _isOnGround--;
            StartCoroutine(Respawn());
        }
    }

    private void Update()
    {
        transform.localPosition = new Vector3(0, -1, 0);
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.1f);
        if (_isOnGround <= 0)
            OnFall?.Invoke();
    }

}
