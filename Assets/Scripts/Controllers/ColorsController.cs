using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ColorsController 
{
    public List<Color> Colors => _colors;
    
    [SerializeField] private List<Color> _colors;
    
    public Color GetRandomColor()
    {
        var randomIndex =  Random.Range(0, _colors.Count);
        var randomColor = _colors[randomIndex];
        return randomColor;
    }
}
