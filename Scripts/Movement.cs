using UnityEngine;

public class Movement : MonoBehaviour
{
    //RigidBody
    public Rigidbody rb1;
    //Floats
    public float leftRightForce;
    public float jumpForce;
    //transform
    private Transform player1;
    //bools
    private bool particlesPlaying = false;
    //Vector3
    private Vector3 normalVector = Vector3.up;
    public Vector3 rotationIDK;
    //int
    private int jumpCount = 2;
    //particles
    public ParticleSystem walkingParicles;

    public void Awake()
    {
        rb1 = GetComponent<Rigidbody>();
        player1 = GetComponent<Transform>();
    }

    //resets jump amount
    public void OnCollisionEnter(Collision colInfo)
    {
        if(colInfo.collider.tag == "ground")
        {
            jumpCount = 2;
        }
    }

    void Update()
    {
        Jump();
        movement();
    }

    void movement() 
    {
        if(Input.GetButton("Player1Left"))
        {
            rb1.AddForce(-leftRightForce * Time.deltaTime, 0, 0);
            player1.rotation = Quaternion.Euler(0, 180, 0);
            particleHandler();
        }
        else if (Input.GetButton("Player1Right"))
        {
            rb1.AddForce(leftRightForce * Time.deltaTime, 0, 0);
            player1.rotation = Quaternion.Euler(0, 0, 0);
            particleHandler();
        }
        else
        {
            walkingParicles.Stop();
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {

            jumpCount -= 1;
            //Add jump forces
            rb1.AddForce(Vector2.up * jumpForce * 1.5f);
            rb1.AddForce(normalVector * jumpForce * 0.5f);
        }
    }

    //handle particles
    void particleHandler()
    {
        walkingParicles.Play();
        //particlesPlaying = true;
    }
}
