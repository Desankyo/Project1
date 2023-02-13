using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeSpawn : MonoBehaviour
{
    private Animator pAnimator;

    public float timer = 5;
    public int health = 3;
    int animtrigger = 0;
    int counter = 1;
    float rando;

    public int aliveCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        pAnimator = GetComponent<Animator>();
        rando = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && animtrigger == 0)
        {
            pAnimator.ResetTrigger("Close");
            pAnimator.SetTrigger("Open");
            animtrigger = 1;
            timer = 5;
            counter = 0;
        }
        if (timer <= 0 && animtrigger == 1)
        {
            pAnimator.ResetTrigger("Open");
            pAnimator.SetTrigger("Close");
            animtrigger = 0;
            timer = 5;
        }
        if (health == 0){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            if(animtrigger == 1){
                health--;
            }
        }
        if(collision.gameObject.tag == "Sword")
        {
            if(animtrigger == 1){
                health--;
            }
        }
    }
}
