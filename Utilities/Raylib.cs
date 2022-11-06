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

    public static class Shaders
    {
        // set shader position
        public static void SetValuePosition(Shader shader, int location, Vector2 position)
        {
            float[] positionArray = new float[2] { position.X, position.Y };

            Raylib.SetShaderValue(shader, location, positionArray, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
        }

        public static void SetValueColor(Shader shader, int location, Color color)
        {
            // Create a float array from the color
            float[] colorArray = new float[] { color.r / 255f, color.g / 255f, color.b / 255f, color.a / 255f };

            // Set shader value
            Raylib.SetShaderValue(shader, location, colorArray, ShaderUniformDataType.SHADER_UNIFORM_VEC4);
        }
    }
}