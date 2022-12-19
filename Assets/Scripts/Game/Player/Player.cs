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
        transform.Translate(_movement * Time.deltaTime * _speed);
    }

    #endregion
}
