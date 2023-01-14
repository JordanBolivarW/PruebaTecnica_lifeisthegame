using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAmmunition : MonoBehaviour
{
    List<GameObject> objList = new List<GameObject>();
    float timer = 0;
    Vector3 acceleration, velocity;

    void Start()
    {
        StartCoroutine(Attract());
    }

    IEnumerator Attract()
    {
        yield return new WaitForSeconds(1f);
        Still();
        ObjToAttract();
        yield return new WaitForSeconds(0.2f);

        while (timer < 3.7f)
        {
            for (int i = 0; i < objList.Count; i++)
            {
                objList[i].GetComponent<Rigidbody>().velocity += (transform.position - objList[i].transform.position) * Time.deltaTime * 5f;
            }
            yield return null;
            timer += Time.deltaTime;
        }
        for (int i = 0; i < objList.Count; i++)
        {
            objList[i].GetComponent<Rigidbody>().useGravity = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Still();
    }

    void Still()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<TrailRenderer>().Clear();
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    void ObjToAttract()
    {
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
        gameObject.GetComponent<SphereCollider>().radius = 10f;
        gameObject.GetComponent<Collider>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!objList.Contains(other.gameObject) && other.gameObject.layer == 7)
        {
            objList.Add(other.gameObject);
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 1.5f, 0);
            other.gameObject.GetComponent<Rigidbody>().velocity = other.transform.forward;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
