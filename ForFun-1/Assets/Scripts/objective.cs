using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class objective : MonoBehaviour
{
    //Winning Variables
    public GameObject scoreText;
    public static int theScore = 0;
    public GameObject winningText;
    public GameObject winningImage;
    public GameObject cyberEnemy;
    public Transform player;
    int n = 1;
    public int posMultiplier;
   // public slenderMovement slender;
    public GameObject returnButton;
    public int vaccineCollection = 5;


    //Lossing Variables
    public static bool cyberAttack;
    public GameObject lossingImage;
    public GameObject lossingText;
    //public GameObject returnButton;

    // Start is called before the first frame update
    void Start()
    {
        winningImage.SetActive(false);
        winningText.SetActive(false);
        cyberEnemy.SetActive(true);
        returnButton.SetActive(false);

        Invoke("lossingScreen", 9f);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("winningScreen", 0);

        if (Input.GetMouseButton(0))
        {
            winningImage.SetActive(false);
            winningText.SetActive(false);
            cyberEnemy.SetActive(true);
            returnButton.SetActive(false);
        }

        scoreText.GetComponent<Text>().text = theScore + "/5 Collected";

        if (theScore == n)
        {
            Vector2 randomPos = Random.insideUnitCircle;
            Vector3 randomPosVector3 = new Vector3(randomPos.x + 5, -.25f, randomPos.y + 5);
            //GameObject.FindWithTag("enemy").transform.position = player.position + randomPosVector3 * posMultiplier;
            //slender.Speed += 2;
            n += 1;
        }
    }

    public void returntoMainMenu(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    void winningScreen()
    {
        if (theScore == vaccineCollection)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            winningImage.SetActive(true);
            winningText.SetActive(true);
            cyberEnemy.SetActive(false);
            returnButton.SetActive(true);

            //PauseMenu.gameIsPaused(false);
        }
    }

    void lossingScreen()
    {
        if (cyberAttack == true)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            lossingImage.SetActive(true);
        }
    }

    /*public void returntoMainMenu(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }*/
}
