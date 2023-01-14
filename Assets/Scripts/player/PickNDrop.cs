using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickNDrop : MonoBehaviour
{
    AimPoint aimPoint;
    GameObject target, inHand;


    private void Start()
    {
        aimPoint = AimPoint.aimPointScript;
    }
    private void Update()
    {
        target = aimPoint.target;
        if ((aimPoint.aimPoint - transform.position).magnitude < 3)
        {
            //e to pick up
            if (Input.GetKeyDown(KeyCode.E) && target.layer == 7)
                PickUp(target);
        }
        if (Input.GetKeyDown(KeyCode.G) && inHand != null) 
        {
            Drop();
        }
    }

    void PickUp(GameObject target_)
    {
        if (inHand != null)
            Drop();

        inHand = target_;
        inHand.GetComponent<Collider>().enabled = false;
        inHand.GetComponent<Rigidbody>().isKinematic = true;
        inHand.GetComponent<Rigidbody>().useGravity = false;

        inHand.transform.SetParent(transform.GetChild(0).GetChild(0));
        inHand.transform.localPosition = Vector3.zero;
        inHand.transform.localRotation = Quaternion.Euler(Vector3.zero);
        inHand.GetComponent<Gun>().enabled = true;
    }
    void Drop()
    {
        inHand.GetComponent<Gun>().enabled = false;
        inHand.GetComponent<Collider>().enabled = true;
        inHand.GetComponent<Rigidbody>().isKinematic = false;
        inHand.GetComponent<Rigidbody>().useGravity = true;
        inHand.transform.SetParent(null);
        inHand = null;
    }
}
