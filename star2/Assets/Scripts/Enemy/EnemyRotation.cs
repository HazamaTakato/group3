using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    EnemyChange EC;
    NeoCat nc;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject parentObject = transform.parent.gameObject;
        nc = GetComponentInParent<NeoCat>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (nc.IsPlayerHitBlock())
        {
            transform.Rotate(0, 0, 10);
        }
        else
        {
            transform.Rotate(0, 0, -10);
        }

    }
}
