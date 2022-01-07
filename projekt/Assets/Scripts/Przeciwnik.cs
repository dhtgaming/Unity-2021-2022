using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przeciwnik : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //dystans do gracza
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroRange)
        {
            //sledz gracza
            ChasePlayer();
        }
        else
        {
            //przestan sledzic gracza
            StopChasingPlayer();
        }
    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //porusza w prawa
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1); //obraca sie
        }
        else if(transform.position.x > player.position.x)
        {
            //porusza w lewa
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1); //obraca sie
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("scianalewa"))
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
        }
        if (collision.gameObject.CompareTag("scianaprawa"))
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
        }
    }
}


