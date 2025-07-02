using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Tetrimino : MonoBehaviour
{

    [Header("移動のリピート設定")]
    [SerializeField] private float _horizontalInputDelay = 0.3f;  // キーを押しっぱなしのときの間隔
    private float _lastHorizontalInputTime = 0f;  //最後に押された時間

    private bool _wasHorizontalPressedLastFrame;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        HandleMovement();
        HandleRotation();
        HandleFall();

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
    /// テトミノのx軸の動き
    /// </summary>
    private void HandleMovement()
    {
        float _horizontal = Input.GetAxisRaw("Horizontal"); // -1（←）、1（→）

        if (_horizontal != 0f)
        {
            if (!_wasHorizontalPressedLastFrame)
            {
                // 押した瞬間はすぐ動かす
                //三項演算子 条件 ? A: B
                //入力に対する移動
                Vector3 _direction = (_horizontal < 0)
                    ? Vector3.left : Vector3.right;
                transform.position += _direction;
                _lastHorizontalInputTime = Time.time;  //前回の移動時刻の更新
            }
            else if (Time.time - _lastHorizontalInputTime > _horizontalInputDelay)
            {
                // 長押し中は一定間隔で動かす
                Vector3 _direction = (_horizontal < 0)
                    ? Vector3.left : Vector3.right;
                transform.position += _direction;
                _lastHorizontalInputTime = Time.time;  //前回の移動時刻の更新
            }

            _wasHorizontalPressedLastFrame = true;
        }
        else
        {
            // 離されたら次の押し直しに即反応できるよう準備
            _wasHorizontalPressedLastFrame = false;
            _lastHorizontalInputTime = Time.time - _horizontalInputDelay;  //動きをよくするための更新
        }


    }



    /// <summary>
    /// テトミノの回転の動き
    /// </summary>
    private void HandleRotation()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.Rotate(0, 0, 90);  //左回転
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            transform.Rotate(0, 0, -90);  //右回転
        }
    }

    private void HandleFall()
    {

    }
}
