using UnityEngine;

public class SphereController : MonoBehaviour
{
    public UnitStats unitStats;
    public Vector3 positionToMove;
    public float moveSpeed = 0.2f;
    public Vector2Int position;

    
    
    public void MoveTo(Vector2Int pos)
    {
        positionToMove = GridField.GetPosition(pos.x, pos.y);
        position = pos;
    }

    

    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, positionToMove);
        
        
        if (distance <= unitStats.speed && distance > 0.1f)
        {
            Vector3 direction = Vector3.Normalize(positionToMove - transform.position);
            transform.position += direction * moveSpeed;
        }

    }
}
