using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {


    // public List<GameObject> allPVO = new List<GameObject>();
    //  private int pvoBroj;
    public GameObject[] pvos;
    private int numPVO;

	void Start () {
        numPVO = pvos.Length;
        
        
		
	}
	
	void checkDistance(float distance)
    {
        if (distance > 170)
        {
            //Debug.Log("DOBRO JE");
           
        }

    }
	void Update () {
      //  if (Input.GetKeyDown("b"))
       // {
             for(int i = 0; i < numPVO; i++)
            {
               // Debug.Log(pvos[i].ToString());
                //Debug.Log(pvos[i].transform.position);
                //camera radara                //pvos[i].transform.position
               // Debug.Log("Distanca izmedju NLO I objekta" + pvos[i].ToString());
                var distance = Vector3.Distance(this.transform.position, pvos[i].transform.position);
            //Debug.Log(pvos[i].ToString()+distance);
           
            if (distance < 170)
            {
                
                  // Debug.Log("blizina" + distance + pvos[i].ToString());

                  //  checkDistance(distance);
              
            }
            else
            {
               // Debug.Log("Dobar si baja"+distance.ToString());
                
            }
           

        }
           
       // }
		
	}
}
