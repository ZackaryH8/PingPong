using System.Numerics;
using Raylib_CsLo;

namespace PingPong.Utilities
{
    // Get center of screen
    public static class Screen
    {
        public static Vector2 Center => new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
        public static int CenterX => Raylib.GetScreenWidth() / 2;
        public static int CenterY => Raylib.GetScreenHeight() / 2;

        public static int OffsetX(int offset) => Raylib.GetScreenWidth() - offset;
        public static int OffsetY(int offset) => Raylib.GetScreenHeight() - offset;
    }
}