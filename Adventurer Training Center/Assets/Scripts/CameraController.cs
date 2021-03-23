using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed;
    public float panBorder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if(Input.mousePosition.y>=Screen.height - panBorder)
        {
            position.y += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= panBorder)
        {
            position.y -= panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - panBorder)
        {
            position.x += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= panBorder)
        {
            position.x -= panSpeed * Time.deltaTime;
        }
        transform.position = position;
    }
}
