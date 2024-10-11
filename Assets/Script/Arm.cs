using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;




public class Arm : MonoBehaviour
{
    public Transform ikTarget;
    public Transform handCollider;
    public Transform destination;
    public Transform root;
    public Transform cam;

    public float speed = 5;
    public float radius;
    public float armExt = 0.8f;
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

        destination.position += ((cam.right * hForce) + (cam.up * vForce)) * Time.deltaTime * speed;
        destination.position -= root.position;
        destination.position = destination.position.normalized * (radius * armExt);
        destination.position += root.position;

        handCollider.GetComponent<Rigidbody>().AddForce((destination.position - handCollider.position) * speed);

        ikTarget.position = handCollider.position;
    }
}
/*
    public Transform target;
    public Transform destinationPos;
    public Transform basePos;
    public Transform camera;
    public float speed = 5;
    public float springForce = 0.05f;
    public float damp = 0.95f;
    float radius;
    float radiusScale;
    Vector3 targetVel;
    // Start is called before the first frame update
    void Start()
    {
        radius = Vector3.Distance(basePos.position, target.position) * .98f;
        destinationPos.position = target.position;
    }

void Update()
{

    Vector3 overshootPos = destinationPos.position;

    radiusScale = .7f + (Input.GetAxis("Action_Grab") * .2f);

    Vector3 translation = new Vector3(Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")) * speed;
    translation *= Time.deltaTime;
    destinationPos.Translate(translation);

    destinationPos.position -= basePos.position;
    destinationPos.position = Vector3.Normalize(destinationPos.position);
    destinationPos.position *= radius * radiusScale;
    destinationPos.position += basePos.position;



    Vector3 force = springForce * (destinationPos.position - target.position);
    targetVel += force * Time.deltaTime;
    targetVel *= Mathf.Pow(damp, Time.deltaTime);

    target.position += targetVel;
}
*/