using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private Enemy _enemyPrefab;
    
    private Transform _target;

    private float _actualTime = 0f;
    
    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        _actualTime += Time.deltaTime;
        
        if (_actualTime >= _timeToSpawn)
        {
            _target = FindObjectOfType<AttackedPoint>().gameObject.transform;
            
            Enemy newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.SetTarget(_target);
            
            _actualTime = 0f;
        }
    }
}
