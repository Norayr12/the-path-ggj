using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BodyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private bool _isPrespawned;
    [SerializeField] private Vector2 _externalForce;
    [SerializeField] private float _externalForceRandomnessCap;
    [SerializeField] [Range(0, 180)] private float _torque;
    [SerializeField] private float _destroyTimer;
    
    public void Initialize()
    {
        _rb.AddForce(new Vector2(Random.Range(_externalForce.x - _externalForceRandomnessCap, _externalForce.x + _externalForceRandomnessCap),
                                Random.Range(_externalForce.y - _externalForceRandomnessCap, _externalForce.y + _externalForceRandomnessCap)));
        _rb.AddTorque(Random.Range(-_torque, _torque));

        SceneManager.Instance.StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_destroyTimer);
        GameObject.Destroy(gameObject);
    }

    private void Start()
    {
        if(_isPrespawned)
            Initialize();
    }
}
