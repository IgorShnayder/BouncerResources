using UnityEngine;

public class Player : MonoBehaviour
{
    public Color MaterialColor { get; private set; }
    
    [SerializeField] private Renderer _renderer;
    
    private Material _coloringMaterial;
    
    private void Awake()
    {
        _coloringMaterial = ColoringHelper.FindMaterialForColoring(_renderer);
    }

    public void SetColor(Color color)
    {
        _coloringMaterial.color = color;
        MaterialColor = color;
    }
}

