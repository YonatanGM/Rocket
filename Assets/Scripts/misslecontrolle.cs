using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misslecontrolle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rocket;
    Vector3 randomoffset, oldpos, toeuler;
    Quaternion oldorientation;
    private bool miss = false;
    public float smoothness, elapsed, rotspeed, randomrotationoffset, d, relapsed, dr;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            Debug.Log(miss);
            elapsed += Time.deltaTime;
            relapsed += Time.deltaTime;
            randomrotationoffset = Random.Range(-10f, 10f);
            randomoffset = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0, 1.0f));
            if (elapsed > d)     //get position every two seconds
            {
                oldpos = rocket.transform.position;
                elapsed = 0;
            }

            if (relapsed > dr)
            {
                oldorientation = rocket.transform.rotation;
                oldorientation = Quaternion.Euler(oldorientation.eulerAngles.x, oldorientation.eulerAngles.y, oldorientation.eulerAngles.z + randomrotationoffset);
                relapsed = 0;
            }
            if (miss)
            {
                transform.Translate(0, Time.deltaTime * 5f, 0);
            }
            else
            {
                
                smoothness = smoothness + 0.01f;

                transform.position = Vector3.Lerp(transform.position, oldpos, Time.deltaTime * smoothness); //lerp to position with offset 
                transform.rotation = Quaternion.Lerp(transform.rotation, oldorientation, Time.deltaTime * rotspeed);
            }
            if (Mathf.Abs(transform.position.y - oldpos.y) < 0.5f && Mathf.Abs(transform.position.x - oldpos.x) < 0.5f) 
            {

                miss = true; 
            }

        }
    }
}