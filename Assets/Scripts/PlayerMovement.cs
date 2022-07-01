using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rgb;
    Vector3 velocity;
    public Animator animator;
    public TextMeshProUGUI playerScoreText;

    public int life;
    public float damagedTime;
    public int score;
    public int keyScore;
    public TextMeshProUGUI keyScoreText;
    public TextMeshProUGUI lifeText;


    float speedAmount = 7f;
    float jumpAmount = 7f;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        score = 0;
        keyScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(damagedTime > 0)
        {
            damagedTime -= Time.deltaTime;
        }

        lifeText.text = life.ToString();
        keyScoreText.text = "Key " + keyScore.ToString() + " / 5";
        playerScoreText.text = "Score: "+ score.ToString();
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));


        if (Input.GetButtonDown("Jump") && !animator.GetBool("IsJumping"))
        {
            rgb.AddForce(Vector3.up* jumpAmount, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
              

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
      }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            animator.SetBool("IsJumping", false);
        }

        if (collision.gameObject.tag == "Enemy" && damagedTime <= 0)
        {
            Hit();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            animator.SetBool("IsJumping", true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && damagedTime <= 0)
        {
            Hit();
        }
    }

    void Hit()
    {
        life--;
        
        //  Debug.Log("Can :" + life);
        damagedTime = 0.7f;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.6f, gameObject.transform.position.z);

        if (life <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
