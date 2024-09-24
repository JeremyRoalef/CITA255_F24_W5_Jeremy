using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class will demonstrate the use of if statements
 */

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] float fltPlayerMoveSpeed = 5f;
    [SerializeField] float fltPlayerRotateSpeed = 5f;

    GameObject playerObj;

    void Start()
    {
        playerObj = SetPlayerObject();
        Debug.Log(playerObj);
    }

    void Update()
    {
        float fltMoveInput = Input.GetAxis("Vertical");
        float fltRotateInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(fltMoveInput) > 0)
        {
            MovePlayer(fltMoveInput);
        }
        if (Mathf.Abs(fltRotateInput) > 0)
        {
            RotatePlayer(fltRotateInput);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerObj = ChangePlayerObject();
        }
    }

    void MovePlayer(float moveDirection)
    {
        playerObj.GetComponent<Rigidbody>().velocity = playerObj.transform.forward * moveDirection * fltPlayerMoveSpeed;
    }
    void RotatePlayer(float rotateDirection)
    {
        Rigidbody rb = playerObj.GetComponent<Rigidbody>();
        Vector3 rotation = new Vector3(0, fltPlayerRotateSpeed * Time.deltaTime * rotateDirection, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }

    GameObject SetPlayerObject()
    {
        //Get the current player object from gameStarter script
        return GetComponent<GameStarter>().PlayerObject;
    }
    GameObject ChangePlayerObject()
    {
        GetComponent<GameStarter>().PlayerObject = new GameObject(); //Empty value to call the setter. IDK how to do it normally
        return GetComponent<GameStarter>().PlayerObject;
    }

}
