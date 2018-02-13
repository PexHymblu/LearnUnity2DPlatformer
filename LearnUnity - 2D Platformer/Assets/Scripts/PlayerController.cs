using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public int playerHealth;
    public int playerMaxHealth;
    public int playerScore;
    public int playerBombCount;
    public int playerChickenCollected;
    public AudioSource playerJump;
    public AudioSource playerHurt;
    private Rigidbody2D playerBody;
    private Animator playerAnimator;
    private SpriteRenderer playerSprite;
	public float speed;                      // Скорость движения, а в дальнейшем ускорение
    public float maxSpeed;
    public GameObject Bullet;                      // Наш снаряд которым будем стрелять
	public GameObject StartBullet;                  // и точка, где он создаётся	
	public int jumpHeight;
    public int jumpHeightOnEnemyDestroy;

    void Awake()
    {
        playerMaxHealth = 100;
        playerHealth = 100;
    }

    void Start()
    {        
        playerScore = 0;
        playerBombCount = 3;
        playerChickenCollected = 0;
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

	void FixedUpdate()
	{
        checkHealth();
        float moveHorizontal = Input.GetAxis("Horizontal");
        playerBody.velocity = new Vector2(Mathf.Clamp(playerBody.velocity.x, maxSpeed * -1, maxSpeed), playerBody.velocity.y);
        playerAnimator.SetBool("Run", false);
        
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
            playerSprite.flipX = false;
            playerAnimator.SetBool("Run", true);
            playerBody.AddForce(Vector2.right * moveHorizontal * speed, ForceMode2D.Force);
		}

        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
            playerSprite.flipX = true;
            playerAnimator.SetBool("Run", true);            
            playerBody.AddForce(Vector2.left * moveHorizontal * speed * -1, ForceMode2D.Force);            
        }            

        if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            playerJump.Play();
			playerBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
		}




        // Если нажата кнопка 
        if (Input.GetButtonDown("Fire1"))
        {
            // Создаём Bullet в точке StartBullet
            Instantiate(Bullet, StartBullet.transform.position, StartBullet.transform.rotation);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {        
        if (col.gameObject.tag == "Enemy")
        {
            playerHealth = playerHealth - col.gameObject.GetComponent<enemyDamage>().damage;
            playerHurt.Play();
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "outOfMapCollision")
        {
            Die();
        }
        if (col.gameObject.tag == "Enemy")
        {
            playerScore = playerScore + 200;
            playerBody.AddForce(Vector2.up * jumpHeightOnEnemyDestroy, ForceMode2D.Impulse);
            Destroy(col.gameObject);            
        }
        if (col.gameObject.tag == "Chicken")
        {
            playerScore = playerScore + 500;
            playerChickenCollected = playerChickenCollected + 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "cherry")
        {
            playerScore = playerScore + 100;
            if (playerHealth + 20 >= playerMaxHealth)
            {
                playerHealth = playerMaxHealth;
            }
            else
            {
                playerHealth = playerHealth + 20;
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "diamond")
        {
            playerScore = playerScore + 300;
            playerBombCount = playerBombCount + 1;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "House" && playerChickenCollected == 3)
        {
            SceneManager.LoadScene("Win");
            Debug.Log("You Win");
        }
    }

    void Die()
    {
        //SceneManager.LoadScene("GameOver");
        Debug.Log("<color=red>Player Die</color>");
    }

    void checkHealth()
    {
        if(playerHealth <= 0)
        {
            Die();
        }
    }
}


