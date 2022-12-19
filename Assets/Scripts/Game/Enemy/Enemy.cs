using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Respawn();
    }

    #region Movements

    private void Movement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

    }

    private void Respawn()
    {
        if(transform.position.y <= -4.0f)
        {
            transform.position = new Vector3(Random.Range(-11,11.25f), 11.0f, 0);
        }
    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
