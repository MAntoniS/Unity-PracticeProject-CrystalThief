using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad_0 : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField]private Door_0 door;

  
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if not null
        renderer.sprite = sprites[1];
        door.EnterTheTomb();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        renderer.sprite = sprites[0];
    }
}
