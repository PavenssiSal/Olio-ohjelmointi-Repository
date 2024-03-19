using System;
using System.Numerics;
using ZeroElectric.Vinculum;

namespace raylib_pohja
{
    class WindowTest
    {
        const int screen_width = 800;
        const int screen_height = 450;

        public WindowTest()
        {

        }

        public void Run()
        {
            Raylib.InitWindow(screen_width, screen_height, "Raylib");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }

        private void Draw()
        {
            //Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.YELLOW);

            // Piirrä ympyrä
            Raylib.DrawCircleLines(screen_width / 4, screen_height / 2, 30, Raylib.BLUE);

            // Piirrä neliö
            Raylib.DrawRectangle(screen_width / 2 - 30, screen_height / 2 - 30, 60, 60, Raylib.GREEN);

            // Piirrä kolmio
            Vector2[] points = new Vector2[3];
            points[0] = new Vector2(screen_width * 3 / 4, screen_height / 2 - 30);
            points[1] = new Vector2(screen_width * 3 / 4 + 60, screen_height / 2 + 30);
            points[2] = new Vector2(screen_width * 3 / 4 - 60, screen_height / 2 + 30);
            Raylib.DrawTriangleLines(points[0], points[1], points[2], Raylib.BLACK);

            //Piirrä Shakkilauta (i didnt do fucking shit)
            Color color1 = Raylib.LIGHTGRAY;
            Color color2 = Raylib.DARKGRAY;
            int tileSize = 30;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        Raylib.DrawRectangle(i * tileSize, j * tileSize, tileSize, tileSize, color1);
                    else
                        Raylib.DrawRectangle(i * tileSize, j * tileSize, tileSize, tileSize, color2);
                }
            }

            Raylib.EndDrawing();
        }

        private void Update()
        {
            // Update game here
        }
    }
}
