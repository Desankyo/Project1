using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    public PlayerMover playerHealth;
    public PlayerMover enemyKnockback;
    public PlayerMover fromRight;
    public fireballAttack fireballPrefab;
    public Transform fireballOffset;
    
    public int damage = 1;
    public float timer = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            Instantiate(fireballPrefab, fireballOffset.position, transform.rotation);
            timer = 5;
        }
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
