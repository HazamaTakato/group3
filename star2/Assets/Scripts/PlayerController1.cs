using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public bool jump;
    public float JumpForce = 500.0f;
    public float walkForce = 30.0f;
    public float maxWalkSpeed = 3.0f;
    public bool change;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
        Debug.Log(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            rigid2D.AddForce(transform.up * JumpForce);
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.Z) && gameObject == true)
        {
            gameObject.SetActive(false);
            change = false;
        }


        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //プレイヤー速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //動く方向に向けて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        jump = false;
        change = false;
    }

    void OnDisable()
    {
        Debug.Log(gameObject);
        if (Input.GetKeyDown(KeyCode.Z) && gameObject == false)
        {
            gameObject.SetActive(false);
            change = true;
        }
    }
}
