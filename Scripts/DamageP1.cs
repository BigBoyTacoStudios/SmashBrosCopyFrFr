using UnityEngine;
using UnityEngine.UI;

public class DamageP1 : MonoBehaviour
{
    //ints
    public int health2 = 0;
    public int maxDamage;
    private int combo;
    //games objects
    public GameObject player1;
    public GameObject Zach;
    //box collider
    public BoxCollider playercollider1;
    //bools
    private bool InReach;
    private bool attackP1Avalable = true;
    //rigid body
    public Rigidbody ZachRB;
    //vector3
    private Vector3 direction;
    //text
    public Text Player2Text;

    void Start()
    {
        //gets player2 box collider
        playercollider1 = GetComponent<BoxCollider>();
        
        attackP1Avalable = true;

        //set zachRB
        ZachRB = Zach.GetComponent<Rigidbody>();
    }

    public void DamageCheck()
    {
        //attack for p2
        if(Input.GetButton("AttackP1") && InReach == true && attackP1Avalable == true)
        {
            direction.x = 45 * 10; //move zach left
            if(player1.transform.localRotation.y == 1)
            {
                direction.x = -direction.x; //move zach right
                
            }
            else
            {
                direction.x = 45 * 10; //move zach left
            }
            //calculates damage
            attackP1Avalable = false;
            health2 = health2 + 8;
            Invoke("CoolDown", 0.9f);
            //inflicts damage
            direction.y = player1.transform.localRotation.y + 45 * 10; //up
            direction.z = 0;
            //increase force applied depending on the health of other player
            direction.x = health2/10 * direction.x + 10;
            ZachRB.AddForce(direction);
            combo = combo + 1;
        }
    }
    public void Update()
    {
        DamageCheck();
        Player2Text.text = health2.ToString();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            InReach = true;
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player")
        {
            InReach = false;
        }
    }
    //attack cool down
    public void CoolDown()
    {
        attackP1Avalable = true;
    }
}