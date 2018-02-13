using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour {
        
    private Rigidbody2D _rigidbody;
    private Vector2 velocity;
    private Vector2 startPosition;
    public float range;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();        
        startPosition = _rigidbody.position;
        velocity.x = 1;
    }
	
	void FixedUpdate () {        
        if (_rigidbody.position.x <= startPosition.x)
        {
            velocity.x = 1;            
        }
        if (_rigidbody.position.x >= startPosition.x + range)
        {
            velocity.x = -1;
        }
        _rigidbody.MovePosition(_rigidbody.position + velocity * Time.deltaTime);
    }
}
