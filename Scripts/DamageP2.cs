using UnityEngine;
using UnityEngine.UI;

public class DamageP2 : MonoBehaviour
{
    //ints
    public int health1 = 0;
    public int maxDamage;
    private int combo;
    //games objects
    public GameObject player1;
    public GameObject Zach;
    //box collider
    public BoxCollider playercollider2;
    //rigid bodys
    public Rigidbody P1RB;
    //bools
    private bool InReach;
    private bool attackP2Avalable = true;
    //vector3
    private Vector3 direction;
    //text
    public Text Player1Text;

    void Start()
    {
        //gets player2 box collider
        playercollider2 = GetComponent<BoxCollider>();
        
        attackP2Avalable = true;

        //get player 1 collider
        P1RB = player1.GetComponent<Rigidbody>();
    }

    public void DamageCheck()
    {
        //attack for p2
        if(Input.GetButton("AttackP2") && InReach == true && attackP2Avalable == true)
        {
            direction.x = 45 * 10; //move player 1 left
            if(Zach.transform.localRotation.y == 0)
            {
                direction.x = -direction.x;
            }
            else if(Zach.transform.localRotation.y == -180)
            {
                direction.x = 45 * 10; //move zach left
            }
            //calculates damage
            attackP2Avalable = false;
            health1 = health1 + 8;
            Invoke("CoolDown", 0.9f);
            //inflicts damage
            direction.y = Zach.transform.localRotation.y + 45 * 10; //up
            direction.z = 0;
            //increase force applied depending on the health of other player
            direction.x = health1/10 * direction.x + 10;
            P1RB.AddForce(direction);
            combo = combo + 1;
        }
    }
    public void Update()
    {
        DamageCheck();
        Player1Text.text = health1.ToString();
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
        attackP2Avalable = true;
    }
}