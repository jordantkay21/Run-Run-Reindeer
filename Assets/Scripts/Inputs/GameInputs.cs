using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{
    private GameInputActions _input;

    [SerializeField]
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _input = new GameInputActions();
        _input.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();
    }

    #region Player
    void PlayerInputs()
    {
        Vector2 move = _input.Player.Movement.ReadValue<Vector2>();
        _player.SetMovement(move);
    }

    #endregion
}
