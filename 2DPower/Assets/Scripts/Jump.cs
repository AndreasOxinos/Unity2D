using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{

    public string jumpButton = "Fire1";
    public float jumpPower = 250.0f;
    public Animator anim;
    public bool grounded = false;
    public Transform groundCheck;

    public float minJumpDelay = 0.5f;
    private float jumpTime = 0.0f;
    private bool jumped = false;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        jumpTime -= Time.deltaTime;
        if (Input.GetButtonDown(jumpButton))
        {
            if (!jumped)
            {
                jumped = true;
                grounded = false;
                rigidbody2D.AddForce(transform.up*jumpPower);
                anim.SetTrigger("Jump");
                jumpTime = minJumpDelay;
            }
        }

        if (grounded && jumpTime <= 0 && jumped)
        {
            jumped = false;
            anim.SetTrigger("Land");
        }
    }


}
