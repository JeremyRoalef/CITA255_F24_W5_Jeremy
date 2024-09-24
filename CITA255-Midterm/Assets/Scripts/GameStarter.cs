using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class will demonstrate the usage of for loops, arrays, foreach loops, and properties
 */

public class GameStarter : MonoBehaviour
{
    [SerializeField] int intNumOfBlocks;
    [SerializeField] GameObject block;

    GameObject[] blocksInWorld; //Array usage
    int intCurrentPlayerIndex = 0;

    private GameObject playerObject;
    public GameObject PlayerObject
    {
        get
        {
            return playerObject;
        }
        set
        {
            value = value; //Just doing random stuff so I can use setter
            playerObject = SetPlayerObject();
        }
    }

    Vector3 blockSpawnPos = Vector3.zero;
    float red = 0f;
    float green = 0f;
    float blue = 1f;

    private void Awake()
    {
        blocksInWorld = new GameObject[intNumOfBlocks];
        //Debug.Log(red + ", " + green + ", " + blue);
        GenerateObjects();
        playerObject = blocksInWorld[0];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void GenerateObjects()
    {
        //Demonstrate the use of for loop
        for (int i = 0; i < intNumOfBlocks; i++)
        {
            GameObject newObj = Instantiate(block, blockSpawnPos, Quaternion.identity);
            blocksInWorld[i] = newObj;
            blockSpawnPos += new Vector3(2, 0, 0);
        }
        //Demonstrate the use of foreach loop
        foreach (GameObject block in blocksInWorld)
        {
            //Get object's renderer
            Renderer objRenderer = block.GetComponent<Renderer>();
            //Set the rgb values for the block
            objRenderer.material.color = new Color(red, green, blue);
            //update rgb values for next object
            red += 1f / (float)intNumOfBlocks; //I hate integer division
            green += 1f / (float)intNumOfBlocks;
        }
    }
    GameObject SetPlayerObject()
    {
        intCurrentPlayerIndex++;
        if (intCurrentPlayerIndex < intNumOfBlocks)
        {
            return blocksInWorld[intCurrentPlayerIndex];
        }
        else
        {
            intCurrentPlayerIndex = 0;
            return blocksInWorld[intCurrentPlayerIndex];
        }
    }
}
