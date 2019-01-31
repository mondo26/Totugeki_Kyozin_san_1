using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy01を継承したクラス
public class Enemy02 : Enemy01
{
    [SerializeField, Header("Stopする時間")]
    private float stopTime;

    private int randamStopValue;            //  配列の中身を格納する値
    private int timer;
    private float stopMoveTimer;            // StopMove関数で使用する値
    private List<int> randomArray = new List<int>();

	public override void Start ()
    {
        base.Start();
        for (int i = 1; i <= 5; i++)
        {
            randomArray.Add(50 * i);
        }
        randamStopValue = randomArray[Random.Range(1, 5)];
    }
	
	
	public override void Update ()
    {
        base.Update();
        // 師匠にHitしていたらこれ以降処理をしない
        if (ishit_flg) { return; }
        // Stop状態じゃなかったらtimerをカウント
        if (moveDir != MOVEDIR.STOP) { ++timer; }
        // randamに割り振られた値よりtimerの方が値が大きかったら
        if(randamStopValue <= timer)
        {
            // Stop状態に
            moveDir = MOVEDIR.STOP;
            timer = 0;
        }
    }

    // 動きを止める処理
    public override void StopMove()
    {
        stopMoveTimer += Time.deltaTime;

        if(stopTime <= stopMoveTimer)
        {
            Debug.Log("Stop終了");
            moveDir = MOVEDIR.RIGHT;
            // ランダムの値を格納
            randamStopValue = randomArray[Random.Range(1, 5)];
            stopMoveTimer = 0.0f;
        }
    }

}
