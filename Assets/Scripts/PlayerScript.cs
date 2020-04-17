using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [Header("Player attributes")]
    public float speed = 20f;
    public float jumpForce = 10f;

    [Header("Slide attributes")]
    public float scaleValue = .2f;
    public float slideTime = 1f;
    public float shrinkTime = 0.005f;

    [SerializeField]
    private bool isRunning = false;
    [SerializeField]
    private bool isGrounded = false;



    private Rigidbody2D rb;

    [Header("Buttons")]
    public Button jumpButton;
    public Button runButton;
    public Button stopButton;
    public Button turnButton;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Run();
    }

    void Update()
    {
        if (isRunning)
        {
            jumpButton.interactable = true;
            stopButton.interactable = true;
            runButton.interactable = false;
            turnButton.interactable = true;
        }
        else
        {
            jumpButton.interactable = false;
            stopButton.interactable = false;
            runButton.interactable = true;
            turnButton.interactable = true;
        }

        if (isGrounded)
        {
            jumpButton.interactable = true;
            turnButton.interactable = true;
        }
        else
        {
            jumpButton.interactable = false;
            runButton.interactable = false;
            turnButton.interactable = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        //if (col.gameObject.tag == "DamageObject")
        //{
        //    healthScr.IsHit();
        //    Debug.Log("Lose health and slide");
        //}
    }

    public void Run()
    {
        if (isGrounded)
		{
			rb.velocity = new Vector2(speed, rb.velocity.y);
			isRunning = true;
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
			rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
    }

    public void Stop()
    {
        isRunning = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void Turn()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            isRunning = true;
        }
    }
}

