using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private KnifeHitbox _knifeHitbox;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _knifeHitbox.Activate();
    }
}
