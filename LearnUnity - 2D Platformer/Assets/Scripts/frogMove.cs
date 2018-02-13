using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogMove : MonoBehaviour {

    private Rigidbody2D frogBody;
    private Animator frogAnimator;
    public int jumpHeight;
    public int jumpFrequncy;

	void Start () {
        frogBody = GetComponent<Rigidbody2D>();
        frogAnimator = GetComponent<Animator>();        
	}
		
	void FixedUpdate () {
		if (Time.time % jumpFrequncy == 0)
        {
            ChangeAnimation("Jump", true);
            frogBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        else
        {
            ChangeAnimation("Jump", false);
        }
	}

    void ChangeAnimation(string animation, bool state)
    {
        frogAnimator.SetBool(animation, state);
    }
}
