using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeoCat : MonoBehaviour
{
    public bool playerHitBlock;
    private gravity gravity;
    // Start is called before the first frame update
    void Start()
    {
        GameObject anotherobject = GameObject.Find("cat");
        gravity = anotherobject.GetComponent<gravity>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHitBlock = gravity.IsChange();
    }

    public bool IsPlayerHitBlock()
    {
        return playerHitBlock;
    }
}
