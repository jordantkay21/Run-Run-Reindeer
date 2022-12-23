using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    private Player _player;
    
    [SerializeField]
    private float _speed = .5f;


    public void SetPlayerPos(Transform target)
    {
        transform.LookAt(target, Vector3.up);
    }
    // Update is called once per frame
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {
        Movement();
        DestroyDart();
    }
    private void Movement()
    {
        //transform.position = Vector3.MoveTowards(transform.position, _playerPos, Time.deltaTime * _speed);

        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        //transform.LookAt(_playerPos);
    }

    private void DestroyDart()
    {
        if (transform.position.x > 13 || transform.position.x < -13)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y > 11 || transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            _player.Damage();

        }
    }
}
