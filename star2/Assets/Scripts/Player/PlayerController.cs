using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public bool jump;
    public float JumpForce = 500.0f;
    public float walkForce = 30.0f;
    public float maxWalkSpeed = 3.0f;
    public float maxDashSpeed = 6.0f;
    public bool mode;
    SpriteRenderer starrender;
    public Sprite catsprite;
    public Sprite standcat;
    Vector2 catGravity;
    Vector2 standGravity;

    Vector2 velocity;
    public Vector2 yGravity;
    public Vector2 xGravity;
    public float MaxGravitySpeed = 1.0f;

    public LayerMask groundLayer;
    bool grounded = false;
    public bool isGround = false;
    bool jumpRes = false;

    int key = 0;
    bool leftFlag;

    Animator anim;

    public float totalTime;
    float seconds;

    public float resTime;
    public float startingStar;
    public float currentStar;
    public Slider starSlider;

    bool CanSecondJump = false;

    private GameObject particle;
    private GameObject breakblock;

    PlayerGravity playerGravity;

    public int startJumpCount;
    int jumpCount;

    public AudioClip andou2;
    AudioManager audioManager;
   

    // Start is called before  the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        starrender = gameObject.GetComponent<SpriteRenderer>();
        //particle = GameObject.Find("Particle System");
        //particle.SetActive(false);
        starrender.sprite = catsprite;
        mode = true;//trueは人間 falseは星
        anim = GetComponent<Animator>();
        audioManager = GetComponent<AudioManager>();

        currentStar = startingStar;
        breakblock = GameObject.Find("BreakBlock");

        playerGravity = gameObject.GetComponent<PlayerGravity>();

        jumpCount = startJumpCount;
      
       
    }

    // Update is called once per frame
    void Update()
    {

        playerGravity.Change(seconds);

        grounded = Physics2D.Linecast(transform.position, transform.position - transform.up * 0.55f, groundLayer);

        isGround = Physics2D.Linecast(
            transform.position,
            transform.position - transform.up * 1.6f, groundLayer);

        if (isGround && rigid2D.velocity.y <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpRes = true;
            }
        }
        else if(!grounded && 0 < jumpCount && playerGravity.IsMode())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid2D.velocity = new Vector2(rigid2D.velocity.x, 8f);

                jumpCount--;
            }
        }
        if (grounded && jumpRes && playerGravity.IsMode())
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, 10f);
            
            //Jump();
            jumpRes = false;
            jumpCount = startJumpCount;
        }

        //大小ジャンプ
        if (Input.GetKey(KeyCode.Space) && rigid2D.velocity.y > 0.0f && playerGravity.IsMode() && !grounded)
        {
            rigid2D.gravityScale = 0.5f;
        }
        else
        {
            rigid2D.gravityScale = 1f;
        }

        key = 0;
        //左右移動
        if (playerGravity.IsMode())
        {
            totalTime += Time.deltaTime;
            seconds = totalTime;
            if (seconds >= resTime)
            {
                totalTime = resTime;
            }
            //Physics2D.gravity = yGravity;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                key = 1;
                leftFlag = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                key = -1;
                leftFlag = true;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
            }
        }
        else if (!playerGravity.IsMode())
        {
            audioManager.AudioPlay(andou2);
            totalTime -= Time.deltaTime;
            seconds = totalTime;
            //Physics2D.gravity = xGravity;
            if (velocity.x < MaxGravitySpeed)
            {
                velocity += xGravity * Time.deltaTime;
                transform.Translate(velocity * Time.deltaTime);
            }
        }


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        jump = false;
        CanSecondJump = false;
        //if (!playerGravity.IsMode()) 
        //{
        //    if (other.gameObject.tag == "BreakBlock")
        //    {
        //        breakblock.SetActive(false);
        //    }
        //}
    }

    void Stop()
    {
        rigid2D.velocity = Vector2.zero;
        rigid2D.angularVelocity = 0f;
    }

    void Jump()
    {
        //ジャンプ
        //if (mode == true)
        //{
        //rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
        //rigid2D.AddForce(transform.up * JumpForce);
        //}

        //}
        //void JumpRes()
        //{
        //    if (Input.GetKeyUp(KeyCode.Space))
        //    {
        //        if (rigid2D.velocity.y <= 7)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            rigid2D.velocity = new Vector2(rigid2D.velocity.x, rigid2D.velocity.y / 3f);
        //        }
        //    }
        //}
    }
    void PlayerAnim(int key)
    {
        bool trans = key !=0;
        anim.SetBool("trans", trans);
    }

    void PlayerTransStar()
    {
        anim.SetBool("StarTrans", true);
    }
    void PlayerReturnStar()
    {
        anim.SetBool("StarTrans", false);
    }

    void FixedUpdate()
    {
        //プレイヤー速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (speedx < maxDashSpeed&&grounded)
            {
                rigid2D.AddForce(transform.right * key * walkForce * 2);
            }
        }

        //rigid2D.velocity = new Vector2(key * 3f, rigid2D.velocity.y);

        //動く方向に向けて反転
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;

        PlayerAnim(key);
        TakeStar();

    }

    public void TakeStar()
    {
         currentStar = seconds;
         starSlider.value = currentStar;
    }

    void ParticleStart()
    {
        particle.SetActive(true);
        particle.GetComponent<ParticleSystem>().Play();
    }
    void ParticleEnd()
    {
        particle.SetActive(false);
        particle.GetComponent<ParticleSystem>().Stop();
    }

    //ギミック
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GoalFlag")
        {
            SceneManager.LoadScene("EndingScene");
        }
        if (other.gameObject.tag == "Death")
        {
            GetComponent<PlayerScript>().enabled = false;
            Invoke("Fall", 1.0f);
        }
    }
    void Fall()
    {
        SceneManager.LoadScene("GameScene");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(!playerGravity.IsMode())
        {
            if (other.gameObject.tag == "UpGravity")
            {
                rigid2D.velocity = new Vector2(0, 5);
            }
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(!playerGravity.IsMode())
        {
            if(other.gameObject.tag=="UpGravity")
            {
                rigid2D.velocity = new Vector2(0, 0);
            }
        }
    }
}

