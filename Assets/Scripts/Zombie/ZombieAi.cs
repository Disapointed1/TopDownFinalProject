using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZombieAi : MonoBehaviour
{
   [Inject] private PlayerContext _playerContext;
   [SerializeField] private float _speed;
   [SerializeField] private LayerMask _wallLayerMask;

   private RaycastHit2D _raycastHit;
   private Vector2 _avoidDirection;
   private bool _isAvoiding;


   private Rigidbody2D _zombieRigidbody;
   private Vector3 _movement;

   private void Awake()
   {
      _zombieRigidbody = GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate()
   {

      Vector2 directToPlayer = (_playerContext.PlayerTransform.position - transform.position).normalized;

      if(Physics2D.Raycast(transform.position, directToPlayer, 1.5f, _wallLayerMask).collider == null)
            _isAvoiding = false;

      if (_isAvoiding)
         _movement = _avoidDirection;
      else
         _movement = directToPlayer;

      _raycastHit  = Physics2D.Raycast(transform.position, _movement, 1.5f, _wallLayerMask);

      if (_raycastHit.collider != null)
      {
         for (int angle = 15; angle <= 90; angle += 15)
         {
            Vector2 right = Quaternion.Euler(0, 0, angle) * _movement;

            _raycastHit = Physics2D.Raycast(transform.position, right, 1.5f, _wallLayerMask);
            if (_raycastHit.collider == null)
            {
               _movement = right;
               _avoidDirection = right;
               _isAvoiding = true;
               break;
            }

            Vector2 left = Quaternion.Euler(0, 0, -angle) * _movement;

            _raycastHit = Physics2D.Raycast(transform.position, left, 1.5f, _wallLayerMask);
            if (_raycastHit.collider == null)
            {
               _movement = left;
               _avoidDirection = left;
               _isAvoiding = true;
               break;
            }
         }
      }

      _zombieRigidbody.velocity = _movement * _speed;
   }
}
