using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Particle : MonoBehaviour {
    public GameObject ufo;
    public GameObject dizalica;
    bool jeste=false;
    private float time = 0;
    // Use this for initialization
    void Start () {
        dizalica = new GameObject();
		
	}

    public void OnParticleCollision(GameObject other)
    {

        if (other.name.ToString() == "Dizi")
        {
            // Debug.Log("colide with"+other.name.ToString());
            //  int ufovisina;
            // int.TryParse(ufo.transform.position.y.ToString(), out ufovisina);
            // Debug.Log(ufovisina);
            jeste = true;
            other.GetComponent<Kyle>().enabled=false;

            Debug.Log("Dizi smradonju");
            dizalica = other;
           // IdiGore(dizalica);
            //   }
            // dizalica.transform.Translate(ufo.transform.position.x, , ufo.transform.position.z);
        }

    }
    private void IdiGore(GameObject dizalica)
    {
        /*    float positiony = dizalica.transform.position.y;
            // int covavisina;
            //  int.TryParse(dizalica.transform.position.y.ToString(), out covavisina);

            float ufopositiony = ufo.transform.position.y;
            //  int ufovisina;
            //  int.TryParse(ufo.transform.position.y.ToString(), out ufovisina);

            float ovo;

            float.TryParse(ufo.transform.position.x.ToString(), out ovo);
            //dizalica.transform.position = new Vector3(ufo.transform.position.x, 0, ufo.transform.position.z);
            //dizalica.transform.position.z = ufo.transform.position.z;
            //Vector3 ufopos = new Vector3(ufo.transform.position.x, 0, ufo.transform.position.z);

            // dizalica.transform.position = ufopos;*/
        if (dizalica != null)
        {
            float ufox = ufo.transform.position.x;
            // float ufoz = ufo.transform.position.z;
            float dizx = dizalica.transform.position.x;
            // float dizz = dizalica.transform.position.y;
            float translatex = ufox - dizx;
            if (translatex > 0)
            {
                dizalica.transform.Translate(translatex, 0, 0);
            }
            if (translatex < 0)
            {

                //prvo mu moras rigidbody enable false da se ne krece
                dizalica.transform.Translate(-translatex, 0, 0);
            }
        }
      



     /*  float ufoz = ufo.transform.position.z;
        float dizz = dizalica.transform.position.z;
        float translatez = ufoz - dizz;
        if (translatez>0)
        {
            dizalica.transform.Translate(0, 0,translatez);
        }

        if (translatez < 0)
        {
            dizalica.transform.Translate(0, 0, -translatez);
        }
        // float translatez = ufoz - dizz;

        Debug.Log(translatex);*/
        
    /*    if (positiony <= ufopositiony - 5)
        {
            positiony += 0.5f;
             dizalica.transform.Translate(0, 1.1f, 0);
           // transform.Translate(Vector3.up * Time.deltaTime, Space.World);


        }
        */
    }
    //sad ti valja raditi ui 
   //ili ralease na moving
   //if full capacity ufo is slightly slower
   //napravi trampolinu

    void OvoPozovi()
    {
        IdiGore(dizalica);
        // Debug.Log("BROD" + ufo.transform.position.y + "particlce" + this.transform.position.y);
        //                  35                                         27 

        //KAKO DA GA PRATI NON STOP?

        //A AKO STAVIS PARTICLE SYSTEM SA 0 4 0  NA 0 0 0 BUDE TI SLEDECE
        //                40                                          40
        //+ STO TI NE RADI COLLISION SRANJE JER SE ONDA ON IMA COLLISION SA BRODOM

        //     Debug.Log("ovo smece je paricle"+this.transform.position);
        // Vector3 cova = new Vector3(this.transform.position.x,, this.transform.z);
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * 105;
       // transform.Translate(xMove, 0, 0);
        float zMove = Input.GetAxis("Vertical") * Time.deltaTime * 105;
        //transform.Translate(0, 0, -zMove);

        if (dizalica != null)
        {
            //e al sto sasd ovde nije kontra ko tamo dje ide smrt fasizmu sloboda narodu
            dizalica.transform.localPosition += new Vector3(xMove, 0, zMove);
        }
       // dizalica.transform.localPosition += new Vector3(xMove,0,-zMove);
        time += Time.deltaTime;
        if (Input.GetKeyDown("m") && jeste == true && dizalica != null && time < 2f)
        {
            //sad jos treba staviti i da ga prati lijevo desno    OVO DOLE JE IZ MOVING SCRIPTA
            //  rigidbody.constraints = RigidbodyConstraints.FreezePosition             rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
           // transform.position = respawnPoint.position;            transform.rotation = Quaternion.Euler(-180, 0, 0);

            //FUNKCIJA NEK SAMO PRATI PO X
            //po z nne  radi nikakooooooooo 
            // unity one object takes another object Transform.Translate or position

            // Debug.Log(time);
            time = 0;
            if (Input.GetKeyDown("m") && time < 3f)
            //   {
            {
                dizalica.GetComponent<Rigidbody>().useGravity = false;
                float dizpozy = dizalica.transform.position.y;
                if (dizpozy < this.transform.position.y - 10)
                {
                    //   Debug.Log("jel manje" + dizpozy + "od ovog sranja" +this.transform.position.y);
                    dizalica.transform.Rotate(0, 50f, 0);
                    // ovo radi ali jebem ti znanjeDestroy(dizalica);
                    dizalica.transform.Translate(0, 0.9f, 0);
                    dizpozy += 0.9F;

                }
                //NAPOKON RADI AL TREBA OVE KOLAJDERE SREZATI JER AFTERBURNER KRECE OD 
                else //if(dizpozy>this.transform.position.y-9.5) ovo te jebe gledaj gore ide i do -10
                {
                    Destroy(dizalica);
                }
            }
           /* else if(time>2f)
            {
                dizalica.GetComponent<Rigidbody>().useGravity = true;
                time = 0;
                //ovde ga onda trebas i ispraviti
                //dizalica.GetComponent<Rigidbody>().transform.rotation=new Vector3(0,0,0); //(0,0,0,0)
            }
            */
        }
        else if (time > 2f)
        {
            //nesto izbacuje jebo ga  brat

            try
            {
                dizalica.GetComponent<Rigidbody>().useGravity = true;
                time = 0;
            }
            catch (Exception e)
            {
               // Debug.Log("JBG");
            }
            //ovde ga onda trebas i ispraviti
            //dizalica.GetComponent<Rigidbody>().transform.rotation=new Vector3(0,0,0); //(0,0,0,0)
        }

    }



    void Update () {

        OvoPozovi();
        // float x, y, z;
        //float.TryParse(ufo.transform.position.x.ToString(), out x);

        // Debug.Log(dizalica);

        //Debug.Log(ufopos);

      /*  time += Time.deltaTime;

        if (Input.GetKeyDown("m") && jeste == true && dizalica != null&&time<2f)
        {

            Debug.Log(time);
            time = 0;//restart time

            //  if (Input.GetKeyDown("m") && time < 3f)
            //   {
            dizalica.GetComponent<Rigidbody>().useGravity = false;
            dizalica.GetComponent<Rigidbody>().transform.Rotate(8f, 0, 8f);
              
               // dizalica.GetComponent<Rigidbody>().useGravity = false;
                float dizpozy = dizalica.transform.position.y;


            //ne traba kurcev ufo vec particle sistem sa njim se kolajduje
                if (dizpozy < ufo.transform.position.y - 3)
                {
                    dizalica.transform.Translate(0, 0.9f, 0);
                    dizpozy += 0.9F;

                }
       
        }
        else if(time>2f)
        {
            dizalica.GetComponent<Rigidbody>().useGravity = true;
            time = 0;
            //ovde ga onda trebas i ispraviti
            //dizalica.GetComponent<Rigidbody>().transform.rotation; (0,0,0,0)
        }
        
		*/
	}
}
