using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float rotationrange, speed;   //-30 to 30
    // Start is called before the first frame update
    private Transform rocketpos;
 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rocketpos = GameObject.Find("Rocket").transform;
        Debug.Log(rocketpos.position.y);
        float rotateby = Mathf.Lerp(-rotationrange+10, rotationrange, rocketpos.position.y * Time.deltaTime * speed);
        Quaternion target = Quaternion.Euler(0, 0, 2*rotateby);
        Debug.Log(rotateby);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * speed);
       // transform.rotation.Euler(0, 0, 4);
        
    }
}
