using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordBehavior : MonoBehaviour
{
    public float Speed = 0.0f;
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject Player in otherObjects) {
            Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position += -transform.right * Time.deltaTime * Speed;
        if(timer < 0)
        {
            Destroy(gameObject);
        }

    }
}