using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    DistanceJoint2D distanceJoint2D;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;

    public LineRenderer line;

    public float step = 0.2f;

    private Player player;

	void Start () {
        distanceJoint2D = GetComponent<DistanceJoint2D>();
        player = GetComponent<Player>();
        distanceJoint2D.enabled = false;

        line.enabled = false;
    }

	void Update () {

        line.SetPosition(0, transform.position);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)

            {
                distanceJoint2D.enabled = true;
                Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
                connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;
                distanceJoint2D.connectedAnchor = connectPoint;

                distanceJoint2D.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                distanceJoint2D.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
                player.connected = true;
            }
        }
        if (distanceJoint2D.enabled)
        {
            line.SetPosition(1, distanceJoint2D.connectedBody.transform.TransformPoint(distanceJoint2D.connectedAnchor));
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            distanceJoint2D.enabled = false;
            line.enabled = false;
            player.connected = false;
        }
    }
}