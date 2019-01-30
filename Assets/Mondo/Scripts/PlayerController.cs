using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの速度")]
    private float playerSpeed;
    [SerializeField, Header("回転量")]
    private float rotationValue;

    private float rotateForce;              // 回る力

	void Start ()
    {
	}
	
	void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += (new Vector3(horizontal, vertical, 0) * Time.deltaTime) * playerSpeed;
        PlayerRotate();
	}

    void PlayerRotate()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rotateForce += rotationValue;
            transform.Rotate(0, 0, rotateForce);
        }
        else
        {
            rotateForce = 0;
        }
    }
}
