using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLife : PickUp
{
    // Start is called before the first frame update
    public override void PickMeUp()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().AddLife();
        Destroy(gameObject);
    }
}
