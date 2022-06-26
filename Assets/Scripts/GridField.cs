using UnityEngine;

public class GridField : MonoBehaviour
{
    public LineRenderer prefab;
    public int x = 18;
    public int y = 12;

    public static Vector3 GetPosition(int xPosition, int yPosition)
    {
        return new Vector3(xPosition - 0.5f, 0.1f,yPosition - 0.5f);
    }

    public static Vector2Int CurrentPosition(Vector3 pos)
    {
        int xPos = Mathf.CeilToInt(pos.x);
        int yPos = (int)Mathf.Ceil(pos.z);
        return new Vector2Int(xPos, yPos);
    }

    public bool CanMoveLeft(Vector2Int position)
    {
        if (position.x - 1 < 0)
        {
            return false;
        }
        return true;
    }
    public bool CanMoveRight(Vector2Int position)
    {
        if (position.x + 1 > x + 1)
        {
            return false;
        }
        return true;
    }
    public bool CanMoveUp(Vector2Int position)
    {
        if (position.y + 1 > y + 1)
        {
            return false;
        }
        return true;
    }
    public bool CanMoveDown(Vector2Int position)
    {
        if (position.y - 1 < 0)
        {
            return false;
        }
        return true;
    }
    
    public Vector2Int GridBorderUp(Vector2Int border)
    {
        bool upBorder = CanMoveUp(border);
        if (upBorder == false)
        {
            return new Vector2Int(border.x, 1);
        }
        return border;
    }
    public Vector2Int GridBorderDown(Vector2Int border)
    {
        bool downBorder = CanMoveDown(border);
        if (downBorder == false)
        {
            return new Vector2Int(border.x, y);
        }
        return border;
    }
    
    public Vector2Int GridBorderLeft(Vector2Int border)
    {
        bool downBorder = CanMoveLeft(border);
        if (downBorder == false)
        {
            return new Vector2Int(x, border.y);
        }
        return border;
    }
    public Vector2Int GridBorderRight(Vector2Int border)
    {
        bool downBorder = CanMoveRight(border);
        if (downBorder == false)
        {
            return new Vector2Int(1, border.y);
        }
        return border;
    }
    
    void Start()
    {
        for(int i = 0; i <= 18; i++)
        {
            var line = Instantiate(prefab);
            line.SetPosition(0, new Vector3(i, 0.1f, 0));
            line.SetPosition(1, new Vector3(i, 0.1f, 12));
            
            line.gameObject.SetActive(true);
        }
        for(int i = 0; i <= 12; i++)
        {
            var line = Instantiate(prefab);
            line.SetPosition(0, new Vector3(0, 0.1f, i));
            line.SetPosition(1, new Vector3(18, 0.1f, i));
            line.gameObject.SetActive(true);
        }

    }

        
}
