using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPowerupPrefab;
    [SerializeField]
    private GameObject _speedUpPowerupPrefab;    
    [SerializeField]
    private GameObject _shieldsPowerupPrefab;

    private bool _isSpawning = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
        StartCoroutine(SpawnSpeedupRoutine());
        StartCoroutine(SpawnShieldsRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // spawn game objects every 5 seconds
    // create a coroutine of type IEnumerator -- Yield events
    // while loop

    IEnumerator SpawnEnemyRoutine()
    {
        // while loop (infinite loop)
        while (_isSpawning)
        {
            float randomX = UnityEngine.Random.Range(-8f, 9f);
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(randomX, 8f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_isSpawning)
        {
            float randomX = UnityEngine.Random.Range(-8f, 9f);
            Vector3 posToSpawn = new Vector3(randomX, 7, 0);
            Instantiate(_tripleShotPowerupPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(UnityEngine.Random.Range(3, 8));
        }
    }
    
    IEnumerator SpawnShieldsRoutine()
    {
        while (_isSpawning)
        {
            float randomX = UnityEngine.Random.Range(-8f, 9f);
            Vector3 posToSpawn = new Vector3(randomX, 7, 0);
            Instantiate(_speedUpPowerupPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(UnityEngine.Random.Range(5, 10));
        }
    }    

    IEnumerator SpawnSpeedupRoutine()
    {
        while (_isSpawning)
        {
            float randomX = UnityEngine.Random.Range(-8f, 9f);
            Vector3 posToSpawn = new Vector3(randomX, 7, 0);
            Instantiate(_shieldsPowerupPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(UnityEngine.Random.Range(8, 20));
        }
    }

    public void OnPlayerDeath()
    {
        _isSpawning = false;
    }
}
