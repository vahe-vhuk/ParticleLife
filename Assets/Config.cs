using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    static public float radius = 50f;
    static public int w = 3;
    static public int width = 1097;
    static public int h = 3;
    static public int height = 567;
    static public int border = 50;
    
    public static Dictionary<string, float> conf = new Dictionary<string, float>()
    {
        {"RR", 0},
        {"RB", 0},
        {"RG", 0},
        {"BR", 0},
        {"BB", 0},
        {"BG", 0},
        {"GR", 0},
        {"GB", 0},
        {"GG", 0},
    };

    private static float xEqu(Vector2 pos, Vector2 dir, float y)
    {
        return (dir.x * (y - pos.y) + dir.y * pos.x) / dir.y;
    }
    
    private static float yEqu(Vector2 pos, Vector2 dir, float x)
    {
        return (dir.y * (x - pos.x) + dir.x * pos.y) / dir.x;
    }

    // private Vector2 rotate(Vector2 dir, int deg)
    // {
    //     
    // }

    public static Vector3 Direction(Vector2 pos, Vector2 dir)
    {
        
        float temp = xEqu(pos, dir, h);
        if (temp >= w && temp <= width && Vector2.Distance(pos, new Vector2(temp, h)) < border)
        {
            return -dir;
        }
        
        temp = xEqu(pos, dir, height);
        if (temp >= w && temp <= width)
        {
            if (Vector2.Distance(pos, new Vector2(temp, height)) < border)
            {
                return -dir;
            }
        }
        
        temp = yEqu(pos, dir, w);
        if (temp >= h && temp <= height)
        {
            if (Vector2.Distance(pos, new Vector2(w, temp)) < border)
            {
                return -dir;
            }
        }
        
        temp = yEqu(pos, dir, width);
        if (temp >= h && temp <= height)
        {
            if (Vector2.Distance(pos, new Vector2(width, temp)) < border)
            {
                return -dir;
            }
        }
		

        return dir;
    }

    public static Vector3 Position(Vector3 pos)
    {
        if (pos.x < w - 20)
        {
            pos.x = width + 20;
        }

        if (pos.x > width + 20)
        {
            pos.x = w - 20;
        }

        if (pos.y < h - 20)
        {
            pos.y = height + 20;
        }

        if (pos.y > height + 20)
        {
            pos.y = h - 20;
        }

        return pos;
    }
    
}








