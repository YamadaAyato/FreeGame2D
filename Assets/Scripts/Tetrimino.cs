using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimino : MonoBehaviour
{
    private float _horizontalInputDelay = 0.1f;  // キーを押しっぱなしのときの間隔
    private float _lastHorizontalInputTime = 0f;  //最後に押された時間

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        HandleMovement();

        ////横移動
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    transform.position += Vector3.left;  //(-1,0)座標を移動
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    transform.position += Vector3.right;  //(1,0)座標を移動
        //}

        ////回転の動き
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    transform.Rotate(0, 0, 90);  //左回転
        //}
        //else if (Input.GetKeyDown(KeyCode.X))
        //{
        //    transform.Rotate(0, 0, -90);  //右回転
        //}

        //transform.position = Vector3.down;

    }

    /// <summary>
    /// テトミノの動き
    /// </summary>
    private void HandleMovement()
    {
        float _horizontal = Input.GetAxisRaw("Horizontal"); // -1（←）、1（→）

        if (_horizontal != 0f)
        {
            if (Time.time - _lastHorizontalInputTime > _horizontalInputDelay)
            {
                //三項演算子 条件 ? A: B
                //入力に対する移動
                Vector3 _direction = (_horizontal < 0)
                    ? Vector3.left : Vector3.right;  

                transform.position += _direction;

                _lastHorizontalInputTime = Time.time;  //前回の移動時刻の更新
            }
            else
            {
                _lastHorizontalInputTime = Time.time - _horizontalInputDelay;  //動きをよくするための更新
            }
        }


    }
}
