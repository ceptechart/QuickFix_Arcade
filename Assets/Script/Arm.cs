using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;




public class Arm : MonoBehaviour
{
    public Transform ikTarget;
    public Transform ikHint;
    public Transform handCollider;
    public Transform destination;
    public Transform root;
    public Transform cam;

    public float speed = 5;
    public float radius;
    public float armExt = 0.8f;

    Vector3 hintTargetPos;
    public Transform hintTargetPosDebug;

    Grab Hili = null;
    Grab grab = null;

    // Start is called before the first frame update
    void Start()
    {
        radius = (ikTarget.position - root.position).magnitude;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hForce = Input.GetAxis("Horizontal");
        float vForce = Input.GetAxis("Vertical");

        armExt = (0.7f + (0.25f * Input.GetAxis("Action_Grab")));

        destination.position += ((cam.right * hForce) + (cam.up * vForce)) * Time.deltaTime * speed;
        destination.position -= root.position;
        destination.position = destination.position.normalized * (radius * armExt);
        destination.position += root.position;
        destination.position = new Vector3(destination.position.x, Mathf.Max(-0.2f, destination.position.y), destination.position.z);


        float destDist = (destination.position - root.position).magnitude;
        float handDist = (handCollider.position - root.position).magnitude;
        if (destDist - handDist > 0.5)
        {
            handCollider.GetComponent<Rigidbody>().AddForce((destination.position - handCollider.position) * speed * 5);
        } else
        {
            handCollider.GetComponent<Rigidbody>().AddForce((destination.position - handCollider.position) * speed);
        }
        

        ikTarget.position = handCollider.position;

        if ((ikTarget.position - root.position).magnitude > radius * 0.98f)
        {
            ikTarget.position -= root.position;
            ikTarget.position = ikTarget.position.normalized;
            ikTarget.position *= 0.98f * radius;
            ikTarget.position += root.position;
            handCollider.position = ikTarget.position;
            handCollider.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        int rcLayerMask = 1 << 3;
        RaycastHit hit;
        if (Physics.Raycast(root.position, (handCollider.position-root.position).normalized, out hit, radius, rcLayerMask))
        {
            Debug.DrawRay(root.position, (handCollider.position - root.position).normalized * hit.distance, Color.yellow);
            Grab gc = hit.transform.gameObject.GetComponent<Grab>();
            if (gc != null)
            {
                Hili = gc.highlight();
            }
        } else
        {
            Debug.DrawRay(root.position, (handCollider.position - root.position).normalized * radius, Color.white);
            if (Hili != null)
            {
                Hili.unhighlight();
                Hili = null;
            }
        }

        if (Hili && (Input.GetAxis("Action_Grab") > 0.2f))
        {
            grab = Hili.grab(handCollider);
        }
        if (grab && (Input.GetAxis("Action_Grab") < 0.2f))
        {
            print("test");
            grab.letgo();
        }



        hintTargetPos = (destination.position);
        hintTargetPos.y = 0;
        hintTargetPos.Normalize();
        hintTargetPos = Quaternion.AngleAxis(45, Vector3.up) * hintTargetPos;
        hintTargetPos *= 5f;
        ikHint.position = hintTargetPos;
    }
}