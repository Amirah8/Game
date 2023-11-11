using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody rb;
    public float MovementSpeed = 5.0f;
    public float JumpForce = 8.0f;
    public int CollectedCoins;

    public int MaxHealth = 1;
    [SerializeField] int CurrintHealth;

    Camera MainCamera;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        int CurrintHealth = MaxHealth;
        MainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * JumpForce , ForceMode.Impulse);
        }
    }

    public void Movement()
    {

        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticallInput = Input.GetAxis("Vertical");

        Vector3 CameraForward = Camera.main.transform.forward;
        Vector3 CameraRight = Camera.main.transform.right;
        CameraForward.y = 0;
        CameraRight.y = 0;

        Vector3 MoveDirection = CameraForward.normalized * VerticallInput + CameraRight.normalized * HorizontalInput;

        if (MoveDirection != Vector3.zero)
        {
            transform.forward = MoveDirection;
            transform.position += MoveDirection * MovementSpeed * Time.deltaTime;

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            Vector3 damageDiriction = other.transform.position - transform.position;
            damageDiriction.Normalize();
            rb.AddForce(-damageDiriction * 2 , ForceMode.Impulse);

            CurrintHealth--;
            if (CurrintHealth < 0)
            {
                gameManager.Restart();
            }
            gameManager.UpdateHealthText(CurrintHealth, MaxHealth);
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CollectedCoins++;
            gameManager.UpdateCoinText(CollectedCoins);
            Destroy(other.gameObject);
        }
    }
}
