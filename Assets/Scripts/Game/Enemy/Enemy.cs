using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Associated Scripts")]
    [SerializeField]
    private Player _player;
    [SerializeField]
    private LineOfSight _lineOfSight;
    [SerializeField]
    private Dart _dart;

    [Header("Enemy Attributes")]
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private float _fireRate;
    [SerializeField]
    private float _canFire;
    [SerializeField]
    private Transform _playerTarget;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private bool _isAiming = true;
    [SerializeField]
    private GameObject _dartPrefab;
    [SerializeField]
    private bool _stopFire = false;

    //Values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;
    private Transform _target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Respawn();

        if (_isAiming == true)
        {
            Aim();
        }
        else
        {
            FireDart();
        }
    }

    #region Movements

    private void Movement()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);

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

    public void SetAim(bool aim)
    {
        _isAiming = aim; ;
    }

    #endregion

    #region Firing
    private void FireDart()
    {
        StartCoroutine(FireDartRoutine());
        new WaitForSeconds(1f);
        if (Time.time > _canFire && _stopFire == false)
        {
            _fireRate = .2f;
            _canFire = Time.time + _fireRate;
            GameObject dart = Instantiate(_dartPrefab, transform.position, Quaternion.identity);
            dart.GetComponent<Dart>().SetPlayerPos(_target);
        }
    }

    public void SetTarget(Transform pos)
    {
        _target = pos;
    }

    IEnumerator FireDartRoutine()
    {
        yield return new WaitForEndOfFrame();
        while (_isAiming == false)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(1f);
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            _lineOfSight.SetAim(true);
            _isAiming = true;
        }
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
