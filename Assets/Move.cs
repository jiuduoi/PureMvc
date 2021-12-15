using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed = 10;
    public int rotate_speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(h!=0||v!=0)
        {
            transform.Translate(new Vector3(0, 0, v) * Time.deltaTime * speed,Space.Self);
            transform.Rotate(new Vector3(0, h, 0) * Time.deltaTime * rotate_speed);

        }
    }
}
