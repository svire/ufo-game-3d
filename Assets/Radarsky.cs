using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
public class Radarsky : MonoBehaviour {

    public Image[] bars;
    private bool smanji = true;
    private float tempTime = 0;
    private int now;
    private int max = 100;
    //public Transform nlo;
    public GameObject nlo;

 // //  private AudioSource audio;
  //  public AudioClip let;
  //  public AudioClip RadarOn;

    private bool inZone = false;

    public GameObject[] pvos;
    private int numPVO;



    void Start() {
        now = max;
        numPVO = pvos.Length;
      //  audio = GetComponent<AudioSource>();

    }
    public void Add(int value)
    {
        now += value;
        if (now > max)
            now = max;
        updateMultibar();
    }
    public bool Remove(int value)
    {
        now -= value;
        if (now <= 30)
        {
            now = 30;
            updateMultibar();
            //ako je 0 vraca ture
            return true;
        }
        updateMultibar();
        return false;
    }

    void Decrease()
    {
        for (int i = 0; i < 3; i++)
        {
            tempTime += Time.deltaTime;
            if (tempTime > 0.3)
            {
                tempTime = 0;
                //RemoveHealth(15);
                Add(20);
            }
            //smanji = false;
        }
        smanji = false;
    }
    void Increase()
    {
        for (int i = 0; i < 3; i++)
        {
            tempTime += Time.deltaTime;
            if (tempTime > 0.3)
            {
                tempTime = 0;
                //RemoveHealth(15);
                Remove(20);
            }
        }
        smanji = true;
    }
    //https://www.youtube.com/watch?v=8QdhlS11kd0
    //changin color to red if <180




    // Update is called once per frame
    void Update() {
        //every 3 seconds can see ovo


        tempTime += Time.deltaTime;
        if (tempTime > 0.3)
        {
            tempTime = 0;
            //RemoveHealth(15);

        }
        var distance1 = Vector3.Distance(nlo.transform.position, pvos[0].transform.position);
        var distance2 = Vector3.Distance(nlo.transform.position, pvos[1].transform.position);
        var distance3 = Vector3.Distance(nlo.transform.position, pvos[2].transform.position);
        var distance4 = Vector3.Distance(nlo.transform.position, pvos[3].transform.position);
        var distance5 = Vector3.Distance(nlo.transform.position, pvos[4].transform.position);

        if (distance1 < 180f|| distance2 < 180f || distance3 < 180f || distance4 < 180f || distance5 < 180f)
        {
            ChangeColor1();
        }
        else
        {
            ChangeColor2();
        }

       


     //   for (int i = 0; i < numPVO; i++)
     //   {

      //      var distance = Vector3.Distance(nlo.transform.position, pvos[i].transform.position);
      ////      Debug.Log(distance.ToString());
      //     if (distance < 170f)
       //     {
     //           inZone = true;
      //          ChangeColor1();


       //     }
      //      if(distance>170f)
      //      {
     //           inZone = false;
     //           ChangeColor2();
     //       }

    //    }






        if (smanji == true)
        {
            Decrease();

        }
        else if (smanji == false)
        {
            Increase();
        }
              


        if (Input.GetKeyDown("h"))
        {
            Component[] djeca = this.transform.GetComponentsInChildren<Image>();

            string[] bojePrije = new string[] { "#101565","#3e31a6","#709aec","#13568e","#052e7d","#0d1365","#05a6d8","#054de6"};

            string[] bojeMjenjaj = new string[] { "#FF2D00", "#D55C42", "#E8291C", "#93b33f", "#F93714", "#EC3A0A", "#D52323", "#0e9f3f" };

            //samo jos sa zutima za srednju udaljenost 
            //crvena je u zoni
            for (int i = 0; i < djeca.Length; i++)
            {
                UnityEngine.Debug.Log(djeca[i].ToString());
                Image sliba = (Image)djeca[i];
                // djeca[i].GetComponent<Color>().

               // sliba.color = Color.rg
                //[ napravi nizu tuplova sa bojama rgb da se prebaci

           
            Color myColor = new Color();
                //Color.TryParseHexString("#F00", out myColor);

                if (inZone==true)
                {
                    ColorUtility.TryParseHtmlString(bojeMjenjaj[i], out myColor);
                    sliba.color = myColor;


                }
                if (inZone == false)
                {
                    ColorUtility.TryParseHtmlString(bojePrije[i], out myColor);
                    sliba.color = myColor;
                }
            }

        }

    }

