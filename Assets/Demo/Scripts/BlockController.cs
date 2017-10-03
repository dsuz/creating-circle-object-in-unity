using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control blocks. This destroy gameobject when it's off platform.
/// </summary>
public class BlockController : MonoBehaviour
{
	void FixedUpdate()
    {
        if (transform.position.y < -3)
            Destroy(this.gameObject);
	}
}
