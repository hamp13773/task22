using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _spawnPositions;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _objectCount;

    private int _currentIndex;
    private void OnEnable()
    {
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
