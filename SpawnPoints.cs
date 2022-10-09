using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _objectCount;

    private Spawner[] _spawnPositions;
    private int _currentIndex;

    private void OnEnable()
    {
        _spawnPositions = GetComponentsInChildren<Spawner>();
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (_objectCount != 0)
        {
            var waitForSeconds = new WaitForSecondsRealtime(_spawnDelay);
            yield return waitForSeconds;
            Instantiate(_enemy, _spawnPositions[_currentIndex].transform.position, Quaternion.identity);
            _currentIndex++;
            _objectCount--;

            if (_currentIndex >= _spawnPositions.Length)
            {
                _currentIndex = 0;
            }
        }
    }
}