    private void Zvuk()
    {
        StackTrace stackTrace = new StackTrace();
        UnityEngine.Debug.Log(stackTrace.GetFrame(1).GetMethod().Name);
       
        if (stackTrace.GetFrame(1).GetMethod().Name=="ChangeColor2")
        {
         //   audio.Stop();
            //  https://www.youtube.com/watch?v=6OT43pvUyfY
          //  audio.clip = let;
           // audio.Play();

        }
        if (stackTrace.GetFrame(1).GetMethod().Name == "ChangeColor1")
        {
          //  audio.Stop();
         //   audio.clip = RadarOn;
         //   audio.Play();

        }
    }

    private void ChangeColor1()
    {
        FindObjectOfType<AudioManager>().Play("voznja");
        Zvuk();
        //audio.PlayOneShot(let);
        Component[] djeca = this.transform.GetComponentsInChildren<Image>();

      //  string[] bojePrije = new string[] { "#101565", "#3e31a6", "#709aec", "#13568e", "#052e7d", "#0d1365", "#05a6d8", "#054de6" };

        string[] bojeMjenjaj = new string[] { "#FF2D00", "#D55C42", "#E8291C", "#93b33f", "#F93714", "#EC3A0A", "#D52323", "#0e9f3f" };

        //samo jos sa zutima za srednju udaljenost 
        //crvena je u zoni
        for (int i = 0; i < djeca.Length; i++)
        {
           // UnityEngine.Debug.Log(djeca[i].ToString());
            Image sliba = (Image)djeca[i];
            // djeca[i].GetComponent<Color>().
           
            // sliba.color = Color.rg
            //[ napravi nizu tuplova sa bojama rgb da se prebaci


            Color myColor = new Color();
            //Color.TryParseHexString("#F00", out myColor);
            //ColorUtility.TryParseHtmlString(bojeMjenjaj[i], out myColor);
            // sliba.color = myColor;


          //  if (inZone)
          //  {
                ColorUtility.TryParseHtmlString(bojeMjenjaj[i], out myColor);
                sliba.color = myColor;


          //  }
         //   if (inZone = false)
         //   {
            //    ColorUtility.TryParseHtmlString(bojePrije[i], out myColor);
           //     sliba.color = myColor;
          //  }


        }
    }
  



        private void ChangeColor2()
    {
        FindObjectOfType<AudioManager>().Play("radarOn");
        //  audio.PlayOneShot(RadarOn);
        Zvuk();
        Component[] djeca = this.transform.GetComponentsInChildren<Image>();

        string[] bojePrije = new string[] { "#101565", "#3e31a6", "#709aec", "#13568e", "#052e7d", "#0d1365", "#05a6d8", "#054de6" };

        //string[] bojeMjenjaj = new string[] { "#FF2D00", "#D55C42", "#E8291C", "#93b33f", "#F93714", "#EC3A0A", "#D52323", "#0e9f3f" };

        //samo jos sa zutima za srednju udaljenost 
        //crvena je u zoni
        for (int i = 0; i < djeca.Length; i++)
        {
         //   UnityEngine.Debug.Log(djeca[i].ToString());
            Image sliba = (Image)djeca[i];
            // djeca[i].GetComponent<Color>().

            // sliba.color = Color.rg
            //[ napravi nizu tuplova sa bojama rgb da se prebaci


            Color myColor = new Color();
            //Color.TryParseHexString("#F00", out myColor);
            //ColorUtility.TryParseHtmlString(bojeMjenjaj[i], out myColor);
            // sliba.color = myColor;


        //    if (inZone)
        //    {
         //       ColorUtility.TryParseHtmlString(bojeMjenjaj[i], out myColor);
         //       sliba.color = myColor;


         //   }
        //    if (inZone = false)
        //    {
                ColorUtility.TryParseHtmlString(bojePrije[i], out myColor);
                sliba.color = myColor;
        //    }


        }




    }


    private void updateMultibar()
    {
        for (int i = 0; i < bars.Length; i++)
        {
            float kolicnik = float.Parse(now.ToString()) / float.Parse(max.ToString());
            
            bars[i].fillAmount = kolicnik;
            
        }
    }
}
