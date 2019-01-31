using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private const float destroyTime = 1.0f;
    private float timer = 0.0f;

	void Start ()
    {
        
	}
	
	void Update ()
    {
        this.timer += Time.deltaTime;

        // 一秒後に消滅
		if(this.timer >= destroyTime)
        {
            Destroy(this.gameObject);
        }
	}
}
