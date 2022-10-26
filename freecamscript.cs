using UnityEngine;
using System.Collections;

public class DebugCam : MonoBehaviour 
{
    Vector3 rotation = Vector2.zero;
 
    [Header("Camera")]
    public GameObject cam;
 
    [Header("Speeds")]
    public float cspeed = 5;
    public float mspeed = 5;
 
    void Update () {
        rotation.y += Input.GetAxis ("Mouse X");
        rotation.x += -Input.GetAxis ("Mouse Y");
        transform.eulerAngles = (Vector3)rotation * cspeed;
 
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
 
        if(Input.GetKey(KeyCode.W))
            transform.position += cam.transform.forward * mspeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.A))
            transform.position += cam.transform.right * -1 * mspeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.S))
            transform.position += cam.transform.forward * -1 * mspeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.D))
            transform.position += cam.transform.right * mspeed * Time.deltaTime;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f )
            if(Input.GetKey(LeftControl))
                cam.GetComponent<Camera>().fieldOfView += 1;
            else
                mspeed += 0.5f;
            Debug.Log(mspeed);
        if (Input.GetAxis("Mouse ScrollWheel") < 0f )
            if(Input.GetKey(LeftControl))
                cam.GetComponent<Camera>().fieldOfView += 1;
            else
                mspeed -= 0.5f;
            Debug.Log(mspeed);
        if(Input.GetKeyDown(KeyCode.LeftShift))
            mspeed = 15;
        if(Input.GetKeyUp(KeyCode.LeftShift))
            mspeed = 10;
        }
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}