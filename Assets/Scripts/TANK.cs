namespace DefaultNamespace
{
    public enum Team
    {
        CAPTAIN,
        DRIVER,
        GUNNER,
        CHARGING,
        OPERATOR
    }
 
    public enum TankMemberStatus
    {
        OK,
        DEAD
    }
    
    public enum Ammunition
    {
        PIERCING,
        HIGH_EXPLOSIVE,
        
    }
    public enum Track
    {
        LEFT,
        RIGHT
    }
    public enum TankStatus
    {
        LIVE,
        DEAD
    }
    public enum Moving
    {
        FORWARD,
        BACK,
        LEFT,
        RIGHT,
        STAND
    }
 
    public class Bullet
    {
        public Ammunition type;
        public int count;
    }
 
    public class TankMember
    {
        public Team type;
        public TankMemberStatus status;
    }
    
    public class Gun
    {
        public int currentType = 1;
        public Bullet[] bullets;
        public int reloadSpeed = 150;
 
        public Gun()
        {
            bullets = new[]
            {
                new Bullet { type = Ammunition.PIERCING, count = 10 },
                new Bullet { type = Ammunition.HIGH_EXPLOSIVE, count = 15 }
            };
 
        }
 
        private void ChangeBulletType(int type)
        {
            currentType = type;
        }
        
        private void Shot(Ammunition type)
        {
            bullets[currentType].count--;
        }
        
        private void Reload()
        {
            int i = 0;
            do
            {
                i++;
            } while (i <= reloadSpeed);
        }
    }
    
    public class Tower
    {
        //public Quaternion rotation;
        public Gun gun;
        public int turnSpeed = 15;
    }
    
    public class Engine
    {
        public Moving direction;
        public int speed = 45;
    }
    
    public class FuelBarrel
    {
        public int volume = 400;
 
        public bool IsOk()
        {
            return volume > 0;
        }
    }
    
    public class Tank
    {
        //public Vector3 position; //(0, 0, 0)
        public TankStatus status;
        public TankMember[] members;
        private Engine _engine;
        private FuelBarrel _fuelBarrel;
        public Tower tower;
        public int health = 100;
        public float moveSpeed;
 
 
        public void Init()
        {
        }
 
        //direction (0, 0, 1) || FORWARD
        //public void Move(Vector3 direction)
        //{
            //position += direction * _engine.speed;
        //}
 
        public void TowerRotate(float angle)
        {
            //tower.SetRotationAngle(angle);
        }
        
        
        public bool CanMove()
        {
            //if (!_engine.IsOk())
                //return false;
 
            if (!_fuelBarrel.IsOk())
                return false;
 
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].type == Team.DRIVER)
                {
                    if (members[i].status == TankMemberStatus.DEAD)
                        return false;
                    else
                        return true;
                }
            }
 
            return false;
        }
 
        public bool CanShoot()
        {
            /*return !members.Any(member =>
                member.type == Team.GUNNER ||
                member.type == Team.CHARGING &&
                member.status == TankMemberStatus.DEAD);*/
 
            /*return members.All(member =>
                member.type == Team.GUNNER ||
                member.type == Team.CHARGING &&
                member.status == TankMemberStatus.OK);*/
            
            bool isGunnerFound = false;
            bool isChargerFound = false;
            
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].type == Team.GUNNER)
                {
                    isGunnerFound = true;
                }
                
                if (members[i].type == Team.CHARGING)
                {
                    isChargerFound = true;
                }
            }
            
            if (!isChargerFound || !isGunnerFound)
            {
                return false;
            }
            
            
            //[commander, charging, radist, gunner]
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].type == Team.GUNNER ||
                    members[i].type == Team.CHARGING)
                {
                    if (members[i].status == TankMemberStatus.DEAD)
                        return false;
                }
            }
 
            return true;
        }
        
        public void SetDamage(int count)
        {
            health -= count;
            if (health <= 0)
            {
                status = TankStatus.DEAD;
            }
        }
 
 
 
 
        public class Player
        {
            public Tank tank;
            
 
            public void KeyWPressed()
            {
                //tank.Move(new Vector3(0, 0, 1));
            }
            
        }
    }
}