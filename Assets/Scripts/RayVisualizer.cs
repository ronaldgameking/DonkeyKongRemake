using UnityEngine;

public class RayVisualizer
{
    public static void DrawRay2D(Vector2 start, Vector2 direction, float distance)
    {
        Debug.DrawLine(start, start + direction * distance, Color.green);
    }
    public static void DrawRay2D(Vector2 start, Vector2 direction, float distance, Color color)
    {
        Debug.DrawLine(start, start + direction * distance, color);
    }
}

