using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _speed = 3;
    [SerializeField] private Rigidbody2D _rigidbody;
    [Inject] private PlayerHealth _playerHealth;
    private Vector3 _movement;



    private void Awake()
    {
        if(_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movement * _speed;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _movement = new Vector3(horizontal, vertical, 0).normalized;
        Debug.Log(_playerHealth);
    }

}
