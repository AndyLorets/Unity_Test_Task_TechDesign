using UnityEngine;

public class GizmosDrawing : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Color _gizmosColor;
    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;
        switch (_collider)
        {
            case null:
                Vector3 notOffset = Vector3.one;
                Gizmos.DrawWireCube(transform.position, notOffset);
                break;
            case BoxCollider2D:
                BoxCollider2D boxColl = _collider.GetComponent<BoxCollider2D>();
                Gizmos.DrawCube(boxColl.bounds.center, boxColl.bounds.size);
                break;
            case CircleCollider2D:
                CircleCollider2D circleColl = _collider.GetComponent<CircleCollider2D>();
                Gizmos.DrawSphere(circleColl.bounds.center, circleColl.radius);
                break;
            case EdgeCollider2D:
                EdgeCollider2D edgeleColl = _collider.GetComponent<EdgeCollider2D>();
                Vector3 edgeleOffset = edgeleColl.transform.position; 
                Vector2 [] edgePoints = edgeleColl.points;
                for (int i = 0; i < edgePoints.Length - 1; i++)
                {
                    Gizmos.DrawLine(new Vector3(edgePoints[i].x + edgeleOffset.x, edgePoints[i].y + edgeleOffset.y), new Vector3(edgePoints[i + 1].x + edgeleOffset.x, edgePoints[i + 1].y + edgeleOffset.y));
                }
                break;
        }

    }
}
