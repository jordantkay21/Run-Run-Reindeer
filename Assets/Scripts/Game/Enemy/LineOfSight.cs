using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField]
    private Enemy _enemy;

    private bool _isAiming = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit _hitInfo;
        if (_isAiming == true)
        {
            if (Physics.Raycast(transform.position, transform.forward, out _hitInfo, 10))
            {
                if (_hitInfo.transform.tag == "Player")
                {
                    _enemy.SetAim(false);
                    _isAiming = false;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10);
    }
}
