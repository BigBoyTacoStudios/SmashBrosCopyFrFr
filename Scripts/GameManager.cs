using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //player objects
    public GameObject player1;
    public GameObject player2;

    //int
    public int player1Lives;
    public int player2Lives;
    private int easterEggInt = 0;

    //floats
    public float lowestY;

    //Vector3
    public Vector3 respawnPointP1;
    public Vector3 respawnPointP2;

    //Component
    private Component DamageP1;
    private Component DamageP2;

    //Text
    public Text Player1LivesText;
    public Text Player2LivesText;

    //key codes
    public KeyCode enter;

    private void Update() 
    {
        CheckPlayerPos();
        //easter egg
        if(Input.GetKeyDown(KeyCode.UpArrow) && easterEggInt == 0)
        {
            easterEggInt += 1;
            Debug.Log(easterEggInt);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && easterEggInt == 1)
        {
            easterEggInt += 1;
            Debug.Log(easterEggInt);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && easterEggInt == 2)
        {
            easterEggInt += 1;
            Debug.Log(easterEggInt);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && easterEggInt == 3)
        {
            easterEggInt += 1;
            Debug.Log(easterEggInt);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && easterEggInt == 4)
        {
            easterEggInt += 1;
            Debug.Log(easterEggInt);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && easterEggInt == 5)
        {
            easterEggInt += 1;
            Debug.Log(easterEggInt);
        }
        
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && easterEggInt == 6)
        {
            easterEggInt += 1;
            Debug.Log(easterEggInt);
        }
        
        else if(Input.GetKeyDown(KeyCode.RightArrow) && easterEggInt == 7)
        {
            easterEggInt += 1;
            Debug.Log(easterEggInt);
        }
        
        else if(Input.GetKeyDown(KeyCode.B) && easterEggInt == 8)
        {
            easterEggInt += 1;
            Debug.Log(easterEggInt);
        }
        
        else if(Input.GetKeyDown(KeyCode.A) && easterEggInt == 9)
        {
            easterEggInt += 1;
            Debug.Log(easterEggInt);
        }
        
        else if(Input.GetKeyDown(enter) && easterEggInt == 10)
        {
            Screen.SetResolution(227, 128, true);
            Debug.Log("Hi");
            easterEggInt = easterEggInt + 1;
        }
    }

    private void Start() {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            respawnPointP1 = player1.transform.position;
            respawnPointP2 = player2.transform.position;
        }
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        if(SceneManager.GetActiveScene().buildIndex == 0 && Screen.currentResolution.width == 227 && Screen.currentResolution.height == 128)
        {
            Screen.fullScreen = false;
            Invoke("SetToFull", 0.1f);
        }
        Player1LivesText.text = player1Lives.ToString();
        Player2LivesText.text = player2Lives.ToString();
    }

    private void SetToFull()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        Debug.Log("hi");
    }

    //respawn player
    public void CheckPlayerPos()
    {
        if(player1.transform.position.y < lowestY)
        {
            if(player1Lives == 1)
            {
                Player1LivesText.text = "0";
                EndGame("2");
                return;
            }
            else
            {
                player1Lives = player1Lives - 1;
                player1.transform.position = respawnPointP1;
                player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
                player1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                player2.GetComponent<DamageP2>().health1 = 0;
                Player1LivesText.text = player1Lives.ToString();
            }
            Debug.Log("Player 1 lives: " + player1Lives);
        }
        else if(player2.transform.position.y < lowestY)
        {
            if(player2Lives == 1)
            {
                Player2LivesText.text = "0";
                EndGame("1");
                return;
            }
            else
            {
                player2Lives = player2Lives - 1;
                player2.transform.position = respawnPointP2;
                player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
                player2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                player1.GetComponent<DamageP1>().health2 = 0;
                Player2LivesText.text = player2Lives.ToString();
            }
            Debug.Log("Player 2 lives: " + player2Lives);
        }
    }
    public void QuitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
    public void ToMain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void EndGame(string won)
    {
        if(won == "1")
        {
            Debug.Log("Player 1 wins!");
        }
        else if(won == "2")
        {
            Debug.Log("Player 2 wins!");
        }
    }
}
