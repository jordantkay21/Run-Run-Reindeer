using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    //Variables Set By Game Inputs
    private Vector2 _movement;

    //Variables Set Wihtin the Inspector
    [SerializeField]
    private float _speed;

    //Variables Hard Coded
    [SerializeField]
    private int _lives = 3;
    private bool _wasHit = false;

    #endregion
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

    #region Health

    public void Damage()
    {
        if(_wasHit == false)
        {
            _wasHit = true;
            _lives--;
            StartCoroutine(HitVisual());
        }
    }

    IEnumerator HitVisual()
    {
        yield return new WaitForEndOfFrame();
        while (_wasHit == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.25f);

            _wasHit = false;
        }
    }

    #endregion
}
