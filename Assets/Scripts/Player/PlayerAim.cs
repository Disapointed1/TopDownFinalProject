using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Camera _camera;
    private void Start()
    {
        _camera =  Camera.main;
    }

    private void Update()
    {
        Vector3 mousePosition = (Vector2)_camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRadian = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x);
        float angleDegree = angleRadian * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angleDegree);
    }
}
