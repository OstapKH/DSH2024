using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generasuelo3 : MonoBehaviour
{
    public GameObject lastGround, groundPrefab, newGround2Object;

    private int groundDirection;

     private void Start1(){
        RandomGround1();
    }

    private void RandomGround1(){
        for (int i = 0; i < 5; i++)
        {
            newGround2();
        }    
    }

      public void RandonGround22()
    {
        for (int i = 0; i < 1; i++)
        {
            newGround2();
        }    
    }


     private void newGround2(){
        groundDirection = Random.Range(0, 2);

        if (groundDirection == 0)
        {
            newGround2Object = Instantiate(groundPrefab,
                new Vector3(lastGround.transform.position.x - 1f, lastGround.transform.position.y,
                    lastGround.transform.position.z), Quaternion.identity);
            lastGround = newGround2Object;
        }
        else
        {
            newGround2Object = Instantiate(groundPrefab,
                new Vector3(lastGround.transform.position.x, lastGround.transform.position.y,
                    lastGround.transform.position.z + 1f), Quaternion.identity);
            lastGround = newGround2Object;
        }
    }
}
