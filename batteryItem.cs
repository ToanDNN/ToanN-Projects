using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryItem : MonoBehaviour
{

    public bool canPickUp;
    public float amount;
    public GameObject flashlightObject;
    public BatteryLifeScript battery;
    public float radius = 2f;
    public Transform player;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Update is called once per frame
    private void Update()
    {
        InRange();
        if(canPickUp && Input.GetKeyDown(KeyCode.E)) {
            PickUp();
            flashlight flash = flashlightObject.GetComponent<flashlight>();
            flash.SetBatterylife(amount);
        }
    }

    public void InRange ()
    {
        float playerDistance = Vector3.Distance(player.position, transform.position);
        if (playerDistance <= radius)
        {
            canPickUp = true;
        }
        else
        {
            canPickUp = false;
        }
    }

    private void PickUp() {
        Destroy(gameObject);
    }
}
