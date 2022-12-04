using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController player;
    private float _horizontalMovement;
    private float _verticalMovement;
    private float _speed = 10.0f;
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        player.Move(new Vector3(_horizontalMovement, 0, _verticalMovement) * _speed * Time.deltaTime);
    }
}
