using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    public Camera camera;
    public Spawner spawner;
    
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
            {   
                spawner.SphereMoveTo(GridField.CurrentPosition(hit.point));
                spawner.ChengSphere();
                
                
            }
            
        }

    }
}
