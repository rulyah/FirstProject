
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class RPGChar : MonoBehaviour
    {
        public Person Rulya;
        public Person Rusya;

        public BattleManager battleManager;


        private void Start()
        {
            Rulya = new Person("Rulya-True");
            Rulya.AddExperience(3000);
            Rusya = new Person("SantaClaus");
            Rusya.AddExperience(71000);

            battleManager.one = Rulya;
            battleManager.two = Rusya;
            

            //Debug.Log("Lvl Rulya is : " + Rulya.lvl.ToString());
            //Debug.Log("Lvl Rusya is : " + Rusya.lvl.ToString());

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Rusya.stats.TryIncreaseDefence();
                Debug.Log("Stats Rusya is " + Rusya.stats.defence);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rulya.stats.TryIncreaseAttack();
                Debug.Log("Stats Rulya is " + Rulya.stats.attack);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {

            }
        }
    }


    public class Person
    {
        public string name;
        public int lvl;
        public int health = 100;

        public PersonStats stats;
        public PersonExp exp;

        public Person(string nick)
        {
            name = nick;
            lvl = 1;

            stats = new PersonStats();
            exp = new PersonExp();
        }
        public void LvlUp()
        {
            lvl++;
            stats.freePoint++;
            CalcCoefficientExp();
            exp.experienceForLvlUp *= exp.coefficientExpForLvl;
        }

        public void CalcCoefficientExp()
        {
            exp.coefficientExpForLvl = Random.Range(2.3f, 2.5f);
        }
        public void AddExperience(int count)
        {
            exp.experience += count;
            while (exp.experience >= exp.experienceForLvlUp)
            {
                LvlUp();
            }
        }
    }
    public class PersonStats
    {
        public int attack;
        public int defence;
        public int freePoint;
        
        public bool TryIncreaseAttack()
        {
            if (freePoint <= 0)
                return false;
            attack++;
            freePoint--;
            return true;
        }
    
        public bool TryIncreaseDefence()
        {
            if (freePoint <= 0)
            {
                return false;
            }

            defence++;
            freePoint--;
            return true;
        }
    }
    public class PersonExp
    {
        public int experience;
        public double experienceForLvlUp = 200;
        public double coefficientExpForLvl;

    }
    
    
}
    
