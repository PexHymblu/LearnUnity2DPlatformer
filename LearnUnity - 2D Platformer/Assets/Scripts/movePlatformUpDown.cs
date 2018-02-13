using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatformUpDown : MonoBehaviour {

    private Rigidbody2D _rigidbody;
    private Vector2 velocity;
    private Vector2 startPosition;
    public float range;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        startPosition = _rigidbody.position;
        velocity.y = 1;
    }

    void FixedUpdate()
    {
        if (_rigidbody.position.y <= startPosition.y)
        {
            velocity.y = 1;
        }
        if (_rigidbody.position.y >= startPosition.y + range)
        {
            velocity.y = -1;
        }
        _rigidbody.MovePosition(_rigidbody.position + velocity * Time.deltaTime);
    }
}
