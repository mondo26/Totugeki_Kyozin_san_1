using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    enum DIR
    {
        LEFT,
        RIGHT,
        UP,
        DOWN,
    };

    [SerializeField, Header("歩くスピード")]
    private float walkSpeed;
    private DIR dir;                    // キャラの方向

	public virtual void Start ()
    {
		
	}

    public virtual void Update ()
    {
		
	}
}
