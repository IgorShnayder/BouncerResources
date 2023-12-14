using UnityEngine;
using TMPro;

public class PlayerMovesCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerMovesCounter;
    private PlayerMovementController _playerMovementController;
    
    public void Initialize(PlayerMovementController playerMovementController)
    {
        _playerMovementController = playerMovementController;
        
        _playerMovementController.MakeMove += UpdateMoveCounter;
    }
    
    private void OnDestroy()
    {
        _playerMovementController.MakeMove -= UpdateMoveCounter;
    }
    
    private void UpdateMoveCounter(int moves)
    {
        _playerMovesCounter.text = moves.ToString();
    }
}
