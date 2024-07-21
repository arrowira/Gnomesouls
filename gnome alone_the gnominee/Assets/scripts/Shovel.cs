using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    [SerializeField]
    private Animator anm;
    private bool cooldown = false;
    [SerializeField]
    private Player_Movement pm;
    private float firstspeed = 0;
    void Start()
    {
        firstspeed = pm.speed;
    }
    void cooldowntimer()
    {
        cooldown = false;
        pm.speed = firstspeed;
        anm.SetBool("isSword1", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && cooldown == false)
        {
            cooldown = true;
            pm.speed = 1; 

            anm.SetBool("isWalking", false);
            anm.SetBool("isIdle", false);
            anm.SetBool("isSword1", true);
            Invoke("cooldowntimer", 0.7f);
        }
    }
}
