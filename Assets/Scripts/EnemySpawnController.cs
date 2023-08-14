using System;
using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private Enemy _enemyPrefab;

    private bool _timedOut;
    
    private Transform _target;
    
    private void Awake()
    {
        _target = FindObjectOfType<AttackedPoint>().gameObject.transform;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.SetTarget(_target);

            yield return new WaitForSeconds(_timeToSpawn);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(Spawn());
    }
}
