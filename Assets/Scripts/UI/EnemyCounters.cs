using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounters : MonoBehaviour
{
    [SerializeField] private List<RawImage> _enemyPictures;
    [SerializeField] private List<TextMeshProUGUI> _enemyCounters;
    
    private ColorsController _colorController;
    private EnemySpawner _enemySpawner;
    
    public void Initialize(ColorsController colorController, EnemySpawner enemySpawner)
    {
        _colorController = colorController;
        _enemySpawner = enemySpawner;

        ColoringEnemyIcons();
        FillCounters();
        
        _enemySpawner.EnemyDestroyed += UpdateCounters;
    }
    
    private void OnDestroy()
    {
        _enemySpawner.EnemyDestroyed -= UpdateCounters;
    }

    private void ColoringEnemyIcons()
    {
        for (int i = 0; i < _colorController.Colors.Count; i++)
        {
            _enemyPictures[i].color = _colorController.Colors[i];
        }
    }

    private void FillCounters()
    {
        for (var i = 0; i < _enemyCounters.Count; i++)
        {
            var color = _colorController.Colors[i];
            var count = _enemySpawner.EnemyCounts[color].ToString();
            _enemyCounters[i].text = count;
        }
    }

    private void UpdateCounters(Color color)
    {
        var index = _colorController.Colors.IndexOf(color);
        _enemyCounters[index].text = _enemySpawner.EnemyCounts[color].ToString();
    }
}
