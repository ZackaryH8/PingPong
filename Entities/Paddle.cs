using System.Numerics;
using Raylib_CsLo;

namespace PingPong.Entities
{
    public class Paddle
    {
        public int Speed = 10;
        public Vector2 Position;
        public Vector2 Size;
        public Vector2 Velocity;
        public Color Color;
        public bool IsNetwork;


        public Paddle(Vector2 position, Vector2 size, Color color, bool isNetwork = false)
        {
            Position = position;
            Size = size;
            Color = color;
            IsNetwork = isNetwork;
        }

        
        public void CheckControls()
        {
                // Create a new position vector
            Vector2 newPosition = Position;
            // Check if paddle is network
            if (IsNetwork) {
                            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                newPosition.Y -= Speed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                newPosition.Y += Speed;
            }
            };



            // Check if key is pressed
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                newPosition.Y -= Speed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                newPosition.Y += Speed;
            }
            
            // Check if new position is valid (not outside of screen)
            if (newPosition.Y >= 0 && newPosition.Y <= Raylib.GetScreenHeight() - Size.Y)
            {
                // Set the new position
                Position = newPosition;
            }
        }

        public void Update()
        {
            CheckControls();
        }

        public void Draw()
        {
            Raylib.DrawRectangleV(Position, Size, Color);
        }
    }
}