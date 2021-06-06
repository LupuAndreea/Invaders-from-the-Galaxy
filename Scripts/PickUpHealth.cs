using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : PickUp
{
    // Start is called before the first frame update
   public override void PickMeUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().AddHealth();
        Destroy(gameObject);
    }
}
