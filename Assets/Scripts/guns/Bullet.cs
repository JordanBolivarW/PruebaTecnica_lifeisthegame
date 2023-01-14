using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float lifeTime;
    void Start()
    {
        StartCoroutine(autoDestroy());
    }

    IEnumerator autoDestroy()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
        
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<TrailRenderer>().Clear();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        
    }
}
