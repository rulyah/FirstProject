using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SphereController pref;
    public SphereController prefab;
    public SphereController prefab1;
    private SphereController newFirstSphere;
    private SphereController newSecondSphere;
    private SphereController newThirdSphere;



    public List<SphereController> queue;
    

    public void SphereMoveTo(Vector2Int coordinatu)
    {
        queue[0].MoveTo(coordinatu);
    }
    
    
    
    
    public void ChengSphere()
    {
        SphereController first = queue[0];
        queue.Remove(first);
        queue.Add(first);
    }
    
    void Start()
    {
        
        var sphere = Instantiate(pref);
        sphere.gameObject.SetActive(true);
        newFirstSphere = sphere;
        newFirstSphere.unitStats.speed = 3;
        queue.Add(newFirstSphere);
        


            
        sphere = Instantiate(prefab);
        sphere.gameObject.SetActive(true);
        newSecondSphere = sphere;
        newSecondSphere.unitStats.speed = 2;
        queue.Add(newSecondSphere);
        
        
        
        sphere = Instantiate(prefab1);
        sphere.gameObject.SetActive(true);
        newThirdSphere = sphere;
        newThirdSphere.unitStats.speed = 4;
        queue.Add(newThirdSphere);
        

    }

}
