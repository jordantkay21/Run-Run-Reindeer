using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Variables
    [Header("Enemies to Spawn")]
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _enemyPrefab;

    [Header("Miscellaneous")]
    [SerializeField]
    private float _enemySpawnTime;
    [SerializeField]
    private bool _stopSpawning = true;

    #endregion

    private void Start()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-11, 11.25f), 11.0f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_enemySpawnTime);
        }
    }

}
