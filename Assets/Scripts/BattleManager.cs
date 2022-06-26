using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Person one;
    public Person two;
    
    


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            HitEnemy(CalcDamage());
            Debug.Log($"Battle is start. The health of {two.name} is {two.health.ToString()}");
        }
    }
    public int CalcDamage()
    { 
        return one.stats.attack - two.stats.defence;
    }

    public void HitEnemy(int value)
    {
        two.health -= value;
        Debug.Log("The damage is " + value);
        Debug.Log("Health is " + two.health);
        if (two.health <= 0)
        {
            Debug.Log("The second char lost");
        }
    }
    
    
}
