using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    [SerializeField] private float _regress = 2f;
    [Header("SceneReference")]
    [SerializeField] private Player _player;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GunHolder _gunHoldder;
    [SerializeField] private CameraHolder _camera;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = _player.transform.position;
    }

    public void Reset()
    {
        _player.Reset();
        _wallet.SetRegress(_regress);
        _gunHoldder.Reset();
        _player.transform.position = _startPosition;
        _camera.transform.position = _startPosition;
    }


}
