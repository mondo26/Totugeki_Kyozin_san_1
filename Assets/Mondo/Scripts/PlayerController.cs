using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの速度")]
    private float playerSpeed;
    [SerializeField, Header("回転量")]
    private float rotationValue;
    [SerializeField, Header("Shishou(familyObj)を格納してください")]
    private familyobj familyObj;           /*familyobj.csから変数を取る*/

    private float rotateForce;              // 回る力
    private bool onceFlg;                   // 一度だけ通す処理

    public float _RotateForce { get { return rotateForce; } set { rotateForce = value; } }

    void Start ()
    {
        
	}
	
	void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        transform.position += (new Vector3(horizontal,/* vertical*/0, 0) * Time.deltaTime) * playerSpeed;
        PlayerRotate();
	}

    void PlayerRotate()
    {
        // Zボタンを押し、弟子が掴まえられていたら
        if (Input.GetKey(KeyCode.Z) && familyObj._Grad_flg)
        {
            rotateForce += rotationValue;               // 回転量を回る力に格納
            transform.Rotate(0, 0, rotateForce);        // プレイヤーの回転処理
            onceFlg = true;                             // 
        }

        // (Zボタンを押し、弟子が掴まえられていたら)が終わり、Zボタンを離したら
        if (Input.GetKeyUp(KeyCode.Z) && onceFlg)
        {
            familyObj._ReleaseParent = true;           // 親子関係を解放するFlgをTrueに
            familyObj._Grad_flg = false;               // 弟子を捕まえるFlgをfalseに
        }

    }
}
