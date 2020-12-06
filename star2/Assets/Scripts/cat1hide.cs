using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat1hide : MonoBehaviour
{
    public GameObject cat;
    public GameObject cat1;
    Rigidbody2D rigid2D;
    public bool jump;
    public float JumpForce = 500.0f;
    public float walkForce = 30.0f;
    public float maxWalkSpeed = 3.0f;

    public float catJump = 500.0f;
    public float cat1Jump = 500.0f;
    public float catWalk = 30.0f;
    public float cat1Walk = 30.0f;
    public float catWalkMax = 3.0f;
    public float cat1WalkMax = 3.0f;

    public Vector3 catPos;
    public Vector3 cat1Pos;

    public bool a;
    // Start is called before the first frame update
    void Start()
    {
        a = false;
        this.rigid2D = GetComponent<Rigidbody2D>();
        //cat.SetActive(true);
        //cat1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cat.transform.position = catPos;
        cat1.transform.position = cat1Pos;

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    cat.SetActive(false);
        //    cat1.SetActive(true);
        //    //Destroy(cat);
        //    //Destroy(cat1);
        //    a = true;
        //    if (Input.GetKeyDown(KeyCode.Z) && a == true)
        //    {
        //        //Instantiate(cat);
        //        //Instantiate(cat1);
        //        cat.SetActive(true);
        //        cat1.SetActive(false);
        //    }
        //}




        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            rigid2D.AddForce(cat.transform.up * catJump);
            rigid2D.AddForce(cat1.transform.up * catJump);
            jump = true;
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
            this.rigid2D.AddForce(cat.transform.right * key * this.catWalk);
            this.rigid2D.AddForce(cat1.transform.right * key * this.catWalk);
        }

        //動く方向に向けて反転
        if (key != 0)
        {
            cat.transform.localScale = new Vector3(key, 1, 1);
            cat1.transform.localScale = new Vector3(key, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        jump = false;
    }
}
