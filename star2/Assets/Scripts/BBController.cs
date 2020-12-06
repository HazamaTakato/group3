using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBController : MonoBehaviour
{
    public GameObject break_particle;

    private PlayerGravity PG;
    // Start is called before the first frame update
    void Start()
    {
        GameObject anotherObject = GameObject.Find("cat");
        PG = anotherObject.GetComponent<PlayerGravity>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!PG.IsMode())
        {
            if (col.gameObject.tag == "Player")
            {
                GameObject particle =Instantiate(break_particle);
                particle.transform.position = transform.position;
                this.gameObject.SetActive(false);
            }
        }
    }
}
