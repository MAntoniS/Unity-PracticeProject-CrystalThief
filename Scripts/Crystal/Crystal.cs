using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<Character_Abilities_Controller>().AddCrystal();
                Debug.Log("You got a Crystal!!");
                Destroy(this.gameObject);
            }
        }
    
}
