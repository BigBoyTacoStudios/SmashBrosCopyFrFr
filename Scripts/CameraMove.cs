using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    //transfroms
    public Transform player1;
    public Transform player2;
    public Transform camera;

    //float
    private float averageY;
    public float respawnPoint;

    //Vector3
    private Vector3 average;
    public Vector3 offset;
    public Vector3 offset2;
    public Vector3 offset3;

    public void Update() 
    {
        Calculate();
    }

    public void Calculate()
    {
        
        if(player1.position.y < respawnPoint)
        {
            camera.position = offset;
        }
        else if (player2.position.y < respawnPoint)
        {
            camera.position = offset;
        }
        else
        {
            //average of x and y
            average = player1.position + player2.position;
            average = average / 2;
            //average of the hight
            averageY = player1.position.y + player2.position.y;
            average.z = -averageY / 2;
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                camera.position = average - offset2 + offset + offset3;
            }
            else
            {
                camera.position = average - offset2 + offset;
            }
        }
    }
}