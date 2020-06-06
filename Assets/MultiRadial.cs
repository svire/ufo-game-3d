using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MultiRadial : MonoBehaviour
{

    public Image[] bars;
    public float timeAmount = 5f;
    private float time;
    public int maxHealth = 100;
    private int health;
    private bool smanji = true;
    private float tempTime = 0;
    void Start()
    {
        health = maxHealth;
    }
    public void AddHealth(int value)
    {
        health += value;
        if (health > maxHealth)
            health = maxHealth;
        updateMultibar();
    }
    public bool RemoveHealth(int value)
    {
        health -= value;
        if (health <= 30)
        {
            health = 30;
            updateMultibar();
            //ako je 0 vraca ture
            return true;
        }
        //ako ima jos healtha vraca false
        updateMultibar();
        return false;

    }
    // Update is called once per frame

    void WorkUnder()
    {


        for (int i = 0; i < 3; i++)
        {

            tempTime += Time.deltaTime;
            if (tempTime > 0.3)
            {
                tempTime = 0;



                //RemoveHealth(15);
                AddHealth(20);
            }
            //smanji = false;
        }
        smanji = false;
    }
    void WorkOver()
    {
        for (int i = 0; i < 3; i++)
        {

            tempTime += Time.deltaTime;
            if (tempTime > 0.3)
            {
                tempTime = 0;



                //RemoveHealth(15);
                RemoveHealth(20);
            }
            //smanji = false;
        }
        smanji = true;
    }

    void Update()
    {

        if (smanji == true)
        {
            WorkUnder();

        }
        else if (smanji == false)
        {
            WorkOver();
        }


        if (Input.GetKeyDown("l"))
        {

            AddHealth(15);


        }
        if (Input.GetKeyDown("k"))
        {
            RemoveHealth(15);

        }


    }

    private void updateMultibar()
    {
        for (int i = 0; i < bars.Length; i++)
        {
            float kolicnik = float.Parse(health.ToString()) / float.Parse(maxHealth.ToString());
            // healthbarFilling.fillAmount = kolicnik * startingFilling;
            bars[i].fillAmount = kolicnik;
            //bars[i].fillAmount = ();
        }
    }


}
