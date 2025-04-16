using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{

    public float timer = 5f;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayExplosion(timer));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destructible")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "CanFall")
        {
            collision.transform.position += Vector3.down * 5f;
        }
        if (collision.gameObject.tag != "Player")
        {
            StopAllCoroutines();
            Explode();
        }

    }

    IEnumerator DelayExplosion(float Timer)
    {
        yield return new WaitForSeconds(timer);

        Explode();
    }

    void Explode()
    {
        if (explosion != null)
        {
            GameObject NewExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            NewExplosion.SetActive(true);
            Destroy(NewExplosion, 1f);
        }
        Destroy(gameObject);
    }
        
    
}
