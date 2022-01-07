using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //do wielu poziomów
using UnityEngine.UI;

public class Gracz : MonoBehaviour
{
    public float speed = 4f;
    public float jumpSpeed = 6.5f;
    private float drabina = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation;

    private Vector3 respawn;
    public GameObject podloga;

    public Text punktacjaText;
    public PunktacjaZycia punktacjaZycia;
    public PunktacjaZycia dodawanieZycia;

    public Audiomanager audiomanager;




    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawn = transform.position;
        punktacjaText.text = "Pkt: " + Punktacja.punktacja; //podlicza pkt Punktacja.punktacja.ToString();

    }

    // Update is called once per frame
    void Update()
    {                     
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");
        Debug.Log(direction);
        if(direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(0.35f, 0.35f);
        }
        else if(direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-0.35f, 0.35f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        //isTouchingGround domyœlnie jest true
        if(Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);

        podloga.transform.position = new Vector2(transform.position.x, podloga.transform.position.y);

        if(Zycie.punktacjaZycia == 0f)
        {
            GameManager.isGameOver = true;
            gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Podloga")
        {
            transform.position = respawn;
        }
        else if(collision.tag == "Kamien")
        {
            respawn = transform.position;
        }
        else if(collision.tag == "Drabina")
        {
            player.velocity = new Vector2(player.velocity.x, drabina);
        }
        else if(collision.tag == "NextLevel")
        {
            audiomanager.Audio.PlayOneShot(audiomanager.Teleport);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.LoadScene(0); SceneManager.LoadScene(1);
            respawn = transform.position;
        }
        else if(collision.tag == "Punkty")
        {
            audiomanager.Audio.PlayOneShot(audiomanager.PickUp);
            Punktacja.punktacja += 1;
            punktacjaText.text = "Pkt: " + Punktacja.punktacja;
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag == "Pulapka")
        {
            punktacjaZycia.Damage(0.0025f);
        }
        else if(collision.tag == "skrzynka")
        {
            SceneManager.LoadScene(2);
        }
        else if(collision.tag == "Powrot")
        {
            SceneManager.LoadScene(0);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Pulapka")
        {
            punktacjaZycia.Damage(0.0025f);
        }
        else if (collision.tag == "Zycie")
        {
            punktacjaZycia.DodajZycie(0.025f);
        }
    }



   
}
