using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Destroyed;
    public Color Color { get; private set; }

    [SerializeField] private Renderer _renderer;
    private Material _coloringMaterial;

    public void Initialize(Color color)
    {
        _coloringMaterial = ColoringHelper.FindMaterialForColoring(_renderer);
        _coloringMaterial.color = color;
        Color = color;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;

        if (player.MaterialColor != Color) return;
        
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
