using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private Enemy _enemy;

    private bool _isAiming = true;

    private void Start()
    {
            _enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 10))
        {
            if (hitInfo.transform.tag == "Player")
            {
                _enemy.SetTarget(hitInfo.transform);
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
