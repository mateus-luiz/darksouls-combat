using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject weapon;
    public Transform armedPoint;
    public Transform retainPoint;

    [SerializeField]
    private bool armed;

    public void Update(){
        if(Input.GetButtonDown("Fire1") && !armed || Input.GetKeyDown(KeyCode.R)) SetArmed();
    }

    public void SetArmed()
    {
        armed = !armed;

        if(armed)
        {
            weapon.transform.position = armedPoint.position;
        }

        if(!armed)
        {
            weapon.transform.position = retainPoint.position;
        }
    }
}
