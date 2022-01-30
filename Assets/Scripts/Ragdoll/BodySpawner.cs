using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BodySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPrefab;
    [SerializeField] private Transform _spawnPos;
    
    [SerializeField] private float _spawnTimeInterval;
    [SerializeField] private float _spawnPosInterval;
    [SerializeField] private bool _randomizeY;

    private Coroutine _spawningRoutine;
    
    private IEnumerator BeginSpawning()
    {
        while (true)
        {
            Debug.Log("fdaas");
            Instantiate(_bodyPrefab, new Vector3(_spawnPos.position.x + Random.Range(-_spawnPosInterval, _spawnPosInterval),
                                                        _spawnPos.position.y + Random.Range(-_spawnPosInterval, _spawnPosInterval) * (_randomizeY ? 1 : 0), 
                                                        _spawnPos.position.z), Quaternion.identity, _spawnPos).GetComponent<BodyController>().Initialize();
            
            yield return new WaitForSeconds(_spawnTimeInterval);
        }
    }

    public void Play() => _spawningRoutine = SceneManager.Instance.StartCoroutine(BeginSpawning());
    
    public void Stop()
    {
        if(_spawningRoutine != null)
            SceneManager.Instance.StopCoroutine(_spawningRoutine);
    }
}
