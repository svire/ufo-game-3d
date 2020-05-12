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
        // Invoke("Restart", 3.0f);
       // Reload();
        var distance = Vector3.Distance(camerica.transform.position, target.position);
       // Debug.Log(distance);
        if (distance < 150f)
        {
           
            if (holdingBall)
            {
               // Invoke("Pucaj", 2.0f); //zapucace za 10 sekundi i to ce trajati negoraniceno
               Pucaj();
            }
            
        }
    }
    void Reload()
    {
        //yield return new WaitForSeconds(5);
        holdingBall = true;
    }


    void Pucaj()
    {
        //if (Input.GetMouseButtonDown(0))
        // {
        //  audioSource.Play();

        FindObjectOfType<AudioManager>().Play("pucanje");
            Vector3 pos = new Vector3(camerica.transform.position.x, camerica.transform.position.y, camerica.transform.position.z);
            GameObject novi = Instantiate(prefab, pos, Quaternion.identity);

            novi.GetComponent<Rigidbody>().AddForce(camerica.transform.forward * ballThrowingForce);
        holdingBall = false;
        Invoke("Reload", 2.0f);

      //  }
    }



}
