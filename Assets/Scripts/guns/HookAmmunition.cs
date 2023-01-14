using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAmmunition : MonoBehaviour
{
    GameObject target;
    Transform playerHands;
    LineRenderer lineRenderer;

    private void Start()
    {
        playerHands = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(0);
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }
    private void Update()
    {
        lineRenderer.SetPosition(0, playerHands.GetChild(0).GetChild(1).position);
        lineRenderer.SetPosition(1, transform.position);
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerHands.GetChild(0).GetChild(1).position + playerHands.transform.GetChild(0).GetChild(1).forward * 0.5f, 20 * Time.deltaTime);
            if (playerHands.GetChild(0).GetChild(1).position + playerHands.transform.GetChild(0).GetChild(1).forward * 0.5f == transform.position)
                StartCoroutine(Drop());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject.GetComponent<Rigidbody>());
            target = collision.gameObject;  
            Destroy(target.GetComponent<Rigidbody>());
            target.transform.parent = transform;
        }
    }
    IEnumerator Drop()
    {
        yield return new WaitForSeconds(1);

        target.AddComponent<Rigidbody>();
        target.transform.parent = null;
        target = null;

        yield return null;

        Destroy(gameObject);
    }
}
