using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyBaseクラス（敵のBaseとなるクラス）
public class EnemyBase : MonoBehaviour
{
    // キャラが動く方向
    protected enum MOVEDIR
    {
        LEFT,
        RIGHT,
        UP,
        DOWN,
        STOP,
    };

    [SerializeField, Header("Playerを格納してください")]
    protected GameObject player;
    [SerializeField, Header("歩くスピード")]
    protected float walkSpeed;
    [SerializeField, Header("（爆発エフェクト）Explosionを格納してください")]
    protected GameObject explosion;
    protected MOVEDIR moveDir;                    // キャラが動く方向
    protected bool ishit_flg;                     // 師匠にHitしたかどうか？
    protected PlayerController playerController;  // プレイヤーのコントローラ

    public virtual void Start ()
    {
		
	}

    public virtual void Update ()
    {
		
	}
}
