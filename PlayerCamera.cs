using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public GameObject Player;

    public float XRotation = 0f;
    public float YRotation = 0f;

    public GameObject Playercamera;
    public GameObject Head;
    public Animator playerAnimator;
    public float fixX;
    public float fixY;
    public float fixZ;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        /*if (playerAnimator.GetBool("LBlock").Equals(true) || playerAnimator.GetBool("RBlock").Equals(true))
         {
             Playercamera.transform.position = new Vector3(Head.transform.position.x - 0.7f, Head.transform.position.y , Head.transform.position.z);
         }
         else
         {
             Playercamera.transform.position = new Vector3(Head.transform.position.x, Head.transform.position.y , Head.transform.position.z);
         }*/
        //Playercamera.transform.position = new Vector3(Head.transform.position.x, Head.transform.position.y, Head.transform.position.z);
        Playercamera.transform.position = new Vector3(Player.transform.position.x + fixX, Player.transform.position.y + fixY, Player.transform.position.z + fixZ);
        
        float HorizontalTurn = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float VerticalTurn = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        XRotation -= VerticalTurn;
        XRotation = Mathf.Clamp(XRotation, -90, 90);


        Mathf.Clamp(Player.transform.localEulerAngles.y, 100, 170);
        transform.rotation = Quaternion.Euler(XRotation, Player.transform.localEulerAngles.y, 0f);
        
        Player.transform.Rotate(Vector3.up *  HorizontalTurn);

        Debug.Log("VerticalTurn" + VerticalTurn);
    }
}
