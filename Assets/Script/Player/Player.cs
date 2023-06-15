using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _height = 5;
    [Header("Reference")]
    [SerializeField] private Camera _hudCamera;
    [SerializeField] private Transform _target;
    [SerializeField] private GameController _controller;

    private void Update()
    {
        _target.position = (Vector2)_hudCamera.ScreenToWorldPoint(Input.mousePosition);
    }

}
