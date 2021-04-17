using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.RemoteConfig;


public class Player : MonoBehaviour {
    private Rigidbody2D rb;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForse = 0.6f;

    public AnimationClip _walk, _jump;
    public Animation _Legs;
    public bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius=0.5f;
    public LayerMask Platforms;
    Vector3 dir;
    private bool facingRight = true;


    //LR7 script ----------------------------------
    public struct userAttributes { }
    public struct appAttributes { }

    void Awake() 
    {
        ConfigManager.FetchCompleted += SetSpeedForce;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void SetSpeedForce(ConfigResponse response) 
    {
        Debug.Log("SetSpeed = " + speed);
        speed = ConfigManager.appConfig.GetFloat("SpeedForce");
    }

    void OnDestroy() 
    {
        ConfigManager.FetchCompleted -= SetSpeedForce;
    }
    // --------------------------------------------
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Run()
    {
        dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime * 5);
        _Legs.clip = _walk;
        _Legs.Play();

    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
        //rb.velocity = new Vector2(rb.velocity.x , jumpForse);
        _Legs.clip = _jump;
        _Legs.Play();
    }


    void Update()
    {

        if (Input.GetButton("Horizontal"))
        {
            if (facingRight == true && Input.GetKey(KeyCode.LeftArrow))
            {
                Flip();
            }
            else if (facingRight == false && Input.GetKey(KeyCode.RightArrow))
            {
                Flip();
            }
            Run();
        }
        if (isGrounded && Input.GetButton("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Platforms);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
