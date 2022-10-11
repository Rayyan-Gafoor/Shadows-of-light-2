using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float move_speed;
    public float walk_speed;
    public float sprint_speed;
    public bool can_move= true;
    [Header("Jumping")]
    public float jump_force;
    public float jump_cooldown;
    public float air_multiplier;
    [SerializeField] bool can_jump;

    [Header("Ground Stuff")]
    public bool grounded;
    public float player_height;
    public float height_offset = 0.2f;
    public LayerMask ground_mask;
    public float ground_drag;

    [Header("Slope Stuff")]
    public float max_slope_angle;
    public float slope_pull;
    bool exit_slope;
    RaycastHit slope_hit;

    [Header("Key Bindings")]
    public KeyCode jump_key = KeyCode.Space;
    public KeyCode sprint_key = KeyCode.LeftShift;

    [Header("Animation Handler")]
    public GameObject player_model;
    Animator animator;
    [Header("References")]
    public Transform orientation;
    [SerializeField] Rigidbody rb;

    float horizontal_input;
    float vertical_input;
    Vector3 move_direction;

    public movement_states state;
    public enum movement_states
    {
        walking,
        sprinting,
        air
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = player_model.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        can_jump = true;

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, (player_height * 0.5f) + height_offset, ground_mask);
        player_inputs();
        speed_control();
        state_handler();
        if (grounded)
        {
            rb.drag = ground_drag;
          

        }
        else
        {
            rb.drag = 0;
        }
    }
    private void FixedUpdate()
    {
        if (can_move)
        {
            move_player();
        }
       
       
    }

    void player_inputs()
    {
        horizontal_input = Input.GetAxisRaw("Horizontal");
        vertical_input = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.Space) && can_jump && grounded)
        {
            can_jump = false;
            jump();
            Invoke(nameof(jump_reset), jump_cooldown);
        }

    }

    void move_player()
    {
        move_direction = orientation.forward * vertical_input + orientation.right * horizontal_input;
        if (on_slope() && !exit_slope)
        {
            rb.AddForce(get_slope_direction()* move_speed * 20f, ForceMode.Force);
            //Debug.Log("TPCC- on_slope=true" + "slope dir= "+ get_slope_direction());
            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
            // keep player on slope when moving down or up
            rb.AddForce(Vector3.down * slope_pull, ForceMode.Force);
        }
        if (grounded)
        {
            rb.AddForce(move_direction.normalized * move_speed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(move_direction.normalized * move_speed * 10f* air_multiplier, ForceMode.Force);
        }
        rb.useGravity = !on_slope();
        animation_controller();
    }
    //movement state handler
    void state_handler()
    {
        // running | sprinting state
        if (!can_move)
        {
            move_speed = 0;
        }
        else if (can_move)
        {
            move_speed = walk_speed;

        }
       
            if (grounded && Input.GetKey(sprint_key))
            {
                //Debug.Log("TPCC- is sprinting");
                state = movement_states.sprinting;
                move_speed = sprint_speed;
            }
            // walking state
            else if (grounded)
            {
                state = movement_states.walking;
                move_speed = walk_speed;
            }
            // not on ground | air state
            else
            {
                state = movement_states.air;
            }
        
        
    }
    void speed_control()
    {
        if (on_slope() && !exit_slope)
        {
            if (rb.velocity.magnitude > move_speed)
            {
                rb.velocity = rb.velocity.normalized * move_speed;
            }
        }
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // get the flat velocity of rigidbody from x and z axis
        // limit this veleocity if it is greater then our movement speed;
        if (flatVel.magnitude > move_speed)
        {
            Vector3 limitedVelocity = flatVel.normalized * move_speed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
    bool on_slope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slope_hit, player_height * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slope_hit.normal);// how steep is the slope
            //Debug.Log("TPCC- angle=" + angle);
            return angle < max_slope_angle && angle != 0;// return true if it is smaller than the max angle we can climb

        }
        return false;
    } 
    Vector3 get_slope_direction()
    {
        return Vector3.ProjectOnPlane(move_direction, slope_hit.normal).normalized;
    }
    void jump()
    {
        exit_slope = true;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //animator.SetBool("Jump", true);
        animator.SetTrigger("Jump");
        rb.AddForce(transform.up * jump_force, ForceMode.Impulse);
    }
    void jump_reset()
    {
        can_jump = true;
        exit_slope = false;
    }
    void animation_controller()
    {
        if(move_direction!= Vector3.zero)
        {
           
           // animator.SetBool("Walking", true);
            if (state == movement_states.sprinting)
            {
                animator.SetBool("Running", true);
                animator.SetBool("Walking", false);
            }
            else if (state == movement_states.walking)
            {
               //Debug.Log("Animator Controller- TPCC- is walking");
                animator.SetBool("Walking", true);
                animator.SetBool("Running", false);
            }
        }
        else if(move_direction== Vector3.zero)
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Running", false);
            

        }
        IEnumerator idle_controller()
        {
            yield return new WaitForSeconds(5f);
            animator.SetTrigger("IdleJump");
            
        }
    }
    
    
}
