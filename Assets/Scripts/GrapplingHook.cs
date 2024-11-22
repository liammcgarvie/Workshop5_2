using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer rope;
    [SerializeField] private Camera cam;
    
    private Vector3 grapplePoint;
    private DistanceJoint2D joint;
    
    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false;
    }
    
    void Update()
    {
        // Convert mouse position to world space
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            cam.nearClipPlane // Use the near clipping plane distance
        ));

        // Start Grapple
        if (Input.GetMouseButtonDown(0))
        {
            // Calculate direction from player to mouse
            Vector2 direction = (mouseWorldPos - transform.position).normalized;

            // Perform raycast in the calculated direction
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, grappleLayer);

            // Debug the ray to visualize it in the Scene view
            Debug.DrawRay(transform.position, direction * 10, Color.red, 2f);

            if (hit.collider)
            {
                grapplePoint = hit.point;
                joint.connectedAnchor = grapplePoint;
                joint.distance = Vector2.Distance(transform.position, grapplePoint);
                joint.enabled = true;

                rope.enabled = true;
                rope.SetPosition(0, grapplePoint);  // Anchor end point
                rope.SetPosition(1, transform.position); // Player's position
            }
        }

        // End Grapple
        if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            rope.enabled = false;
        }

        // Update Rope's Player End Position
        if (rope.enabled)
        {
            rope.SetPosition(1, transform.position);
        }
    }

}
