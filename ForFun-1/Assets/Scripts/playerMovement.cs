using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float stamina;
    public GameObject staminaSlider;
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed);

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            if (playerSpeed < maxSpeed)
            {
                playerSpeed += 5 * Time.deltaTime;
            }
            stamina -= 2 * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || stamina < 0)
        {
            playerSpeed = 5;
        }

        if (stamina < 10 && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += 1 * Time.deltaTime;
        }

        staminaSlider.GetComponent<Slider>().value = stamina;
    }
}
