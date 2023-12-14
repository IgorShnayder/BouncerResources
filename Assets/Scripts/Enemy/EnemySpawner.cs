using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event Action<Color> EnemyDestroyed;
    public Dictionary<Color,int> EnemyCounts { get; private set;}
    
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemiesCount = 6;
    [SerializeField] private int _spawnArea = 8;
    [SerializeField] private float _enemyAroundRadius = 1;

    private ColorsController _colorController;
   
    public void Initialize(ColorsController colorController)
    {
        _colorController = colorController;
        EnemyCounts = new Dictionary<Color, int>();
        
        foreach (var color in _colorController.Colors)
        {
            EnemyCounts.Add(color, 0);
        }

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        for (var i = 0; i < _enemiesCount; i++)
        {
            var position = PositionGenerator.GetRandomPosition(_spawnArea);

            while (position.HasCollisions(_enemyAroundRadius))
            {
                position = PositionGenerator.GetRandomPosition(_spawnArea);
            }

            var enemy = Instantiate(_enemyPrefab);
            enemy.transform.position = position;
            enemy.Initialize(_colorController.GetRandomColor());
            
            enemy.Destroyed += OnEnemyDestroyed;
            
            EnemyCounts[enemy.Color]++;
        }
    }
    
    private void OnEnemyDestroyed(Enemy enemy)
    {
        EnemyCounts[enemy.Color]--;
        enemy.Destroyed -= OnEnemyDestroyed;
        EnemyDestroyed?.Invoke(enemy.Color);
    }
}
