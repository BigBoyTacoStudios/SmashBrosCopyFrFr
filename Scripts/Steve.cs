using UnityEngine;

public class Steve : MonoBehaviour
{
    private Transform playerPos;
    public Vector3 spawnPos;
    public GameObject block;
    public  void Awake()
    {
    playerPos = GetComponent<Transform>();
    Debug.Log("Steve mode on haha");
    }

    private void SpawnBlock()
    {
        spawnPos = playerPos.transform.position;
        //get the block object
        GameObject placedSteveBlock = Instantiate(block);
        //spawn object at player
        placedSteveBlock.transform.position = spawnPos;

    }
    
    private void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            SpawnBlock();
            Debug.Log("pressed c");
        }
        if (Input.GetKeyDown("s"))
        {
            if (Input.GetKeyDown("g"))
            {
                SpawnBlock();
                Debug.Log("should place block steve lololol");
            }
        }
    }
}
