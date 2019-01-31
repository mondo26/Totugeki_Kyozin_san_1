using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class familyobj : MonoBehaviour
{
    [SerializeField, Header("Playerを格納してください")]
    private GameObject player;

    private bool grad_flg = false;                   //　弟子に掴まえられたかどうか（ONなら掴む）
    private bool releaseParent = false;              //  親子関係を解放するFlg 

    private PlayerController playerController;

    public bool _Grad_flg { get { return grad_flg; } set { grad_flg = value; } }
    public bool _ReleaseParent { get { return releaseParent; } set { releaseParent = value; } }


    void Start ()
    {
        playerController = player.GetComponent<PlayerController>();
    }
	
	void Update ()
    {
        // 親子関係を解除するflgが立っていたら
        if (releaseParent)
        {
            // 親子関係解除
            gameObject.transform.parent = null;
            // 回転数を0,0,0にする
            transform.rotation = Quaternion.identity;  
            // 上方向に向かって回転した力分、飛ばす。
            transform.position += transform.up * playerController._RotateForce * 0.01f;
        }
    }

    void OnTriggerEnter2D(Collider2D catchdesi)
    {
        if (catchdesi.gameObject.tag == "Player")
        {
            if (!grad_flg)                                          //　掴まれていなかったら
            {
                gameObject.transform.parent = player.transform;     //　playerの子オブジェクトになる
                grad_flg = true;
            }
            
        }
    }
}
