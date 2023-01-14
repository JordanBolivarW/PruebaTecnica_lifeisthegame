using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPoint : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    public GameObject target;
    public Vector3 aimPoint;
    public static AimPoint aimPointScript; 

    private void Awake()
    {
        if (aimPointScript == null)
            aimPointScript = this;
        else
            Destroy(this);
    }

    void Update()
    {
        RaycastHit hit;
        aimPoint = Vector3.zero;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10000f, layerMask, QueryTriggerInteraction.Ignore))
        {
            target = hit.transform.gameObject;
            aimPoint = hit.point;
        }
        else
        {
            target = null;
            aimPoint = transform.forward * 10000f;
        }
    }
}
