using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public event Action<int> MakeMove;
    
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _movingForce = 250;

    private Vector3 _target;
    private Camera _camera;
    private int _movesCounter;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var mousePosition = Input.mousePosition;
        var ray = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            _playerRigidbody.velocity = Vector3.zero;
            
            MoveTowardsSelectedPoint(hitInfo);
        }
    }

    private void MoveTowardsSelectedPoint(RaycastHit hitInfo)
    {
        var moveDirection = (hitInfo.point - transform.position).normalized;
        _playerRigidbody.AddForce(new Vector3(moveDirection.x, 0, moveDirection.z) * _movingForce);
        MakeMove?.Invoke(++_movesCounter);
    }
}
