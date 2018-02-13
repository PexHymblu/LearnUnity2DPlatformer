using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject BOOM;         // Объект, который спаунится после взрыва
    public int Damage;              // Урон, который мы нанесём
    public float Speed, LifeTime;   // Скорость и время жизни снаряда

    Vector3 Dir = new Vector3(0, 0, 0); // Направление полёта

    // Use this for initialization
    void Start () {
        // Говорим, что всегда летим по оси х
        Dir.x = Speed;
        // Говорим, что этот объект уничтожится через установленное время
        Destroy(gameObject, LifeTime);
    }

    void FixedUpdate()
    {
        // Движение снаряда
        transform.position += Dir;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Если объект с которым мы столкнулись имеет тэг Enemy
        if (collider.gameObject.tag == "Enemy")
        {
            // Делаем ссылку на объект противника            

            // Если ссылка не пуста
            
        }
    }
}
