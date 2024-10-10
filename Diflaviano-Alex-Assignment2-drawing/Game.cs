// Include code libraries you need below (use the namespace).
using Raylib_cs;
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Color playerColor;
        Color redLineColor = new Color(0xce, 0x11, 0x26);
        Color blueLineColor = new Color(0x10, 0x73, 0xd6);
        Color jerseyColorGreen = new Color(0x10, 0x7c, 0x10);
        Color jerseyColorBlue = new Color(0x19, 0x3e, 0x91);
        Color creaseColor = new Color(0x26, 0xbf, 0xbf);

        // Arrays for X and Y Coordinates for players
        float[] xPlayerCoordinates = []; 
        float[] yPlayerCoordinates = [];


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("The Good Old Hockey Game");
            Window.SetSize(800, 400);

            // filling arrays with random coordinates
            for (int i = 0; i < 12; i++)
            {
                xPlayerCoordinates[i] = Random.Integer(55, 380);
                yPlayerCoordinates[i] = Random.Integer(420, 700);
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);

            // Faceoff Circle coordinates
            FaceoffCircle(150, 100, 50);
            FaceoffCircle(650, 100, 50);
            FaceoffCircle(150, 300, 50);
            FaceoffCircle(650, 300, 50);
            FaceoffCircle(400, 200, 50);

            // Coordinates of Lines
            IceRedLines(50, 0, 50, 400);
            IceRedLines(400, 0, 400, 400);
            IceRedLines(750, 0, 750, 400);
            IceBlueLines(300, 0, 300, 400);
            IceBlueLines(500, 0, 500, 400);

            // Coordinates of Goal Creases
            GoalCrease(50, 190, 15);
            GoalCrease(735, 190, 15);

            // Getting keyboard input to spawn players when space bar is presses
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                Draw.LineSize = 1;
                Draw.LineColor = Color.Black;
                Draw.FillColor = playerColor;
                for (int i = 0; i < xPlayerCoordinates.Length; i++)
                {
                    Draw.Square(xPlayerCoordinates[i], yPlayerCoordinates[i], 10);
                    if (i < 5)
                    {
                        playerColor = jerseyColorBlue;
                    }
                    else
                    {
                        playerColor = jerseyColorGreen;
                    }
                }
            }
        }

        // Functions for Drawing different shapes
        void FaceoffCircle(float x, float y, float radius)
        {
            Draw.LineSize = 1;
            Draw.LineColor = redLineColor;
            Draw.FillColor = Color.White;
            Draw.Circle(x, y, radius);
            Draw.FillColor = redLineColor;
            Draw.Circle(x, y, radius / 10);
        }

        void IceRedLines(float x1, float y1, float x2, float y2)
        {
            Draw.LineSize = 2;
            Draw.LineColor = redLineColor;
            Draw.Line(x1, y1, x2, y2);
        }

        void IceBlueLines(float x1, float y1, float x2, float y2)
        {
            Draw.LineSize = 2;
            Draw.LineColor = blueLineColor;
            Draw.Line(x1, y1, x2, y2);
        }

        void GoalCrease(float x, float y, float size)
        {
            Draw.LineSize = 1;
            Draw.LineColor = redLineColor;
            Draw.FillColor = creaseColor;
            Draw.Square(x, y, size);
        }
    }
}
