using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0618

public class Break_particle : MonoBehaviour
{
    void Start()
    {
        transform.FindChild("smoke").gameObject.GetComponent<ParticleSystem>().Play();
        transform.FindChild("fire").gameObject.GetComponent<ParticleSystem>().Play();
    }

    void Update()
    {
        
    }
}
