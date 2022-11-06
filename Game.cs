using System.Numerics;
using PingPong.Entities;
using PingPong.Systems;
using PingPong.Utilities;
using Raylib_CsLo;

namespace PingPong
{
    internal class Game
    {
        public static int WindowWidth = 800;
        public static int WindowHeight = 600;
        public static bool GameRunning = true;

        static void Main(string[] args)
        {
            Console.WriteLine(WindowHeight);
            Console.WriteLine(WindowWidth);


            // Initialize Raylib
            Raylib.InitWindow(WindowWidth, WindowHeight, "Pong!");
            Raylib.SetTargetFPS(60);
            Raylib.InitAudioDevice();

            // Initialize shaders
            ShaderManager.Instance.Initialize();

            // Initialize Entities
            var paddleLeft = EntityManager<Paddle>.Instance.Add(new Paddle(new Vector2(10, Screen.CenterY - 100 / 2), new Vector2(10, 100), Raylib.RED));
            var ball = EntityManager<Ball>.Instance.Add(new Ball(Screen.Center, 15f, Raylib.BLUE));
            var paddleRight = EntityManager<Paddle>.Instance.Add(new Paddle(new Vector2(Screen.OffsetX(20), 10), new Vector2(10, 100), Raylib.BLUE, true));

            // Initialize Game
            Update();
        }

        public static void Update()
        {
            // Run the game loop unless the window should close
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.BLACK);

                // Draw all entities
                EntityManager<Paddle>.Instance.Draw();

                // Update all entities
                EntityManager<Paddle>.Instance.Update();
                EntityManager<Ball>.Instance.Update();


                // Update input manager
                // InputManager.Instance.Update();
                
                Raylib.EndDrawing();
            }

            AudioManager.Instance.Dispose();

            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }
    }
}