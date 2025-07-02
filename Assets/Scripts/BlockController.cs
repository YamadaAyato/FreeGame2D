using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BlockController : MonoBehaviour
{
    [Header("落下設定")]
    [SerializeField] private float _fallTime = 1.0f;  //落下の速さ(一マス落下の感覚)
    [SerializeField] private float _scaleFactor = 10f;  //落下の倍率
    private float _previousTime;

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
            //動きをよくするための更新
            _lastHorizontalInputTime = Time.time - _horizontalInputDelay;
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
        float _interval = Input.GetKey(KeyCode.DownArrow)
            ? _fallTime / _scaleFactor : _fallTime;

        if (Time.time - _previousTime > _interval)
        {
            transform.position += Vector3.down;
            _previousTime = Time.time;
        }
    }
}
