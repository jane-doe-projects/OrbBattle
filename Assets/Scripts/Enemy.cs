using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    public bool isStrongerEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        DestroyKnockedEnemies();
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        if (isStrongerEnemy)
        {
            enemyRb.AddForce(lookDirection * speed * 1.5f);
        } else
        {
            enemyRb.AddForce(lookDirection * speed);
        }
        
    }

    void DestroyKnockedEnemies()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
