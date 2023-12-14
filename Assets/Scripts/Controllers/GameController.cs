using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private ColorsController _colorController;
    [SerializeField] private ColorSetter _colorSetter;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private PlayerMovementController _playerMovementController;
    [SerializeField] private EnemyCounters _uiEnemyCounters;
    [SerializeField] private PlayerMovesCounter _uiPlayerMovesCounter;
    
    
    private void Awake()
    {
        _colorSetter.Initialize(_colorController);
        _enemySpawner.Initialize(_colorController);
        _uiEnemyCounters.Initialize(_colorController, _enemySpawner);
        _uiPlayerMovesCounter.Initialize(_playerMovementController);
    }
}
