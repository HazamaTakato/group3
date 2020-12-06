using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public bool jump;
    public float JumpForce = 500.0f;
    public float walkForce = 30.0f;
    public float maxWalkSpeed = 3.0f;
    public bool mode;
    SpriteRenderer starrender;
    public Sprite catsprite;
    public Sprite standcat;
    Vector2 catGravity;
    Vector2 standGravity;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        starrender = gameObject.GetComponent<SpriteRenderer>();
        starrender.sprite = catsprite;
        mode = true;//trueは人間 falseは星
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && !jump && mode == true)
        {
            rigid2D.AddForce(transform.up * JumpForce);
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.Z) && mode==true)
        {
            starrender.sprite = standcat;
            mode = false;
        }
        if (Input.GetKeyDown(KeyCode.X) && mode == false)
        {
            starrender.sprite = catsprite;
            mode = true;
        }


        //左右移動
        int key = 0;
        if (mode == true)
        {
            Physics2D.gravity = new Vector2(0, -6);
            if (Input.GetKey(KeyCode.RightArrow)) key = 1;
            if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        }
        if (mode == false)
        {
            rigid2D.velocity = Vector2.zero;
            Physics2D.gravity = new Vector2(80, 0);
            rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        //プレイヤー速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限
        if(speedx<this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //動く方向に向けて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key,1,1);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        jump = false;
    }

}
