using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{

    public bool CGravity;
    private PlayerGravity PG;

    // Start is called before the first frame update
    void Start()
    {
        CGravity = false;
        PG = GetComponent<PlayerGravity>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (PG.IsMode())
        {
            if (other.gameObject.tag == "Enemy")
            {
                CGravity = !CGravity;
            }
        }
    }

    public bool IsChange()
    {
        return CGravity;
    }
}
