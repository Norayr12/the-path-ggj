using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSimulator : MonoBehaviour
{
    [SerializeField] private Vector2 _buoyancy;
    [SerializeField] private Vector2 _speedCap;

    private Rigidbody2D _rb;

    private bool isStoppingToRise;
    
    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    private void Update() => _rb.velocity = new Vector2(Mathf.Min(_rb.velocity.x + _buoyancy.x * Time.deltaTime, _speedCap.x), Mathf.Min(_rb.velocity.y + _buoyancy.y * Time.deltaTime, _speedCap.y));
}
