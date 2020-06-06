using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkriptaShooting2 : MonoBehaviour
{

    public GameObject prefab;
    public GameObject camerica;
    public float ballDistance = 2f;
    public float ballThrowingForce = 5f;
    public bool holdingBall = true;
    private AudioSource audioSource;
    public Transform target;


    void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        prefab.GetComponent<Rigidbody>().useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        var distance = Vector3.Distance(camerica.transform.position, target.position);
        // Debug.Log(distance);
        //If the UFO is in the range of shooting, in this case, <150f then run shoot, or run the Pucaj() function
        if (distance < 150f)
        {

            if (holdingBall)
            {           
                //After every shot, anti-aircraft gun reloads, so if is reloaded you can shot again
                Pucaj();
            }

        }
    }
    //Reloads anti-aircraft gun
    //Reload will be invoked every 2 second
    void Reload()
    {        
        holdingBall = true;
    }

    // Shooting function 
    void Pucaj()
    {        
        FindObjectOfType<AudioManager>().Play("pucanje");
        Vector3 pos = new Vector3(camerica.transform.position.x, camerica.transform.position.y, camerica.transform.position.z);
        GameObject novi = Instantiate(prefab, pos, Quaternion.identity);
        novi.GetComponent<Rigidbody>().AddForce(camerica.transform.forward * ballThrowingForce);
        holdingBall = false;        
        Invoke("Reload", 2.0f);
     }

    
}
