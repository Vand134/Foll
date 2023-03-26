using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float slideForce;
    private bool isGrounded;
    private Animator anim;
    private Vector3 direction;
    private Rigidbody rb;
    private Vector3 startPosition;
    private bool tr;
    private bool slide;
    private bool Finish;
    [SerializeField] private GameObject GostPlate;
    [SerializeField] private GameObject GostGlas;
    [SerializeField] private GameObject FinishGlas;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < -30)
        {
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
        }


        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        direction = transform.TransformDirection(new Vector3(moveX, 0, moveZ));

        if (direction.magnitude > 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GostPlate.SetActive(true);
            GostGlas.SetActive(true);
            
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            GostPlate.SetActive(false);
            GostGlas.SetActive(false);
            
        }



        if (slide)
        {
            rb.AddForce(direction * slideForce, ForceMode.Force);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.transform.position + direction * speed * Time.fixedDeltaTime);
        
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        anim.SetBool("Jump", false);

        if (collision.gameObject.CompareTag("Slide"))
        {
            slide = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        anim.SetBool("Jump", true);

        if (collision.gameObject.CompareTag("Slide"))
        {
            slide = false;
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plate"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("CheckPoint"))
        {
            startPosition = transform.position;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            FinishGlas.SetActive(true);

        }

    }
    

}
