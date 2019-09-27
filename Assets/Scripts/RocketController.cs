using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    public float forwardspeed;
    float turn, rotate, ypos;
    float presstime, totalpresstime;
    Vector3 Moveto, current;
    public Rigidbody2D a;
    GameObject temp;
    Transform dashtrail;
    ParticleSystem d; 
    public float dashamount;


    private void Awake()
    {
        dashtrail = transform.GetChild(0);
        d = dashtrail.GetComponent<ParticleSystem>();
        d.Play();
    }
    void Start()
    {
        a = GetComponent<Rigidbody2D>();
        forwardspeed = 5f;
        turn = 5f;
        temp = new GameObject();
    }

    
    void Dash()
    {
        var main = d.main;
        if (Input.GetKey(KeyCode.Space))
        {
            totalpresstime += Time.deltaTime;
            presstime += Time.deltaTime;
            //slow down a bit
            temp.transform.rotation = transform.rotation;
            temp.transform.position = transform.position;
            temp.transform.Translate(0, dashamount, 0);
            Moveto = temp.transform.position;
            current = transform.position;

            if(presstime < 0.3f)
            {
                //float amount = Mathf.Lerp(0f, 0.3f, presstime);
                main.startLifetime = 0.5f;
                a.velocity = (Moveto - current) / Time.deltaTime * 0.2f;
            }
            else
            {
                //transform.position = Vector3.Lerp(transform.position, Moveto, Time.deltaTime);
                //transform.position = Vector3.MoveTowards(transform.position, Moveto, 0.04f);
                print(';');
                a.velocity = Vector3.zero;
                main.startLifetime = 0.25f;
            }
        }
        else {
            totalpresstime = 0f;
            presstime = 0;
            a.velocity = Vector3.zero;
            main.startLifetime = 0.25f;

        }

    }
        void Movement()
        {
            ypos = forwardspeed;
            rotate = Input.GetAxis("Horizontal") * turn;
 
            ypos *= Time.deltaTime;
            rotate *= 50 * Time.deltaTime;
            transform.Translate(0, ypos, 0);
            transform.Rotate(0, 0, -rotate);
  
        }

        void Update()
        {
            Dash();
            Movement();
        }
    
}
