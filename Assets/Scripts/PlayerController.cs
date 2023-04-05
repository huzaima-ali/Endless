using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float JumpForce = 0;
    public bool isOnGround = true;
    public bool gameover = false;
    public float GravityModifier;
    private Animator Playeranim;
    public ParticleSystem ExplosionParticle;
    public ParticleSystem DirtParticle;
    public AudioClip jumpSound;
    public AudioClip CrashSound;
    private AudioSource PlayerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
        Playeranim = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && gameover != true)
        {
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;
            DirtParticle.Stop();
            PlayerAudio.PlayOneShot(jumpSound, 1.0f);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Playeranim.SetTrigger("Jump_trig");
            DirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("ObstaclePrefab"))
        {
            gameover = true;
            Debug.Log("Game Over!");
            Playeranim.SetBool("Death_b", true);
            Playeranim.SetInteger("DeathType_int", 1);
            ExplosionParticle.Play();
            DirtParticle.Stop();
            PlayerAudio.PlayOneShot(CrashSound, 1.0f);
        }
    }
}
