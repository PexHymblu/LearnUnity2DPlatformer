using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMoveRange : MonoBehaviour {

    private Rigidbody2D enemyBody;
    private SpriteRenderer enemySprite;
    private Vector2 velocity;
    private Vector2 startPosition;
    public float range;
	
	void Start () {
        enemyBody = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        startPosition = enemyBody.position;
        velocity.x = 1;
	}
		
	void FixedUpdate () {
        if (enemyBody.position.x <= startPosition.x)
        {
            velocity.x = 1;
            enemySprite.flipX = true;
        }
        if (enemyBody.position.x >= startPosition.x + range)
        {
            velocity.x = -1;
            enemySprite.flipX = false;
        }
        enemyBody.MovePosition(enemyBody.position + velocity * Time.deltaTime);
    }
}
