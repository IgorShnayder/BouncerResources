using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    [SerializeField] private int _spawnArea;
    [SerializeField] private int _radius;
    [SerializeField] private Renderer _renderer;

    private ColorsController _colorController;
    private Material _coloringMaterial;
    private Color _color;
    
    public void Initialize(ColorsController colorController)
    {
        _colorController = colorController;
        _coloringMaterial = ColoringHelper.FindMaterialForColoring(_renderer);
        _color = _coloringMaterial.color;
    }

    private void Start()
    {
        SetRandomPosition();
        SetColor();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent<Player>(out var player)) return;
        
        player.SetColor(_color);
        SetRandomPosition();
        SetColor();
    }

    private void SetRandomPosition()
    {
        var position = Vector3.zero;

        while (position.HasCollisions(_radius))
        {
            position = PositionGenerator.GetRandomPosition(_spawnArea);
        }

        transform.position = position;
    }

    private void SetColor()
    {
        var newColor = _colorController.GetRandomColor();

        _coloringMaterial.color = newColor;
        _color = newColor;
    }
}
