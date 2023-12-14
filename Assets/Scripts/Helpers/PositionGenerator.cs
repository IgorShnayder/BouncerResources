using UnityEngine;

public class PositionGenerator : MonoBehaviour
{
    public static Vector3 GetRandomPosition(float spawnArea)
    {
        var randomPosition = Random.insideUnitCircle * spawnArea;
        return new Vector3(randomPosition.x, 0, randomPosition.y);
    }
}
