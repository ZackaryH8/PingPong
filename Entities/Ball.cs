using System.Numerics;
using PingPong.Systems;
using PingPong.Utilities;
using Raylib_CsLo;

namespace PingPong.Entities
{
    public class Ball
    {
        public Vector2 Position;
        public float Radius;
        public Vector2 Velocity = new Vector2(-3, 0);
        public Color Color;

        public Ball(Vector2 position, float radius, Color color)
        {
            Position = position;
            Radius = radius;
            Color = color;
        }

        // Collides with paddle
        public bool CollidesWithPaddle(Paddle paddle)
        {
            // Check if ball is inside paddle
            if (Position.X + Radius >= paddle.Position.X && Position.X - Radius <= paddle.Position.X + paddle.Size.X)
            {
                if (Position.Y + Radius >= paddle.Position.Y && Position.Y - Radius <= paddle.Position.Y + paddle.Size.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckScreenXCollision()
        {
            return Position.X < 0 || Position.X > Raylib.GetScreenWidth();
        }

        public bool CheckScreenTopCollision()
        {
            return Position.Y < Radius;
        }

        public bool CheckScreenBottomCollision()
        {
            return Position.Y > Raylib.GetScreenHeight() - Radius;
        }

        // Check if the ball has collided with the top or bottom of the screen
        public bool CollidesWithScreen()
        {
            return Position.Y + Radius <= 0 || Position.Y + Radius >= Raylib.GetScreenHeight();
        }

        public void InvertXVelocity()
        {
            Velocity.X *= -1;
        }

        public void InvertYVelocity()
        {
            Velocity.Y *= -1;
        }

        public void Draw()
        {
            // Start shader mode
            Raylib.BeginShaderMode(ShaderManager.Instance.GetShader("radialGradient"));

            // Draw the circle
            Raylib.DrawCircle((int)Position.X, (int)Position.Y, Radius, Color);

            // Draw the shader
            DrawShader();

            // End shader mode
            Raylib.EndShaderMode();
        }

        private void DrawShader()
        {
            // Get shader
            Shader shader = ShaderManager.Instance.GetShader("radialGradient");

            // Set shader values
            int centerLoc = Raylib.GetShaderLocation(shader, "center");
            int colorLoc = Raylib.GetShaderLocation(shader, "color");
            int expandLoc = Raylib.GetShaderLocation(shader, "expand");
            int radiusLoc = Raylib.GetShaderLocation(shader, "radius");
            int windowHeightLoc = Raylib.GetShaderLocation(shader, "windowHeight");

            Shaders.SetValuePosition(shader, centerLoc, Position);
            Shaders.SetValueColor(shader, colorLoc, Color);
            Raylib.SetShaderValue(shader, expandLoc, 0.5f, ShaderUniformDataType.SHADER_UNIFORM_FLOAT);
            Raylib.SetShaderValue(shader, radiusLoc, 20f, ShaderUniformDataType.SHADER_UNIFORM_FLOAT);
            Raylib.SetShaderValue(shader, windowHeightLoc, (float)Raylib.GetScreenHeight(), ShaderUniformDataType.SHADER_UNIFORM_FLOAT);
        }

        public void Update()
        {
            // Draw the ball
            Draw();

            // Loop each paddle and check if the ball has collided with it
            foreach (var paddle in EntityManager<Paddle>.Instance.GetAll())
            {
                // Check if ball collides with paddle
                if (CollidesWithPaddle(paddle))
                {
                    // Play sound
                    AudioManager.Instance.PlayPaddleHitSound();

                    // If the ball hits the top part of the paddle it should go up at a 45 degree angle
                    if (Position.Y < paddle.Position.Y + paddle.Size.Y / 2)
                    {
                        Velocity.Y = -3;
                    }
                    // If the ball hits the middle part of the paddle it should go horizontally inv
                    else if (Position.Y > paddle.Position.Y + paddle.Size.Y / 2)
                    {
                        Velocity.Y = 3;
                    }
                    // If the ball hits the bottom part of the paddle it should go down at a 45 degree angle
                    else
                    {
                        Velocity.Y = 0;
                    }

                    InvertXVelocity();
                }

                // Check if ball collides with top of screen
                if (CheckScreenTopCollision() && Velocity.Y <= 0)
                {
                    AudioManager.Instance.PlayPaddleHitSound();
                    InvertYVelocity();
                }

                // Check if ball collides with bottom of screen
                if (CheckScreenBottomCollision() && Velocity.Y >= 0)
                {
                    AudioManager.Instance.PlayPaddleHitSound();
                    InvertYVelocity();
                }

            }

            Position = Position + Velocity;
        }
    }
}