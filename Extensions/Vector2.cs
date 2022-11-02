using System.Numerics;

namespace PingPong.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 Add(this Vector2 vector, Vector2 other)
        {
            return new Vector2(vector.X + other.X, vector.Y + other.Y);
        }
    }
}