using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //画面中央から左に4移動した位置をプレイヤーが超えたら
        if (transform.position.x > mainCamera.transform.position.x)
        {
            //カメラの位置を取得
            Vector3 cameraPos = mainCamera.transform.position;
            //プレイヤーの位置から右に4移動した位置を画面中央にする
            cameraPos.x = transform.position.x;
            mainCamera.transform.position = cameraPos;
        }
        else
        //画面中央から左に4移動した位置をプレイヤーが超えたら
        if (transform.position.x < mainCamera.transform.position.x)
        {
            //カメラの位置を取得
            Vector3 cameraPos = mainCamera.transform.position;
            //プレイヤーの位置から右に4移動した位置を画面中央にする
            cameraPos.x = transform.position.x;
            mainCamera.transform.position = cameraPos;
        }


        //画面中央から左に4移動した位置をプレイヤーが超えたら
        if (transform.position.y > mainCamera.transform.position.y)
        {
            //カメラの位置を取得
            Vector3 cameraPos = mainCamera.transform.position;
            //プレイヤーの位置から右に4移動した位置を画面中央にする
            cameraPos.y = transform.position.y;
            mainCamera.transform.position = cameraPos;
        }
        else
        //画面中央から左に4移動した位置をプレイヤーが超えたら
        if (transform.position.y < mainCamera.transform.position.y)
        {
            //カメラの位置を取得
            Vector3 cameraPos = mainCamera.transform.position;
            //プレイヤーの位置から右に4移動した位置を画面中央にする
            cameraPos.y = transform.position.y;
            mainCamera.transform.position = cameraPos;
        }

        //カメラ表示領域の左下をワールド座標に変換
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //カメラ表示領域の右上をワールド座標に変換
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        //プレイヤーのポジションを取得
        Vector2 pos = transform.position;
        //プレイヤーのx座標の移動範囲をClampメソッドで制限
        pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
        transform.position = pos;
    }
}
