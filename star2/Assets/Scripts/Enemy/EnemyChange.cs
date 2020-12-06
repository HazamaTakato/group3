using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChange : MonoBehaviour
{

    public bool change;
    private PlayerGravity PG;

    // Start is called before the first frame update
    void Start()
    {
        change = false;
        GameObject anotherObject = GameObject.Find("cat");
        PG = anotherObject.GetComponent<PlayerGravity>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (PG.IsMode())
        {
            if (col.gameObject.tag == "Player")
            {
                change = !change;
            }
        }
    }

    public bool IsChange()
    {
        return change;
    }
}
