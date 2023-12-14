using System.Linq;
using UnityEngine;

public static class Extension 
{
    public static bool HasCollisions(this Vector3 position, float radius)
    {
        Physics.SyncTransforms();

        var colliders = Physics.OverlapSphere(position, radius);
        var collidersExceptGameBoard = colliders
            .Where(currentCollider => !currentCollider.CompareTag(GlobalConstants.GAME_BOARD_TAG)).ToList();

        return collidersExceptGameBoard.Any();
    }
}
