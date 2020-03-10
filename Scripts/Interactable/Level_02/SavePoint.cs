using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer renderer;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if collision == null
        //check if tag == player
        //Change the sprite
        renderer.sprite = sprites[1];
        //Make a save point
    }
}
