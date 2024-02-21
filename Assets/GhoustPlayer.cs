using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoustPlayer : MonoBehaviour
{
    private float horizontalValue;
    private float verticalValue;
    public float moveSpeed = 1f;
    public ControlType controlType;
    public Joystick joystick;

    public enum ControlType{Pc, IOS};
    
    [SerializeField] public Vector3 movementInput;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public float movementSpeed;
    public CameraFallow Trigger_Stay;
    public GameObject prefabB;
    public GameObject ghoustPrefab;
    public Countdown timer;
    public GameObject Menu;
    public List<GameObject> gm;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {

        ProcessInputs();
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    
    }

    //Ходьба Персонажа
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
            transform.position += movementInput * moveSpeed * movementSpeed * Time.fixedDeltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Instantiate(prefabB, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            timer.Lets();
            switch(col.gameObject.name)
            {
                case "Red":
                gm[0].SetActive(true);
                break;
                case "Blue":
                gm[1].SetActive(true);
                break;
                case "Purple":
                gm[2].SetActive(true);
                break;
                case "Yellow":
                gm[3].SetActive(true);
                break;
            }
        }
        Debug.Log("f");
    }

}
