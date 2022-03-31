using UnityEngine;

public class Movement1 : MonoBehaviour
{
    //RigidBody
    public Rigidbody rb1;
    //Floats
    public float leftRightForce;
    public float jumpForce;
    //transform
    private Transform player1;
    //bools
    private bool grouned;
    //Vector3
    private Vector3 normalVector = Vector3.up;
    public Vector3 rotationIDK;
    //int
    private int jumpCount = 2;

    public void Awake()
    {
        rb1 = GetComponent<Rigidbody>();
        player1 = GetComponent<Transform>();
    }

    //resets jump amount
    public void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.tag == "ground")
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
        if (Input.GetKey("j"))
        {
            rb1.AddForce(-leftRightForce * Time.deltaTime, 0, 0);
            player1.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey("l"))
        {
            rb1.AddForce(leftRightForce * Time.deltaTime, 0, 0);
            player1.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown("i") && jumpCount > 0)
        {

            jumpCount -= 1;
            //Add jump forces
            rb1.AddForce(Vector2.up * jumpForce * 1.5f);
            rb1.AddForce(normalVector * jumpForce * 0.5f);
        }
    }
}
