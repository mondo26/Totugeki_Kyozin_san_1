﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    // キャラが動く方向
    enum MOVEDIR
    {
        LEFT,
        RIGHT,
        UP,
        DOWN,
    };

    [SerializeField, Header("Playerを格納してください")]
    private GameObject player;                               
    [SerializeField, Header("（爆発エフェクト）Explosionを格納してください")]
    private GameObject explosion;                              　
    [SerializeField, Header("歩くスピード")]
    private float walkSpeed;
    [SerializeField, Header("右の折り返し地点")]
    private float rightTurningPoint;
    [SerializeField, Header("左の折り返し地点")]
    private float leftTurningPoint;

    private MOVEDIR moveDir;                    // キャラが動く方向
    private bool ishit_flg;                     // 師匠にHitしたかどうか？
    private Vector3 direction;                  // 敵が飛んでいく方向
    private PlayerController playerController;  // プレイヤーのコントローラ

    void Start ()
    {
        playerController = player.GetComponent<PlayerController>();
        moveDir = MOVEDIR.RIGHT;        // 最初は右へ移動
        ishit_flg = false;
	}
	
	void Update ()
    {
        // 師匠にHitしていなかった場合
        if (!ishit_flg)
        {
            switch (moveDir)
            {
                case MOVEDIR.RIGHT:
                    RightMove();
                    break;
                case MOVEDIR.LEFT:
                    LeftMove();
                    break;
            }
        }
        // 師匠にHitしていた場合
        else
        {
            transform.position += (direction * playerController._RotateForce) * -0.01f;
        }
	}

    // 右への移動処理
    void RightMove()
    {
        // 右の折り返し地点に着いていなかったら処理を実行
        if(transform.position.x < rightTurningPoint)
        {
            transform.position += new Vector3(walkSpeed, 0, 0) * Time.deltaTime;
        }
        else
        {
            // 左への移動処理へ
            moveDir = MOVEDIR.LEFT;
        }
    }

    // 左への移動処理
    void LeftMove()
    {
        // 左の折り返し地点に着いていなかったら処理を実行
        if(transform.position.x > leftTurningPoint)
        {
            transform.position += new Vector3(-walkSpeed, 0, 0) * Time.deltaTime;
        }
        else
        {
            // 右への移動処理へ
            moveDir = MOVEDIR.RIGHT;
        }
    }

    // トリガー判定
    void OnTriggerEnter2D(Collider2D catchdesi)
    {
        if (catchdesi.gameObject.tag == "Shishou"　&& !ishit_flg)
        {
            Debug.Log("Hit");
            // 爆発生成
            Instantiate(explosion, transform.position, Quaternion.identity);
            // 師匠の飛んでくる方向を取得
            direction = (catchdesi.gameObject.transform.position - transform.position).normalized;
            // HitしたのでFlgをTrue
            ishit_flg = true;
        }
    }
}
