using UnityEngine;
using System.Collections;

public class MouseCtrl : MonoBehaviour {
    private Vector2 rotation;
    public float speed = 10;
    

	// Use this for initialization
	void Start () {
        rotation = transform.eulerAngles;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            rotation.x -= Input.GetAxis("Mouse Y") * speed;
            rotation.y += Input.GetAxis("Mouse X") * speed;

            transform.eulerAngles = rotation;
            
           
        }
	
	}
}
