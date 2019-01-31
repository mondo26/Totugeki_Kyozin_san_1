using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : EnemyBase
{
                      
    [SerializeField, Header("右の折り返し地点")]
    private float rightTurningPoint;
    [SerializeField, Header("左の折り返し地点")]
    private float leftTurningPoint;

    public override void Start ()
    {
        playerController = player.GetComponent<PlayerController>();
        moveDir = MOVEDIR.RIGHT;        // 最初は右へ移動
        ishit_flg = false;
	}
	
	public override void Update ()
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
                case MOVEDIR.STOP:
                    StopMove();
                    break;
                default:
                    break;
            }
        }
        // 師匠にHitしていた場合
        else
        {
            transform.position += (transform.up * playerController._RotateForce) * 0.01f;
        }
	}

    // 右への移動処理
    public void RightMove()
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
    public void LeftMove()
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
    // 動きを止める処理
    public virtual void StopMove()
    {

    }

    // トリガー判定
    void OnTriggerEnter2D(Collider2D catchdesi)
    {
        if (catchdesi.gameObject.tag == "Shishou"　&& !ishit_flg)
        {
            Debug.Log("Hit");
            // 爆発生成
            Instantiate(explosion, transform.position, Quaternion.identity);
            // HitしたのでFlgをTrue
            ishit_flg = true;
        }
    }
}
