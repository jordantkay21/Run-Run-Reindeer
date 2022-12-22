using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField]
    private float _speed = .5f;

    public void SetPlayerPos(Transform target)
    {
        transform.LookAt(target, Vector3.up);
    }
    // Update is called once per frame
    private void Start()
    {
        //transform.LookAt(_playerPos);
    }
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        //transform.position = Vector3.MoveTowards(transform.position, _playerPos, Time.deltaTime * _speed);

        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        //transform.LookAt(_playerPos);
    }
}
