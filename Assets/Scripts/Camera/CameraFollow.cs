using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(_player.position.x, _player.position.y,transform.position.z);
        transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        
    }
}
