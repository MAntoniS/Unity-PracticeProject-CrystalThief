using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door_0 : MonoBehaviour
{

    [SerializeField] private bool canEnter;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        canEnter = false;
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canEnter)
        {
            StartCoroutine((StartAnotherLevel()));
        }
    }
    public void EnterTheTomb()
    {
        canEnter = true;
        animator.SetBool("CanEnter",true);
    }

    private IEnumerator StartAnotherLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
            
}
