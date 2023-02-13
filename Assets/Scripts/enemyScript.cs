using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public PlayerMover playerHealth;
    public PlayerMover enemyKnockback;
    public PlayerMover fromRight;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            enemyKnockback.knockbackCount = 0.6f;
            if(collision.transform.position.x < transform.position.x)
            {
                fromRight.knockFromRight = true;
            }
            else
            {
                fromRight.knockFromRight = false;
            }
        }
    }
}
