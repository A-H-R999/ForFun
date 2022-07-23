using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class points : MonoBehaviour
{
    public GameObject cyberEnemey;
    public GameObject syringe;
    public GameObject scoreText;
    public bool collected = false;

    public static int theScore = 0;

    private void Update()
    {
        scoreText.GetComponent<Text>().text = theScore + "/5 Collected";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && collected == false)
        {

            print("Vaccine is collected");
            cyberEnemey.SetActive(true);
            syringe.SetActive(false);
            //collectSound.Play();
            objective.theScore += 1;
            collected = true;
        }
    }
}






/*
 * //public GameObject scoreText;
    public GameObject fireFX;
    //public int theScore;
    public AudioSource collectSound;
    public bool collected = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && collected == false)
        {

            print("Fire is collected");
            fireFX.SetActive(false);
            //collectSound.Play();
            ScoringSystem.theScore += 1;
            collected = true;
        }
    }
*
*/









