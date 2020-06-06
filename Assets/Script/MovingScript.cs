using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{

    public float playerSpeed = 30.5f;
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;
    public ParticleSystem puca;
    public GameObject smece;
    public Transform respawnPoint;
    private ParticleSystem[] children;

    private AudioSource audio;
    public AudioClip pad;



    //bool disabledRelevantPSEmissions = false;
    void Start()
    {
        children = this.transform.GetComponentsInChildren<ParticleSystem>();
        audio = GetComponent<AudioSource>();
        ParticleSystem vatra = GetSystem("Vatra");
        ParticleSystem afterburner = GetSystem("AfterBurner");


    }

    public void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name.ToString());
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Djule(Clone)")
        {
            audio.PlayOneShot(pad, 5.5f);
            ParticleSystem vatra = GetSystem("Vatra");
            vatra.enableEmission = enabled;
            Rigidbody rig = GetComponent<Rigidbody>();
            //rig.constraints = RigidbodyConstraints.FreezeRotationZ|RigidbodyConstraints.FreezeRotationX;
            rig.constraints = RigidbodyConstraints.None;
            //dodaj mu malo rotacije :D
            for (int i = 0; i < 50; i++)
            {
                float broj = float.Parse(i.ToString());
                transform.Rotate(i, i, i);
            }
            transform.Rotate(90, 180f, 50);


            smece.GetComponent<SymbolicLivesCounterScript>().loseLife();
            StartCoroutine(ExecuteAfterTime(5.5f));
            //   Debug.Log(col.gameObject.name);
        }


    }

    IEnumerator ExecuteAfterTime(float time)
    {
        ParticleSystem vatra = GetSystem("Vatra");
        // vatra.enableEmission =false;
        yield return new WaitForSeconds(time);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        transform.position = respawnPoint.position;
        transform.rotation = Quaternion.Euler(-180, 0, 0);
        vatra.enableEmission = false;


    }
    private ParticleSystem GetSystem(string sytemName)
    {
        foreach (ParticleSystem childr in children)
        {
            //Debug.Log(childr.ToString());
            if (childr.name == sytemName)
            {
                //Debug.Log("ima" + childr.ToString());
                return childr;
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * 105;
        transform.Translate(xMove, 0, 0);
        float zMove = Input.GetAxis("Vertical") * Time.deltaTime * 105;
        transform.Translate(0, 0, -zMove);


        if (Input.GetButtonDown("Jump"))
        {
            transform.Translate(0, -2.8f, 0);
            ParticleSystem vatra = GetSystem("Vatra");

            if (vatra.enableEmission == false)
            {
                vatra.enableEmission = enabled;

            }
            else
            {
                vatra.enableEmission = false;
            }

        }


        if (Input.GetKeyDown("c"))
        {
            transform.Translate(0, 0.3f, 0);

        }


        if (Input.GetKeyDown("r"))
        {
            transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown("t"))
        {
            smece.GetComponent<SymbolicLivesCounterScript>().loseLife();

        }
        if (Input.GetKeyDown("y"))
        {
            smece.GetComponent<SymbolicLivesCounterScript>().addLife();

        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            transform.Translate(0, -1.3f, 0);

        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            transform.Translate(0, 1.3f, 0);

        }
        if (Input.GetKeyDown("x"))
        {
            if (puca.isPlaying)
            {
                puca.Stop();

            }
            else
            {
                puca.Play();
                Invoke("stopy", 2);
            }

        }

        // print(transform.position);

    }
    public void stopy()
    {
        puca.Stop();
    }
}
