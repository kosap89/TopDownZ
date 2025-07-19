using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Enemy> _enemyPrefabs;
    [SerializeField] float _spawnCooldown;
    [SerializeField] float _spawnCooldownReductionMultiplier;
    float _currentCooldown;

    [SerializeField] Tilemap _groundTiles;
    List<Vector3> _spawnPositions = new();

    void Start()
    {
        SetEnemySpawnPositions();
        InvokeRepeating(nameof(HandleGameDifficultyIncrease), 1f, 1f);
    }

    void HandleGameDifficultyIncrease()
    {
        _spawnCooldown *= _spawnCooldownReductionMultiplier;
    }

    void SetEnemySpawnPositions()
    {
        foreach (Vector3Int position in _groundTiles.cellBounds.allPositionsWithin)
        {
            if (_groundTiles.HasTile(position))
            {
                _spawnPositions.Add(_groundTiles.GetCellCenterWorld(position));
            }
        }
    }

    void Update()
    {
        HandleEnemySpawning();
    }

    void HandleEnemySpawning()
    {
        _currentCooldown -= Time.deltaTime;

        if (_currentCooldown > Time.time)
            return;

        _currentCooldown = Time.time + _spawnCooldown;
        SpawnEnemyToRandomLocation();
    }


    Vector3 GetRandomPosition()
    {
        return _spawnPositions[Random.Range(0, _spawnPositions.Count)];
    }

    void SpawnEnemyToRandomLocation()
    {
        Vector3 spawnPosition = GetRandomPosition();

        // Randomly select an enemy prefab from the list
        Enemy randomEnemy = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)];

        // Spawn it
        Instantiate(randomEnemy, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        if (_spawnPositions == null)
            return;

        Gizmos.color = Color.red;
        foreach (var pos in _spawnPositions)
        {
            Gizmos.DrawSphere(pos, 0.2f);
        }
    }




}