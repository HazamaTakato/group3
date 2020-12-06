using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{

    gravity grav;
    public bool mode;
    Vector2 velocity;
    public Vector2 yGravity;
    public Vector2 xGravity;
    public Vector2 LeftGravity;
    Rigidbody2D rigid2D;
    Animator anim;

    private GameObject particle;
    private GameObject particlerota;
    ParticleSystem particle_particle;
    ParticleSystem particlerota_particle;

    public AudioClip andou1;
    AudioManager audioManager;


    //Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        grav = GetComponent<gravity>();
        particle = GameObject.Find("Particle System");
        particlerota = GameObject.Find("Particle System rota");
        particle_particle = particle.GetComponent<ParticleSystem>();
        particlerota_particle = particlerota.GetComponent<ParticleSystem>();

        audioManager = GetComponent<AudioManager>();


        mode = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeGrav(float seconds)
    {
        if (Input.GetKeyDown(KeyCode.Z) && mode)
        {
            Physics2D.gravity = xGravity;
            rigid2D.velocity = Vector2.zero;
            velocity = Vector2.zero;
            ParticleStart();
            PlayerTransStar();
            mode = false;

        }
        else if (Input.GetKeyDown(KeyCode.Z) && !mode || seconds <= 0)
        {
            audioManager.AudioStop();
            Physics2D.gravity = yGravity;
            rigid2D.velocity /= 2;
            ParticleEnd();
            if (rigid2D.velocity.x >= 5)
            {
                rigid2D.velocity = new Vector2(5, rigid2D.velocity.y);
            }

            audioManager.AudioPlay(andou1);

            PlayerReturnStar();

            mode = true;
        }

    }


    public void ChangeLeftGrav(float seconds)
    {
        if (Input.GetKeyDown(KeyCode.Z) && mode)
        {
            Physics2D.gravity = LeftGravity;
            rigid2D.velocity = Vector2.zero;
            velocity = Vector2.zero;
            ParticleStartRota();

            PlayerTransStar();
            mode = false;

        }
        else if (Input.GetKeyDown(KeyCode.Z) && !mode || seconds <= 0)
        {
            audioManager.AudioStop();
            Physics2D.gravity = yGravity;
            rigid2D.velocity /= 2;
            ParticleEndRota();
            if (rigid2D.velocity.x >= 5)
            {
                rigid2D.velocity = new Vector2(5, rigid2D.velocity.y);
            }
            audioManager.AudioPlay(andou1);

            PlayerReturnStar();

            mode = true;
        }
    }

    public void Change(float seconds)
    {
        if (grav.IsChange())
        {
            ChangeLeftGrav(seconds);
        }

        else if (!grav.IsChange())
        {
            ChangeGrav(seconds);
        }
    }

    public void PlayerTransStar()
    {
        anim.SetBool("StarTrans", true);
    }
    public void PlayerReturnStar()
    {
        anim.SetBool("StarTrans", false);
    }

    public void ParticleStart()
    {
        particle_particle.Play();
    }
    public void ParticleEnd()
    {
        particle_particle.Stop();
    }

    public void ParticleStartRota()
    {
        particlerota_particle.Play();
    }
    public void ParticleEndRota()
    {
        particlerota_particle.Stop();
    }

    public bool IsMode()
    {
        return mode;
    }

}
