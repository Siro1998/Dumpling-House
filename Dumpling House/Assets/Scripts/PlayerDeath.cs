using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    SpriteRenderer sprite;
    //GameObject[] hearts;

    

    int life = 3;
   
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Transform[] hearts = GetComponentsInChildren<Transform>();
        List<GameObject> heartsObjects = new List<GameObject>();
        foreach (Transform child in hearts)
        { 
            heartsObjects.Add(child.gameObject);
        }
        // hearts[0] = this.gameObject.transform.GetChild(0).gameObject;
        // hearts[1] = this.gameObject.transform.GetChild(1).gameObject;
        // hearts[2] = this.gameObject.transform.GetChild(2).gameObject;
    }
    
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Explosion"))
        {
            StartCoroutine(flash());
            Debug.Log ("dead");
            //Destroy(heartsObject[life-1]);
            life--;
            // if(life == 0){

            // }
        }
    }

    IEnumerator flash()
    {
        for(int i = 0; i<3;i++){
            sprite.color = new Color (.2f,.2f,.2f,1);
            yield return new WaitForSeconds(.1f);
            sprite.color = new Color (1,1,1,1);
            yield return new WaitForSeconds(.1f);
        }  
    }
}
