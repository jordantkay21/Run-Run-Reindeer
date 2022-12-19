using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables Set By Game Inputs
    private Vector2 _movement;

    [SerializeField]
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    #region Movements
    public void SetMovement(Vector2 move)
    {
        _movement = move;
    }

    private void Movement()
    {
        PlayerBounds();

        transform.Translate(new Vector3 (_movement.x, _movement.y, 0) * Time.deltaTime * _speed);    
    }

    private void PlayerBounds()
    {
        if (transform.position.x >= 11.25f)
        {
            transform.position = new Vector3(11.25f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.0f)
        {
            transform.position = new Vector3(-11.0f, transform.position.y, 0);
        }

        if (transform.position.y >= 9.5f)
        {
            transform.position = new Vector3(transform.position.x, 9.5f, 0);
        }
        else if (transform.position.y <= -3)
        {
            transform.position = new Vector3(transform.position.x, -3, 0);
        }
    }

    #endregion
}
