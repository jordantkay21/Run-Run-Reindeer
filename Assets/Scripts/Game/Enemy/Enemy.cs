using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Associated Scripts")]
    private Player _player;
    private Transform _playerTarget;
    private LineOfSight _lineOfSight;


    [Header("Enemy Attributes")]
    [SerializeField]
    private float _reloadTime = 2;
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private bool _playerSpotted = false;
    [SerializeField]
    private GameObject _dartPrefab;
    [SerializeField]
    private bool _stopFire = false;
    [SerializeField]
    private float _fireRate;

    //Values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;
    private Transform _target;
    private float _canfire;


    // Start is called before the first frame update
    void Start()
    {
            _player = GameObject.Find("Player").GetComponent<Player>();
            _playerTarget = GameObject.Find("Player").GetComponent<Transform>();
            _lineOfSight = GetComponentInChildren<LineOfSight>();  
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Respawn();
        Aim();
        if (_playerSpotted == true)
        {
            FireDart();
        }
    }

    #region Movements

    private void Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.World);
    }

    private void Respawn()
    {
        if(transform.position.y <= -4.0f)
        {
            transform.position = new Vector3(Random.Range(-11,11.25f), 11.0f, 0);
        }
    }

    #endregion

    #region Aim
    private void Aim()
    {

        //find the vector pointing from enemy position to the player's position
        _direction = (_playerTarget.position - transform.position).normalized;

        //create the rotation the enemy needs to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);


        //rotate the enemy over time to speed until enemy is in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * _rotationSpeed);
    
    }

    public void PlayerSpotted(bool playerSpotted)
    {
        _playerSpotted = playerSpotted;
    }
    #endregion

    #region Firing
    private void FireDart()
    {
        if (Time.time > _canfire)
        {
            _canfire = Time.time + _fireRate;
            GameObject dart = Instantiate(_dartPrefab, transform.position, Quaternion.identity);
            dart.GetComponent<Dart>().SetPlayerPos(_target);
        }
        _playerSpotted = false; 
    }

    public void SetTarget(Transform pos)
    {
        _target = pos;
    }


    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
            _player.Damage();
        }
    }
}
