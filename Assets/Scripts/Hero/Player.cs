using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event EventHandler<OnShootEventsArgs> OnShoot;
    public class OnShootEventsArgs : EventArgs {};

    public GameObject objSlime;

    private float horizontalValue;
    private float verticalValue;
    public float moveSpeed = 1f;
    public ControlType controlType;
    public Joystick joystick;

    public enum ControlType{Pc, IOS};
    
    [SerializeField] public Vector3 movementInput;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;

    public float movementSpeed;
    public CameraFallow Trigger_Stay;
    public bool checkHit;

    private bool facingRight = false;
    private bool meDie = false;

    public bool haveSlime = false;
    public int numAltar;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        checkHit = false;
    }

    private void FixedUpdate()
    {
        if (Trigger_Stay.PlayerTrig)
        {
            animator.SetBool("IsMoving", false);
            return;
        }

        ProcessInputs();
        TurnPlayer();

        if (movementInput != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private void TurnPlayer()
    {
        if (movementInput.x < 0 && !facingRight)
        {
            Flip();
        }
        else if (movementInput.x > 0 && facingRight)
        {
            Flip();
        }
    }
 
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    void ProcessInputs()
    {
        if (controlType == ControlType.Pc)
        {
            horizontalValue = Input.GetAxisRaw("Horizontal");
            verticalValue = Input.GetAxisRaw("Vertical");
            movementInput = new Vector3(horizontalValue, verticalValue);
        }

        else if (controlType == ControlType.IOS)
        {
            movementInput = new Vector3(joystick.Horizontal, joystick.Vertical);
        }

        movementSpeed = Mathf.Clamp(movementInput.magnitude, 0.0f, 1.0f);

        movementInput.Normalize();
        if (movementInput != Vector3.zero)
        {
            checkHit = true;
            transform.position += movementInput * moveSpeed * movementSpeed * Time.fixedDeltaTime;
        }
        else if (movementInput == Vector3.zero && checkHit)
        {
            OnShoot?.Invoke(this, new OnShootEventsArgs{});
            checkHit = false;
        }

        /*if (movementInput == Vector3.zero)
        {
            joystick.input = Vector2.zero;
            joystick.handle.anchoredPosition = Vector2.zero;
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "slime" && !haveSlime)
        {
            objSlime.SetActive(true);
            Debug.Log("slime");
            haveSlime = true;
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage()
    {
        if (meDie == false)
        {
            meDie = true;
            Destroy(gameObject);
        }
    }
    
}
