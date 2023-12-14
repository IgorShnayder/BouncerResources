using System.Linq;
using UnityEngine;

public abstract class ColoringHelper
{
    public static Material FindMaterialForColoring(Renderer renderer)
    {
        var coloringMaterials = renderer.materials;
        return coloringMaterials.First(material => material.name.Contains(GlobalConstants.COLORED_MATERIAL));
    }
}
