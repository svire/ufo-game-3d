using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkriptaPucanj : MonoBehaviour {

    //public Transform prefab;
    public GameObject prefab;
    public GameObject camerica;
    public float ballDistance = 2f;
    public float ballThrowingForce = 5f;
    public bool holdingBall = true;
    private AudioSource audioSource;
   // private float nextActionTime = 0.0f;
   // public float period = 4.1f;
    public Transform target;
    void Start () {
        audioSource = GetComponent<AudioSource>();
        prefab.GetComponent<Rigidbody>().useGravity = false;        
       // Vector3 pos = new Vector3(camerica.transform.position.x, camerica.transform.position.y, camerica.transform.position.z);
      //  Instantiate(prefab, pos, Quaternion.identity);
       //TU GA INSTANCIRA I TU CE OSTATI(NIJE NJEGOV CHILd!)
       //OVO TREBA NAPRAVITI U TRENUTKU ISPALJIVANJA!		
	}
	
	// Update is called once per frame
	void Update () {

        var distance = Vector3.Distance(camerica.transform.position, target.position);
      //  Debug.Log(distance);
        if (distance < 150f) {
          if (holdingBall)
         {
            
            //   if (Time.time > nextActionTime)
       // {
      //      nextActionTime += period;
      //      StartCoroutine(Pucanj());
      //  }

      //  StartCoroutine(Pucanj());
        //if distance betwween object


        // prefab.transform.position = camerica.transform.position + camerica.transform.forward * ballDistance;
         if (Input.GetMouseButtonDown(0))
         {
                audioSource.Play();
                Vector3 pos = new Vector3(camerica.transform.position.x, camerica.transform.position.y, camerica.transform.position.z);
             GameObject novi=Instantiate(prefab, pos, Quaternion.identity);

        //  Vector3 poz = new Vector3(0.126f, 0.858f, 1.632f);
        // Quaternion rotationn = new Quaternion(0, 0, 0,0);
        // Instantiate(djule, poz,rotationn);
        //var myNew=Instantiate(djule, Vector3(0.126f, 0.858f, 1.632f),)
        //   novi.GetComponent<Rigidbody>().useGravity = true;
        //holdingBall = false;
        //graviti needs to be reaplied to ball
        //ovo se doda kad se napravi ball scirpt pa kad je bacis da prsti perje

        //ovde treba Instancirati on click djule
        //
        //prefab.GetComponent<Rigidbody>().useGravity = true;

       // audioSource.Play();
          novi.GetComponent<Rigidbody>().AddForce(camerica.transform.forward * ballThrowingForce);
                }
            }
        }
      /*  IEnumerator Pucanj()
            {
            int pauza = Random.Range(2, 5);
            yield return new WaitForSeconds(pauza);


            Vector3 pos = new Vector3(camerica.transform.position.x, camerica.transform.position.y, camerica.transform.position.z);
            GameObject novi = Instantiate(prefab, pos, Quaternion.identity);
            novi.GetComponent<Rigidbody>().useGravity = true;
            audioSource.Play();
            novi.GetComponent<Rigidbody>().AddForce(camerica.transform.forward * ballThrowingForce);
            */
        

        }
    
}
