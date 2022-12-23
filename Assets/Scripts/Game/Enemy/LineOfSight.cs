using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField]
    private Enemy _enemy;

    private bool _isAiming = true;

    // Update is called once per frame
    void Update()
    {
        RaycastHit _hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out _hitInfo, 10))
        {
            if (_hitInfo.transform.tag == "Player")
            {
                _enemy.SetTarget(_hitInfo.transform);
                _enemy.PlayerSpotted(true);
            }
        }
    }

    public void SetAim(bool aim)
    {
        _isAiming = aim;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10);
    }
}
