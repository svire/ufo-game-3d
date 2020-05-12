using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kyle : MonoBehaviour {

    public float moveSpeed = 3f;
    public float rotSpeed = 100f;
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    // Use this for initialization
    void Start () {
        
	}
    public void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name.ToString());
       


    }

    // Update is called once per frame
    void Update () {
        if(isWandering==false)
        {
            //Coroutines are ways to write code that says "wait at this line for a little."
            //special type of  function used in unity to stop the executiron untril sometime or
            //certain condtion is met and countinues from where it had left off
            StartCoroutine(Wander()); 
        }
        if(isRotatingRight==true)
        {
            transform.Rotate(transform.up * Time.deltaTime*moveSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -moveSpeed);
        }
        if (isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
      
    }

    // IEnumerator allows to stop the process at a specific moment, return that part of object (or nothing) and gets back to that point whenever you need it.
    //The execution of a coroutine can be paused at any point using the yield statement. The yield return value specifies when the coroutine is resumed. Coroutines are excellent when modelling behaviour over several frames
    // StartCoroutine function always returns immediately, however you can yield the result

    IEnumerator Wander()
    {
        int rotTime = Random.Range(6, 7);//how long rotete
        int rotateWait = Random.Range(1,4);//time in between rotating
        int roteteLorR = Random.Range(1, 2);//u can also use bool for this
        int walkWait = Random.Range(1, 4);//amount of time betwwen  walkig
        int walkTime = Random.Range(1, 5);//i
        isWandering = true;
        
        //yield return statement line is the point at which executrion will pause and be resumed the following frame
        yield return new WaitForSeconds(walkWait);  //random number between 1.4
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (roteteLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (roteteLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }
}
