using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyberMovement : MonoBehaviour
{
    [Header("SerializeField")]
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;

    public Transform player;
    public float Speed;
    int screamCount = 0;
    public int screamCounter;

    Rigidbody rb;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            screamCount += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(Speed);

        if (Vector3.Distance(transform.position, player.position) <= minDistance)
        {
            ani.SetBool("isAttacking", true);
            objective.cyberAttack = true;
        }
        else
        {
            ani.SetBool("isAttacking", false);
        } 

        var attacking = ani.GetBool("isAttacking");
        if (attacking == true)
        {
            objective.cyberAttack = true;
        }

        if (Vector3.Distance(transform.position, player.position) < maxDistance)
        {
            if (Vector3.Distance(transform.position, player.position) > minDistance)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
                rb.MovePosition(pos);
            }
            ani.SetBool("isRunning", true);
        }
        else if(Vector3.Distance(transform.position, player.position) > maxDistance)
        {
            ani.SetBool("isRunning", false);
        }
        transform.LookAt(player);
        transform.forward = new Vector3(transform.forward.x, 0, transform.forward.z);

        if (screamCount >= screamCounter)
        {
            ani.SetBool("isShooting", true);
            screamCount = 0;
        }
        else
        {
            ani.SetBool("isShooting", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            objective.cyberAttack = true;
        }
    }
}
