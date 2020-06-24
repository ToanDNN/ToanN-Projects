using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashlight : MonoBehaviour
{
    public Transform flashlightPoint;
    public float offset;
    public LayerMask hitOnly;
    public float distance;
    public GameObject lightRender;

    public float maxBatteryLife;
    public float currentBatteryLife;
    public float batteryDrain;
    public int damage;
    public BatteryLifeScript batteryLife;

    //on start sets the value of current battery life
    void Start() {
        currentBatteryLife = maxBatteryLife;
        batteryLife.SetMaxBatteryLife(maxBatteryLife);
    }

    //will constantly check for an update
    void Update()
    {
        //if left mouse button is held down and current battery life is > 0 call shoot function and decrease battery life. Also controls the light object
        if(Input.GetButton("Fire1") && currentBatteryLife > 0.1f) {
            Shoot();
            currentBatteryLife -= batteryDrain;
            batteryLife.SetBatteryLife(currentBatteryLife);
            if(currentBatteryLife <= 0.1f) {
                Debug.Log("Out of battery");
            }
            lightRender.SetActive(true);
        }
        else {
            lightRender.SetActive(false);
        }
    }
    //shoot function uses a raycast based on the fire point and the mouse position in the world space
    void Shoot() {
        Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 flashlightPointPosition = new Vector2 (flashlightPoint.position.x, flashlightPoint.position.y);
        RaycastHit2D hitInfo = Physics2D.Raycast(flashlightPointPosition, mousePosition - flashlightPointPosition, distance, hitOnly);
        Debug.DrawLine(flashlightPointPosition, mousePosition);

        if(hitInfo) {
            //Debug.Log(hitInfo.transform.name);
            BasicEnemy mob = hitInfo.transform.GetComponent<BasicEnemy>();
            if(mob != null) {
                mob.TakeDamage(damage);
            }
        }
    }
    //public function that will be referenced by other scripts
    public void SetBatterylife(float val) {
        if((currentBatteryLife + val) <= maxBatteryLife) {
            currentBatteryLife += val;
            batteryLife.SetBatteryLife(currentBatteryLife);
        } else if((currentBatteryLife + val) > maxBatteryLife) {
            currentBatteryLife = maxBatteryLife;
            batteryLife.SetBatteryLife(currentBatteryLife);
        }
    }
}
