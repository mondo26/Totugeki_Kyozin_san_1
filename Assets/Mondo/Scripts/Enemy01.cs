using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    enum MOVEDIR
    {
        LEFT,
        RIGHT,
        UP,
        DOWN,
    };

    [SerializeField, Header("歩くスピード")]
    private float walkSpeed;
    [SerializeField, Header("右の折り返し地点")]
    private float rightTurningPoint;
    [SerializeField, Header("左の折り返し地点")]
    private float leftTurningPoint;

    private MOVEDIR moveDir;                    // キャラが動く方向

    void Start ()
    {
        moveDir = MOVEDIR.RIGHT;        // 最初は右へ移動
	}
	
	void Update ()
    {
		switch(moveDir)
        {
            case MOVEDIR.RIGHT:
                RightMove();
                break;
            case MOVEDIR.LEFT:
                LeftMove();
                break;
        }
	}

    // 右への移動処理
    void RightMove()
    {
        if(transform.position.x < rightTurningPoint)
        {
            transform.position += new Vector3(walkSpeed, 0, 0) * Time.deltaTime;
        }
        else
        {
            moveDir = MOVEDIR.LEFT;
        }
    }

    // 左への移動処理
    void LeftMove()
    {
        if(transform.position.x > leftTurningPoint)
        {
            transform.position += new Vector3(-walkSpeed, 0, 0) * Time.deltaTime;
        }
        else
        {
            moveDir = MOVEDIR.RIGHT;
        }
    }
}
