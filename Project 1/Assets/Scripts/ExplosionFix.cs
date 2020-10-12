using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFix : MonoBehaviour
{
    // Explosion now only plays once
    void Start()
    {
        Destroy(gameObject, 2f);
    }

}
