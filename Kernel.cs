using System;
using Time = Cosmos.HAL.RTC;
using Sys = Cosmos.System;

namespace GraphicTest
{
    public class Kernel : Sys.Kernel
    {

        static class mouse
        {
            public static int mouseX;
            public static int mouseY;
            public static int mouseXOld;
            public static int mouseYOld;
        }
        static class settings
        {
            public static System.ConsoleColor BackgroundColor;
            public static System.ConsoleColor TextColor;
            public static string version;
            public static string currentApp;
            public static string currentAppOld;
            public static string[] memoText = new string[1794];
            public static int memoTextCurrentChar;
            public static bool updateScreen;
            public static bool showMouseCoodinates;
            public static bool showSystemVersion;
            public static bool militaryTime;
        }

        static class paint
        {
            public static System.ConsoleColor currentColor;
            public static System.ConsoleColor canvasColor;
            public static System.ConsoleColor[] drawDots1 = new System.ConsoleColor[78]; //Embarrassing, but hey, you're restricted by a lot when it comes to lists in COSMOS
            public static System.ConsoleColor[] drawDots2 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots3 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots4 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots5 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots6 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots7 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots8 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots9 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots10 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots11 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots12 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots13 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots14 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots15 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots16 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots17 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots18 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots19 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots20 = new System.ConsoleColor[78];
            public static System.ConsoleColor[] drawDots21 = new System.ConsoleColor[78];
        }
        static class calc
        {
            public static long num1;
            public static long num2;
            public static string ans;
            public static int CalcEntry;
            public static string operation;
        }

        static class pong
        {
            public static int ballX;
            public static int ballY;
            public static int ballXOld;
            public static int ballYOld;
            public static int XVel;
            public static int YVel;
            public static int P1;
            public static int P2;
            public static int P1Score;
            public static int P2Score;
            public static bool gameOver;
        }

        static class arkanoid
        {
            public static int PX;
            public static int ballX;
            public static int ballY;
            public static int ballXOld;
            public static int ballYOld;
            public static int ballXVel;
            public static int ballYVel;
            public static int score;
            public static bool gameOver;
            public static int lives;
            public static int blocksLeft;
            public static int[] blocks1 = new int[13];
            public static int[] blocks2 = new int[13];
            public static int[] blocks3 = new int[13];
            public static int[] blocks4 = new int[13];
            public static int[] blocks5 = new int[13];
            public static int[] blocks6 = new int[13];
        }

        public static void WaitSeconds(double secNum)
        {
            double counter = secNum * 100000;
            while (secNum < counter)
            {
                secNum++;
            }
        }

        string Sec { get; set; }
        int PongTime { get; set; }
        int ArkanoidTime { get; set; }



        public static void ResetCanvas()
        {
            paint.canvasColor = ConsoleColor.White;
            paint.currentColor = ConsoleColor.Black;
            { //Minimize this monstrosity and move on
                for (int i = 0; i < 78; i++)
                {
                    paint.drawDots1[i] = ConsoleColor.Gray; //Gray/DarkGray is used like "undrawn" canvas space, and will update with the canvas 

                    paint.drawDots2[i] = ConsoleColor.Gray;

                    paint.drawDots3[i] = ConsoleColor.Gray;

                    paint.drawDots4[i] = ConsoleColor.Gray;

                    paint.drawDots5[i] = ConsoleColor.Gray;

                    paint.drawDots6[i] = ConsoleColor.Gray;

                    paint.drawDots7[i] = ConsoleColor.Gray;

                    paint.drawDots8[i] = ConsoleColor.Gray;

                    paint.drawDots9[i] = ConsoleColor.Gray;

                    paint.drawDots10[i] = ConsoleColor.Gray;

                    paint.drawDots11[i] = ConsoleColor.Gray;

                    paint.drawDots12[i] = ConsoleColor.Gray;

                    paint.drawDots13[i] = ConsoleColor.Gray;

                    paint.drawDots14[i] = ConsoleColor.Gray;

                    paint.drawDots15[i] = ConsoleColor.Gray;

                    paint.drawDots16[i] = ConsoleColor.Gray;

                    paint.drawDots17[i] = ConsoleColor.Gray;

                    paint.drawDots18[i] = ConsoleColor.Gray;

                    paint.drawDots19[i] = ConsoleColor.Gray;

                    paint.drawDots20[i] = ConsoleColor.Gray;

                    paint.drawDots21[i] = ConsoleColor.Gray;
                }
            }
        }

        public static void ResetArkanoid()
        {
            int j = 2;
            for (int i = 0; i < 13; i++)
            {
                arkanoid.blocks1[i] = j;
                arkanoid.blocks2[i] = j;
                arkanoid.blocks3[i] = j;
                arkanoid.blocks4[i] = j;
                arkanoid.blocks5[i] = j;
                arkanoid.blocks6[i] = j;
                j += 6;
            }
            arkanoid.PX = 37;
            arkanoid.ballX = 38;
            arkanoid.ballY = 20;
            arkanoid.ballXVel = 1;
            arkanoid.ballYVel = -1;
            arkanoid.score = 0;
            arkanoid.lives = 3;
            arkanoid.blocksLeft = 78;
            arkanoid.gameOver = false;
        }

        protected override void BeforeRun() //Setup variables and mouse areas
        {
            settings.BackgroundColor = ConsoleColor.Blue;
            settings.TextColor = ConsoleColor.White;
            Console.CursorVisible = false;
            settings.currentApp = "init";
            settings.updateScreen = false;
            settings.memoTextCurrentChar = 0;
            ResetCanvas();
            ResetArkanoid();
            Sec = "0";
            PongTime = 0;
            calc.CalcEntry = 1;
            calc.num1 = 0;
            calc.num2 = 0;
            calc.ans = "";
            calc.operation = "add";
            settings.showMouseCoodinates = false;
            settings.showSystemVersion = true;
            settings.militaryTime = false;
            pong.P1 = 11;
            pong.P2 = 11;
            pong.P1Score = 0;
            pong.P2Score = 0;
            pong.ballX = 39;
            pong.ballY = 12;
            pong.XVel = 1;
            pong.YVel = 1;
            pong.gameOver = false;

            


            Console.BackgroundColor = settings.BackgroundColor;
            Console.Clear();
            Sys.MouseManager.ScreenHeight = 230;
            Sys.MouseManager.ScreenWidth = 780;
            Sys.MouseManager.X = (uint)390;
            Sys.MouseManager.Y = (uint)120;
            mouse.mouseX = 39;
            mouse.mouseY = 12;
            


        }

        public static void WriteText(string text, int x, int y) //Custom function for writing text to screen (Without messing up area)
        {
            if (settings.currentApp == "memopad")
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = settings.BackgroundColor;
            }
            
            Console.ForegroundColor = settings.TextColor;
            Console.SetCursorPosition(x + 1, y + 1);
            Console.WriteLine(text);
        }

        public static void ClearScreen()
        {
            int drawY = 1;
            Console.BackgroundColor = ConsoleColor.Black;
            while (drawY < 25 && settings.currentApp != "paint") //Keep the background clear to cleanly update menus
            {
                Console.SetCursorPosition(1, drawY);
                Console.WriteLine("                                                                              ");
                drawY++;
            }
        }

        public static void DrawBox(ConsoleColor color, int len, int wid, int x, int y) //Code for drawing a 'box' on the screen, it's just made with colored spaces
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = color;
            string LengthDrawn = "";
            int i = 0;
            for (i = 0; i < len-1; i++)
            {
                LengthDrawn = LengthDrawn + " ";
            }
            Console.Write(LengthDrawn);
            int j = y;
            for (j = y; j < wid+y; j++)
            {
                Console.SetCursorPosition(x, j);
                Console.Write(" ");
                Console.SetCursorPosition(x+i, j);
                Console.Write(" ");
            }
            Console.SetCursorPosition(x, j-1);
            Console.Write(LengthDrawn);

        }


        protected void Menu() //Main Menu
        {

            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = settings.BackgroundColor;
            Console.ForegroundColor = settings.TextColor;
            Console.WriteLine("xxxman360 OS                                                          " + settings.version);

            WriteText("Memo Pad", 1, 1);
            WriteText("Paint", 10, 1);
            WriteText("Clock", 16, 1);
            WriteText("Settings", 22, 1);
            WriteText("System Information", 31, 1);
            WriteText("Calculator", 50, 1);
            WriteText("Pong", 61, 1);
            WriteText("Arkanoid", 66, 1);
            WriteText("Reboot", 1, 3);
            WriteText("Shutdown", 8, 3);

        }

        protected void MemoPad()
        {
            string memoTextOld;
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = settings.BackgroundColor;
            Console.ForegroundColor = settings.TextColor;
            Console.WriteLine("xxxman360 OS - Memo Pad                                               " + settings.version);
            Console.SetCursorPosition(1, 23);
            Console.WriteLine("Exit");

            //Embarrasing number of variables
            string line1 = "";
            string line2 = "";
            string line3 = "";
            string line4 = "";
            string line5 = "";
            string line6 = "";
            string line7 = "";
            string line8 = "";
            string line9 = "";
            string line10 = "";
            string line11 = "";
            string line12 = "";
            string line13 = "";
            string line14 = "";
            string line15 = "";
            string line16 = "";
            string line17 = "";
            string line18 = "";
            string line19 = "";
            string line20 = "";
            string line21 = "";
            string line22 = "";
            string line23 = "";

            for (int i = 0; i < 1794; i++) //Bad code, I know, but this what I could think of to evenly distribute the text in the memopad without interferring with borders
            {
                if (i <= 77)
                {
                    line1 = line1 + settings.memoText[i];
                }
                if (i <= 155 && i > 77)
                {
                    line2 = line2 + settings.memoText[i];
                }
                if (i <= 233 && i > 155)
                {
                    line3 = line3 + settings.memoText[i];
                }
                if (i <= 311 && i > 233)
                {
                    line4 = line4 + settings.memoText[i];
                }
                if (i <= 389 && i > 311)
                {
                    line5 = line5 + settings.memoText[i];
                }
                if (i <= 467 && i > 389)
                {
                    line6 = line6 + settings.memoText[i];
                }
                if (i <= 545 && i > 467)
                {
                    line7 = line7 + settings.memoText[i];
                }
                if (i <= 623 && i > 545)
                {
                    line8 = line8 + settings.memoText[i];
                }
                if (i <= 701 && i > 623)
                {
                    line9 = line9 + settings.memoText[i];
                }
                if (i <= 779 && i > 701)
                {
                    line10 = line10 + settings.memoText[i];
                }
                if (i <= 857 && i > 779)
                {
                    line11 = line11 + settings.memoText[i];
                }
                if (i <= 935 && i > 857)
                {
                    line12 = line12 + settings.memoText[i];
                }
                if (i <= 1013 && i > 935)
                {
                    line13 = line13 + settings.memoText[i];
                }
                if (i <= 1091 && i > 1013)
                {
                    line14 = line14 + settings.memoText[i];
                }
                if (i <= 1169 && i > 1091)
                {
                    line15 = line15 + settings.memoText[i];
                }
                if (i <= 1247 && i > 1169)
                {
                    line16 = line16 + settings.memoText[i];
                }
                if (i <= 1325 && i > 1247)
                {
                    line17 = line17 + settings.memoText[i];
                }
                if (i <= 1403 && i > 1325)
                {
                    line18 = line18 + settings.memoText[i];
                }
                if (i <= 1481 && i > 1403)
                {
                    line19 = line19 + settings.memoText[i];
                }
                if (i <= 1559 && i > 1481)
                {
                    line20 = line20 + settings.memoText[i];
                }
                if (i <= 1637 && i > 1559)
                {
                    line21 = line21 + settings.memoText[i];
                }
                if (i <= 1715 && i > 1637)
                {
                    line22 = line22 + settings.memoText[i];
                }
                if (i <= 1793 && i > 1715)
                {
                    line23 = line23 + settings.memoText[i];
                }

            }
            WriteText(line1, 0, 0);
            WriteText(line2, 0, 1);
            WriteText(line3, 0, 2);
            WriteText(line4, 0, 3);
            WriteText(line5, 0, 4);
            WriteText(line6, 0, 5);
            WriteText(line7, 0, 6);
            WriteText(line8, 0, 7);
            WriteText(line9, 0, 8);
            WriteText(line10, 0, 9);
            WriteText(line11, 0, 10);
            WriteText(line12, 0, 11);
            WriteText(line13, 0, 12);
            WriteText(line14, 0, 13);
            WriteText(line15, 0, 14);
            WriteText(line16, 0, 15);
            WriteText(line17, 0, 16);
            WriteText(line18, 0, 17);
            WriteText(line19, 0, 18);
            WriteText(line20, 0, 19);
            WriteText(line21, 0, 20);
            WriteText(line22, 0, 21);
            WriteText(line23, 0, 22);

            memoTextOld = string.Join("", settings.memoText);
            if (Console.KeyAvailable) //What's the point of checking keys if none are pressed?
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.A) //Keypessing inputs!
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("A"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.B)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("B"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.C)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("C"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.D)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("D"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.E)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("E"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.F)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("F"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.G)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("G"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.H)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("H"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.I)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("I"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.J)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("J"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.K)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("K"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.L)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("L"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.M)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("M");
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("N"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.O)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("O"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.P)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("P"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("Q"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.R)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("R"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.S)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("S"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.T)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("T"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.U)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("U"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.V)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("V"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.W)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("W"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.X)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("X"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.Y)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("Y"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.Z)
                {
                    settings.memoText[settings.memoTextCurrentChar] = ("Z"); 
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    settings.memoTextCurrentChar--;
                    settings.memoText[settings.memoTextCurrentChar] = (" ");
                }
                else if (key.Key == ConsoleKey.Spacebar)
                {
                    settings.memoText[settings.memoTextCurrentChar] = (" ");
                    settings.memoTextCurrentChar++;
                }
                else if (key.Key == ConsoleKey.D1)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("!"); 
                        settings.memoTextCurrentChar++;
                    } else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("1"); 
                        settings.memoTextCurrentChar++;
                    }
                    
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("@"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("2"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.D3)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("#"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("3"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.D4)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("$"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("4"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.D5)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("%"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("5"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.D6)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("^"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("6"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.D7)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("&"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("7"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.D8)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("*"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("8"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.D9)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("(");
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("9"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.D0)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = (")"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("0"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.OemMinus)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("_"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("-"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.OemPlus)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("+"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("="); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.Oem3)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("~"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("`"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.Oem4)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("{"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("["); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.Oem6)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("}"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("]"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.Oem5)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("|"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("\\"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.Oem1)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = (":"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = (";");
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.Oem7)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("\""); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("'"); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.OemComma)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("<"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = (","); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.OemPeriod)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = (">"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("."); 
                        settings.memoTextCurrentChar++;
                    }

                }
                else if (key.Key == ConsoleKey.Oem2)
                {
                    if (Sys.KeyboardManager.ShiftPressed)
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("?"); 
                        settings.memoTextCurrentChar++;
                    }
                    else
                    {
                        settings.memoText[settings.memoTextCurrentChar] = ("/"); 
                        settings.memoTextCurrentChar++;
                    }

                }
            }
            if (memoTextOld != string.Join("", settings.memoText))
            {
                settings.updateScreen = true;
            }


        }

        public static void Clock()
        {
            ClearScreen();
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = settings.BackgroundColor;
            Console.ForegroundColor = settings.TextColor;
            Console.WriteLine("xxxman360 OS - Clock                                                  " + settings.version);
            Console.SetCursorPosition(1, 23);
            Console.WriteLine("Exit");

            //Get the times and turn them into strings, except Hr. Hr is an int.
            string DoW = Time.DayOfTheWeek.ToString();
            string DoWStr = "";
            string DoM = Time.DayOfTheMonth.ToString();
            string M = Time.Month.ToString();
            string MonStr = "";
            string Cen = Time.Century.ToString();
            string Y = Time.Year.ToString();
            int Hr = (int)Time.Hour;
            string Min = Time.Minute.ToString();
            string Second = Time.Second.ToString();

            if (DoW == "1") //Days of the week
            {
                DoWStr = "Monday";
            } 
            else if (DoW == "2")
            {
                DoWStr = "Tuesday";
            }
            else if (DoW == "3")
            {
                DoWStr = "Wednesday";
            }
            else if (DoW == "4")
            {
                DoWStr = "Thursday";
            }
            else if (DoW == "5")
            {
                DoWStr = "Friday";
            }
            else if (DoW == "6")
            {
                DoWStr = "Saturday";
            }
            else if (DoW == "7")
            {
                DoWStr = "Sunday";
            }

            if (M == "1") //Months of the year
            {
                MonStr = "January";
            }
            else if (M == "2")
            {
                MonStr = "February";
            }
            else if (M == "3")
            {
                MonStr = "March";
            }
            else if (M == "4")
            {
                MonStr = "April";
            }
            else if (M == "5")
            {
                MonStr = "May";
            }
            else if (M == "6")
            {
                MonStr = "June";
            }
            else if (M == "7")
            {
                MonStr = "July";
            }
            else if (M == "8")
            {
                MonStr = "August";
            }
            else if (M == "9")
            {
                MonStr = "September";
            }
            else if (M == "10")
            {
                MonStr = "October";
            }
            else if (M == "11")
            {
                MonStr = "November";
            }
            else if (M == "12")
            {
                MonStr = "December";
            }

            if (settings.militaryTime)
            {
                WriteText("The time is " + DoWStr + ", " + MonStr + " " + DoM + ", " + Cen + Y + " " + Hr + ":" + Min + ":" + Second, 1, 1);
            }
            else
            {
                string AMPM;
                if (Hr > 12)
                {
                    Hr = Hr - 12;
                    AMPM = "PM";
                }
                else
                {
                    AMPM = "AM";
                }
                WriteText("The time is " + DoWStr + ", " + MonStr + " " + DoM + ", " + Cen + Y + " " + Hr + ":" + Min + ":" + Second + " " + AMPM, 1, 1);
            }


            
            
        }

        public static void Settings()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = settings.BackgroundColor;
            Console.ForegroundColor = settings.TextColor;
            Console.WriteLine("xxxman360 OS - Settings                                               " + settings.version);
            Console.SetCursorPosition(1, 23);
            Console.WriteLine("Exit");

            //The following code consists mainly of just printing text and buttons, it's nothing to freak out over.
            WriteText("Text Color:",1,1);
            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(2, 4);
            Console.Write("Red");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(6, 4);
            Console.Write("Red");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(10, 4);
            Console.Write("Yellow");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(17, 4);
            Console.Write("Yellow");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(24, 4);
            Console.Write("Green");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(30, 4);
            Console.Write("Green");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(36, 4);
            Console.Write("Cyan");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(41, 4);
            Console.Write("Cyan");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(46, 4);
            Console.Write("Blue");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(51, 4);
            Console.Write("Blue");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(56, 4);
            Console.Write("Magenta");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(64, 4);
            Console.Write("Magenta");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(72, 4);
            Console.Write("White");

            WriteText("Border Color:", 1, 5);
            Console.ForegroundColor = ConsoleColor.White;

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(2, 8);
            Console.Write("Red");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(6, 8);
            Console.Write("Yellow");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(13, 8);
            Console.Write("Green");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(19, 8);
            Console.Write("Cyan");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(24, 8);
            Console.Write("Blue");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(29, 8);
            Console.Write("Magenta");
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(37, 8);
            Console.Write("White");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(43, 8);
            Console.Write("Black");

            Console.BackgroundColor = settings.BackgroundColor;
            
            WriteText("Display mouse coordinates:", 1, 9);
            WriteText("Yes", 1, 11); WriteText("No", 5, 11);
            WriteText("Show version in corner:", 1, 13);
            WriteText("Yes", 1, 15); WriteText("No", 5, 15);
            WriteText("Time is displayed in AM/PM:", 1, 17);
            WriteText("Yes", 1, 19); WriteText("No", 5, 19);
        }

        public static void ShiftDrawingColor(ConsoleColor consoleColor) //Code to replace the drawing's colors with an inverted variant (Just black and white) incase of a canvas change
        { //THIRD TIME'S THE CHARM
            for (int i = 0; i < 78; i++)
            {
                if (paint.drawDots1[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots1[i] = ConsoleColor.Black;
                }
                if (paint.drawDots1[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots1[i] = ConsoleColor.White;
                }
                if (paint.drawDots1[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots1[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots1[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots1[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots2[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots2[i] = ConsoleColor.Black;
                }
                if (paint.drawDots2[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots2[i] = ConsoleColor.White;
                }

                if (paint.drawDots2[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots2[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots2[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots2[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots3[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots3[i] = ConsoleColor.Black;
                }
                if (paint.drawDots3[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots3[i] = ConsoleColor.White;
                }

                if (paint.drawDots3[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots3[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots3[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots3[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots4[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots4[i] = ConsoleColor.Black;
                }
                if (paint.drawDots4[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots4[i] = ConsoleColor.White;
                }

                if (paint.drawDots4[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots4[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots4[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots4[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots5[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots5[i] = ConsoleColor.Black;
                }
                if (paint.drawDots5[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots5[i] = ConsoleColor.White;
                }

                if (paint.drawDots5[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots5[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots5[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots5[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots6[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots6[i] = ConsoleColor.Black;
                }
                if (paint.drawDots6[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots6[i] = ConsoleColor.White;
                }

                if (paint.drawDots6[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots6[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots6[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots6[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots7[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots7[i] = ConsoleColor.Black;
                }
                if (paint.drawDots7[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots7[i] = ConsoleColor.White;
                }

                if (paint.drawDots7[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots7[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots7[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots7[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots8[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots8[i] = ConsoleColor.Black;
                }
                if (paint.drawDots8[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots8[i] = ConsoleColor.White;
                }

                if (paint.drawDots8[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots8[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots8[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots8[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots9[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots9[i] = ConsoleColor.Black;
                }
                if (paint.drawDots9[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots9[i] = ConsoleColor.White;
                }

                if (paint.drawDots9[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots9[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots9[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots9[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots10[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots10[i] = ConsoleColor.Black;
                }
                if (paint.drawDots10[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots10[i] = ConsoleColor.White;
                }

                if (paint.drawDots10[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots10[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots10[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots10[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots11[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots11[i] = ConsoleColor.Black;
                }
                if (paint.drawDots11[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots11[i] = ConsoleColor.White;
                }

                if (paint.drawDots11[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots11[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots11[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots11[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots12[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots12[i] = ConsoleColor.Black;
                }
                if (paint.drawDots12[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots12[i] = ConsoleColor.White;
                }

                if (paint.drawDots12[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots12[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots12[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots12[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots13[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots13[i] = ConsoleColor.Black;
                }
                if (paint.drawDots13[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots13[i] = ConsoleColor.White;
                }

                if (paint.drawDots13[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots13[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots13[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots13[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots14[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots14[i] = ConsoleColor.Black;
                }
                if (paint.drawDots14[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots14[i] = ConsoleColor.White;
                }

                if (paint.drawDots14[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots14[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots14[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots14[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots15[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots15[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots15[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots15[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots15[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots15[i] = ConsoleColor.Black;
                }
                if (paint.drawDots15[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots15[i] = ConsoleColor.White;
                }

                if (paint.drawDots16[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots16[i] = ConsoleColor.Black;
                }
                if (paint.drawDots16[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots16[i] = ConsoleColor.White;
                }

                if (paint.drawDots16[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots16[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots16[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots16[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots17[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots17[i] = ConsoleColor.Black;
                }
                if (paint.drawDots17[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots17[i] = ConsoleColor.White;
                }

                if (paint.drawDots17[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots17[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots17[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots17[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots18[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots18[i] = ConsoleColor.Black;
                }
                if (paint.drawDots18[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots18[i] = ConsoleColor.White;
                }

                if (paint.drawDots18[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots18[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots18[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots18[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots19[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots19[i] = ConsoleColor.Black;
                }
                if (paint.drawDots19[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots19[i] = ConsoleColor.White;
                }

                if (paint.drawDots19[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots19[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots19[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots19[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots20[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots20[i] = ConsoleColor.Black;
                }
                if (paint.drawDots20[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots20[i] = ConsoleColor.White;
                }

                if (paint.drawDots20[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots20[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots20[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots20[i] = ConsoleColor.Gray;
                }

                if (paint.drawDots21[i] == ConsoleColor.White && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots21[i] = ConsoleColor.Black;
                }
                if (paint.drawDots21[i] == ConsoleColor.Black && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots21[i] = ConsoleColor.White;
                }

                if (paint.drawDots21[i] == ConsoleColor.Gray && consoleColor == ConsoleColor.White)
                {
                    paint.drawDots21[i] = ConsoleColor.DarkGray;
                }
                if (paint.drawDots21[i] == ConsoleColor.DarkGray && consoleColor == ConsoleColor.Black)
                {
                    paint.drawDots21[i] = ConsoleColor.Gray;
                }
            }

        } 

        protected void Paint()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = settings.BackgroundColor;
            Console.ForegroundColor = settings.TextColor;
            Console.WriteLine("xxxman360 OS - Paint                                                  " + settings.version);

            Console.BackgroundColor = paint.canvasColor;
            if (paint.canvasColor == ConsoleColor.White)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            } else if (paint.canvasColor == ConsoleColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.SetCursorPosition(1, 22);
            Console.WriteLine("===============================================To clear the drawing, press C==");
            Console.SetCursorPosition(1, 23);
            Console.WriteLine("Exit                                           White Canvas  Black Canvas  Esr");

            Console.BackgroundColor = ConsoleColor.Red; //CUE THE STEREOTYPICAL BAD CODE MEMES
            Console.SetCursorPosition(6, 22);
            Console.WriteLine("    ");
            Console.SetCursorPosition(6, 23);
            Console.WriteLine("    ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(12, 22);
            Console.WriteLine("    ");
            Console.SetCursorPosition(12, 23);
            Console.WriteLine("    ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(18, 22);
            Console.WriteLine("    ");
            Console.SetCursorPosition(18, 23);
            Console.WriteLine("    ");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(24, 22);
            Console.WriteLine("    ");
            Console.SetCursorPosition(24, 23);
            Console.WriteLine("    ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(30, 22);
            Console.WriteLine("    ");
            Console.SetCursorPosition(30, 23);
            Console.WriteLine("    ");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(36, 22);
            Console.WriteLine("    ");
            Console.SetCursorPosition(36, 23);
            Console.WriteLine("    ");
            if (paint.canvasColor == ConsoleColor.White)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
            } else if (paint.canvasColor == ConsoleColor.Black)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
            }
            
            Console.SetCursorPosition(42, 22);
            Console.WriteLine("    ");
            Console.SetCursorPosition(42, 23);
            Console.WriteLine("    ");
            { //SHIELD YOUR EYES
                //Although, if you're wondering what this does, it simply draws the colors to the screen based on what is stored in the lists.
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots1[i];
                    Console.SetCursorPosition(i + 1, 1);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots2[i];
                    Console.SetCursorPosition(i + 1, 2);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots3[i];
                    Console.SetCursorPosition(i + 1, 3);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots4[i];
                    Console.SetCursorPosition(i + 1, 4);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots5[i];
                    Console.SetCursorPosition(i + 1, 5);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots6[i];
                    Console.SetCursorPosition(i + 1, 6);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots7[i];
                    Console.SetCursorPosition(i + 1, 7);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots8[i];
                    Console.SetCursorPosition(i + 1, 8);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots9[i];
                    Console.SetCursorPosition(i + 1, 9);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots10[i];
                    Console.SetCursorPosition(i + 1, 10);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots11[i];
                    Console.SetCursorPosition(i + 1, 11);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots12[i];
                    Console.SetCursorPosition(i + 1, 12);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots13[i];
                    Console.SetCursorPosition(i + 1, 13);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots14[i];
                    Console.SetCursorPosition(i + 1, 14);
                    Console.Write(" ");
                }

                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots15[i];
                    Console.SetCursorPosition(i + 1, 15);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots16[i];
                    Console.SetCursorPosition(i + 1, 16);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots17[i];
                    Console.SetCursorPosition(i + 1, 17);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots18[i];
                    Console.SetCursorPosition(i + 1, 18);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots19[i];
                    Console.SetCursorPosition(i + 1, 19);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots20[i];
                    Console.SetCursorPosition(i + 1, 20);
                    Console.Write(" ");
                }
                for (int i = 0; i < 78; i++)
                {
                    Console.BackgroundColor = paint.drawDots21[i];
                    Console.SetCursorPosition(i + 1, 21);
                    Console.Write(" ");
                }
            }
            



        }

        protected void SysInfo()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = settings.BackgroundColor;
            Console.ForegroundColor = settings.TextColor;
            Console.WriteLine("xxxman360 OS - System Information                                     " + settings.version);
            Console.SetCursorPosition(1, 23);
            Console.WriteLine("Exit");

            WriteText("CPU:",1,1);
            WriteText(Cosmos.Core.CPU.GetCPUBrandString(), 1, 3);
            WriteText("RAM:", 1, 5);
            WriteText(Cosmos.Core.CPU.GetAmountOfRAM().ToString() + " MB", 1, 7);
            WriteText("MAC Address:", 1, 9);
            WriteText(Cosmos.HAL.Network.MACAddress.Broadcast.ToString(), 1, 11);
            WriteText("Device ID:", 1, 13);
            int devID = (int)Cosmos.HAL.PCIDevice.Config.DeviceID;
            WriteText(devID.ToString(), 1, 15);

            WriteText("About the OS                                                                  ", 0, 17);
            WriteText("xxxman360 OS is an OS created in C# for educational purposes. It is compiled", 1, 19);
            WriteText("using IL2CPU from the COSMOS Team. COSMOS is an OS development kit for", 1, 20);
            WriteText("operating systems with the .NET framework.", 1, 21);
        }

        protected void Calc()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = settings.BackgroundColor;
            Console.ForegroundColor = settings.TextColor;
            Console.WriteLine("xxxman360 OS - Calculator                                             " + settings.version);
            Console.SetCursorPosition(1, 23);
            Console.WriteLine("Exit");
            
            WriteText("                                ", 1, 1);
            Console.SetCursorPosition(2, 3);
            Console.Write(" ");
            Console.SetCursorPosition(33, 3);
            Console.Write(" ");
            Console.SetCursorPosition(2, 4);
            Console.Write(" ");
            Console.SetCursorPosition(3, 3);
            if (calc.CalcEntry == 1)
            {
                Console.Write(calc.num1);
            }
            if (calc.CalcEntry == 2)
            {
                Console.Write(calc.num2);
            }
            if (calc.CalcEntry == 3)
            {
                Console.Write(calc.ans);
            }

            Console.SetCursorPosition(33, 4);
            Console.Write(" ");
            WriteText("                                ", 1, 4);

            DrawBox(settings.BackgroundColor, 5, 5, 2, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(4, 9);
            Console.Write("1");
            DrawBox(settings.BackgroundColor, 5, 5, 8, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(10, 9);
            Console.Write("2");
            DrawBox(settings.BackgroundColor, 5, 5, 14, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(16, 9);
            Console.Write("3");
            DrawBox(settings.BackgroundColor, 5, 5, 20, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(22, 9);
            Console.Write("4");
            DrawBox(settings.BackgroundColor, 5, 5, 26, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(28, 9);
            Console.Write("5");

            DrawBox(settings.BackgroundColor, 5, 5, 2, 13);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(4, 15);
            Console.Write("6");
            DrawBox(settings.BackgroundColor, 5, 5, 8, 13);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(10, 15);
            Console.Write("7");
            DrawBox(settings.BackgroundColor, 5, 5, 14, 13);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(16, 15);
            Console.Write("8");
            DrawBox(settings.BackgroundColor, 5, 5, 20, 13);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(22, 15);
            Console.Write("9");
            DrawBox(settings.BackgroundColor, 5, 5, 26, 13);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(28, 15);
            Console.Write("0");

            DrawBox(settings.BackgroundColor, 3, 3, 3, 19);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(4, 20);
            Console.Write("+");
            DrawBox(settings.BackgroundColor, 3, 3, 9, 19);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(10, 20);
            Console.Write("-");
            DrawBox(settings.BackgroundColor, 3, 3, 15, 19);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(16, 20);
            Console.Write("*");
            DrawBox(settings.BackgroundColor, 3, 3, 21, 19);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(22, 20);
            Console.Write("/");
            DrawBox(settings.BackgroundColor, 3, 3, 27, 19);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(28, 20);
            if (calc.CalcEntry == 3)
            {
                Console.Write("C");
            }
            else
            {
                Console.Write("=");
            }
            


        }

        public static void Pong()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = settings.BackgroundColor;
            Console.ForegroundColor = settings.TextColor;
            Console.WriteLine("xxxman360 OS - Pong                                                   " + settings.version);
            Console.SetCursorPosition(1, 23);
            Console.WriteLine("Exit");

            Console.SetCursorPosition(2, pong.P1); //Paddle 1
            Console.Write(" ");
            Console.SetCursorPosition(2, pong.P1+1);
            Console.Write(" ");
            Console.SetCursorPosition(2, pong.P1+2);
            Console.Write(" ");
            Console.SetCursorPosition(2, pong.P1+3);
            Console.Write(" ");
            Console.SetCursorPosition(2, pong.P1+4);
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            if (pong.P1 < 18)
            {
                Console.SetCursorPosition(2, pong.P1 + 5);
                Console.Write(" ");
            }
            if (pong.P1 < 17)
            {
                Console.SetCursorPosition(2, pong.P1 + 6);
                Console.Write(" ");
            }
            
            if (pong.P1 > 1)
            {
                Console.SetCursorPosition(2, pong.P1 - 1);
                Console.Write(" ");
            }
            
            if (pong.P1 > 1)
            {
                Console.SetCursorPosition(2, pong.P1 - 2);
                Console.Write(" ");
            }
            

            Console.SetCursorPosition(4, 1);
            Console.Write("P1: " + pong.P1Score);

            Console.BackgroundColor = settings.BackgroundColor;
            Console.SetCursorPosition(77, pong.P2); //Paddle 2
            Console.Write(" ");
            Console.SetCursorPosition(77, pong.P2 + 1);
            Console.Write(" ");
            Console.SetCursorPosition(77, pong.P2 + 2);
            Console.Write(" ");
            Console.SetCursorPosition(77, pong.P2 + 3);
            Console.Write(" ");
            Console.SetCursorPosition(77, pong.P2 + 4);
            Console.Write(" ");
            Console.SetCursorPosition(77, pong.P2 + 5);
            Console.BackgroundColor = ConsoleColor.Black;
            if (pong.P2 < 19)
            {
                Console.SetCursorPosition(77, pong.P2 + 5);
                Console.Write(" ");
            }
            if (pong.P2 < 18)
            {
                Console.SetCursorPosition(77, pong.P2 + 6);
                Console.Write(" ");
            }

            if (pong.P2 > 1)
            {
                Console.SetCursorPosition(77, pong.P2 - 1);
                Console.Write(" ");
            }

            if (pong.P2 > 1)
            {
                Console.SetCursorPosition(77, pong.P2 - 2);
                Console.Write(" ");
            }

            Console.SetCursorPosition(71, 1);
            Console.Write("P2: " + pong.P2Score);

            if (pong.P1Score == 10)
            {
                Console.SetCursorPosition(1, 12);
                Console.Write("                              Player 1 has won!                              ");
            } else if (pong.P2Score == 10)
            {
                Console.SetCursorPosition(1, 12);
                Console.Write("                              Player 2 has won!                              ");
            }
            if (pong.P1Score == 10 || pong.P2Score == 10)
            {
                Console.SetCursorPosition(1, 13);
                Console.Write("                            Press N for new game.                            ");
                pong.gameOver = true;
            }
            

        }

        public static void PongBall() //Control the ball
        {
            pong.ballX = pong.ballX + pong.XVel;
            pong.ballY = pong.ballY + pong.YVel;
            if(pong.ballY == 1 || pong.ballY == 23)
            {
                pong.YVel = pong.YVel*-1;
            }
            if (pong.ballX == 1)
            {
                pong.P2Score++;
                pong.ballX = 39;
                pong.XVel = 1;
            }
            if (pong.ballX == 78)
            {
                pong.P1Score++;
                pong.ballX = 39;
                pong.XVel = -1;
            }
            if (pong.ballX == 2 && pong.ballY >= pong.P1 && pong.ballY <= pong.P1+4)
            {
                pong.XVel = 1;
            }
            if (pong.ballX == 77 && pong.ballY >= pong.P2 && pong.ballY <= pong.P2 + 4)
            {
                pong.XVel = -1;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(pong.ballXOld, pong.ballYOld);
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(pong.ballX, pong.ballY);
            Console.Write(" ");
            settings.updateScreen = true;
        }

        public static void Arkanoid()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = settings.BackgroundColor;
            Console.ForegroundColor = settings.TextColor;
            Console.WriteLine("xxxman360 OS - Arkanoid                                               " + settings.version);
            Console.SetCursorPosition(1, 23);
            Console.WriteLine("Exit");

            if (mouse.mouseX > 0 && mouse.mouseX < 74)
            {
                arkanoid.PX = mouse.mouseX; //Set the paddle to the mouse's X position.
            }
            

            for (int i = 0; i < arkanoid.blocks1.Length; i++) //Draw the blocks onto the screen using a for loop
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                if (arkanoid.blocks1[i] < 0) //Negative numbers let the game know the block is already destroyed
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(arkanoid.blocks1[i]* -1, 2);
                }
                else
                {
                    Console.SetCursorPosition(arkanoid.blocks1[i], 2);
                }
                Console.Write("    ");
                Console.BackgroundColor = ConsoleColor.Red;
                if (arkanoid.blocks2[i] < 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(arkanoid.blocks2[i] * -1, 4);
                }
                else
                {
                    Console.SetCursorPosition(arkanoid.blocks2[i], 4);
                }
                Console.Write("    ");
                Console.BackgroundColor = ConsoleColor.Yellow;
                if (arkanoid.blocks3[i] < 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(arkanoid.blocks3[i] * -1, 6);
                }
                else
                {
                    Console.SetCursorPosition(arkanoid.blocks3[i], 6);
                }
                Console.Write("    ");
                Console.BackgroundColor = ConsoleColor.Cyan;
                if (arkanoid.blocks4[i] < 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(arkanoid.blocks4[i] * -1, 8);
                }
                else
                {
                    Console.SetCursorPosition(arkanoid.blocks4[i], 8);
                }
                Console.Write("    ");
                Console.BackgroundColor = ConsoleColor.Magenta;
                if (arkanoid.blocks5[i] < 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(arkanoid.blocks5[i] * -1, 10);
                }
                else
                {
                    Console.SetCursorPosition(arkanoid.blocks5[i], 10);
                }
                Console.Write("    ");
                Console.BackgroundColor = ConsoleColor.Green;
                if (arkanoid.blocks6[i] < 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(arkanoid.blocks6[i] * -1, 12);
                }
                else
                {
                    Console.SetCursorPosition(arkanoid.blocks6[i], 12);
                }
                Console.Write("    ");
                


            }
            Console.BackgroundColor = settings.BackgroundColor;
            Console.SetCursorPosition(arkanoid.PX, 21);
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 1; i <= 78; i++)
            {
                if (i != arkanoid.PX && i != arkanoid.PX + 1 && i != arkanoid.PX + 2 && i != arkanoid.PX + 3 && i != arkanoid.PX + 4 && i != arkanoid.PX + 5)
                {
                    Console.SetCursorPosition(i, 21);
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(1, 1);
            Console.Write("Score: " + arkanoid.score + " Lives: " + arkanoid.lives);
            if (arkanoid.blocksLeft == 0)
            {
                Console.SetCursorPosition(1, 13);
                Console.Write("                              You won the game!                              ");
                Console.SetCursorPosition(1, 14);
                Console.Write("                             Your score was: " + arkanoid.score);
                Console.SetCursorPosition(1, 15);
                Console.Write("                            Press N for new game.                            ");
                arkanoid.gameOver = true;
            }
            if (arkanoid.lives == 0)
            {
                Console.SetCursorPosition(1, 13);
                Console.Write("                                 Game over!                                  ");
                Console.SetCursorPosition(1, 14);
                Console.Write("                             Your score was: " + arkanoid.score);
                Console.SetCursorPosition(1, 15);
                Console.Write("                            Press N for new game.                            ");
                arkanoid.gameOver = true;
            }

        }

        public static void ArkanoidBall() //Arkanoid's ball script; Includes block detection, paddle detection, direction changes and more
        {
            arkanoid.ballXOld = arkanoid.ballX;
            arkanoid.ballYOld = arkanoid.ballY;
            arkanoid.ballX += arkanoid.ballXVel;
            arkanoid.ballY += arkanoid.ballYVel;
            if (arkanoid.ballY == 1) //Vertical wall detection
            {
                arkanoid.ballYVel *= -1;
            }
            if (arkanoid.ballX == 1 || arkanoid.ballX == 78) //Horizontal wall detection
            {
                arkanoid.ballXVel *= -1;
            }
            {

                
                if (arkanoid.ballY == 2) //Gray blocks detection
                {
                    for (int i = 0; i < 13; i++)
                    {
                        if (arkanoid.ballX >= arkanoid.blocks1[i] && arkanoid.ballX <= arkanoid.blocks1[i] + 4 && arkanoid.blocks1[i] > 1)
                        {
                            arkanoid.blocks1[i] *=-1;
                            arkanoid.ballYVel *= -1;
                            arkanoid.score += 100;
                            arkanoid.blocksLeft--;
                        }
                    }
                }
                if (arkanoid.ballY == 4) //Red blocks detection
                {
                    for (int i = 0; i < 13; i++)
                    {
                        if (arkanoid.ballX >= arkanoid.blocks2[i] && arkanoid.ballX <= arkanoid.blocks2[i] + 4 && arkanoid.blocks2[i] > 1)
                        {
                            arkanoid.blocks2[i] *= -1;
                            arkanoid.ballYVel *= -1;
                            arkanoid.score += 100;
                            arkanoid.blocksLeft--;
                        }
                    }
                }
                if (arkanoid.ballY == 6) //Orange blocks detection
                {
                    for (int i = 0; i < 13; i++)
                    {
                        if (arkanoid.ballX >= arkanoid.blocks3[i] && arkanoid.ballX <= arkanoid.blocks3[i] + 4 && arkanoid.blocks3[i] > 1)
                        {
                            arkanoid.blocks3[i] *= -1;
                            arkanoid.ballYVel *= -1;
                            arkanoid.score += 100;
                            arkanoid.blocksLeft--;
                        }
                    }
                }
                if (arkanoid.ballY == 8) //Blue blocks detection
                {
                    for (int i = 0; i < 13; i++)
                    {
                        if (arkanoid.ballX >= arkanoid.blocks4[i] && arkanoid.ballX <= arkanoid.blocks4[i] + 4 && arkanoid.blocks4[i] > 1)
                        {
                            arkanoid.blocks4[i] *= -1;
                            arkanoid.ballYVel *= -1;
                            arkanoid.score += 100;
                            arkanoid.blocksLeft--;
                        }
                    }
                }
                if (arkanoid.ballY == 10) //Pink blocks detection
                {
                    for (int i = 0; i < 13; i++)
                    {
                        if (arkanoid.ballX >= arkanoid.blocks5[i] && arkanoid.ballX <= arkanoid.blocks5[i] + 4 && arkanoid.blocks5[i] > 1)
                        {
                            arkanoid.blocks5[i] *= -1;
                            arkanoid.ballYVel *= -1;
                            arkanoid.score += 100;
                            arkanoid.blocksLeft--;
                        }
                    }
                }
                if (arkanoid.ballY == 12) //Green blocks detection
                {
                    for (int i = 0; i < 13; i++)
                    {
                        if (arkanoid.ballX >= arkanoid.blocks6[i] && arkanoid.ballX <= arkanoid.blocks6[i] + 4 && arkanoid.blocks6[i] > 1)
                        {
                            arkanoid.blocks6[i] *= -1;
                            arkanoid.ballYVel *= -1;
                            arkanoid.score += 100;
                            arkanoid.blocksLeft--;
                        }
                    }
                }
            }
            if (arkanoid.ballY == 23)
            {
                arkanoid.lives--;
                arkanoid.ballX = 38;
                arkanoid.ballY = 20;
                arkanoid.ballYVel = -1;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(1, 13);
                Console.Write("                             You lost one life!                              ");
                WaitSeconds(250);
                Console.SetCursorPosition(1, 13);
                Console.Write("                                                                             ");
            }
            if (arkanoid.ballY == 21 && arkanoid.ballX >= arkanoid.PX && arkanoid.ballX <= arkanoid.PX + 6)
            {
                arkanoid.ballYVel *= -1;
            }
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(arkanoid.ballX, arkanoid.ballY);
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(arkanoid.ballXOld, arkanoid.ballYOld);
            Console.Write(" ");
            settings.updateScreen = true;

        }

        public static void MouseCursor() //Draws the cursor on the screen
        {
            Console.SetCursorPosition(mouse.mouseX, mouse.mouseY);
            if (settings.currentApp == "paint")
            {
                Console.BackgroundColor = paint.currentColor;
            } else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
            }
            
            Console.WriteLine(" ");
            
        }
        protected bool MouseSensing(string app) // This is its own function because mouse sensing doesn't require to draw anything and is also crucial to detect
        {
            if (app == "menu")
            {
                if (mouse.mouseY == 2 && mouse.mouseX > 1 && mouse.mouseX < 10)
                {
                    settings.currentApp = "memopad";
                    return true;
                }
                if (mouse.mouseY == 2 && mouse.mouseX > 10 && mouse.mouseX < 16)
                {
                    settings.currentApp = "paint";
                    return true;
                }
                if (mouse.mouseY == 2 && mouse.mouseX > 16 && mouse.mouseX < 22)
                {
                    settings.currentApp = "clock";
                    return true;
                }
                if (mouse.mouseY == 2 && mouse.mouseX > 22 && mouse.mouseX < 31)
                {
                    settings.currentApp = "settings";
                    return true;
                }
                if (mouse.mouseY == 2 && mouse.mouseX > 31 && mouse.mouseX < 50)
                {
                    settings.currentApp = "sysinfo";
                    return true;
                }
                if (mouse.mouseY == 2 && mouse.mouseX > 50 && mouse.mouseX < 61)
                {
                    settings.currentApp = "calc";
                    return true;
                }
                if (mouse.mouseY == 2 && mouse.mouseX > 61 && mouse.mouseX < 66)
                {
                    settings.currentApp = "pong";
                    return true;
                }
                if (mouse.mouseY == 2 && mouse.mouseX > 66 && mouse.mouseX < 75)
                {
                    settings.currentApp = "arkanoid";
                    return true;
                }
                if (mouse.mouseY == 4 && mouse.mouseX > 1 && mouse.mouseX < 8)
                {
                    Sys.Power.Reboot();
                    return true;
                }
                if (mouse.mouseY == 4 && mouse.mouseX > 8 && mouse.mouseX < 17)
                {
                    Sys.Power.Shutdown();
                    return true;
                }

            }
            else if (app == "memopad")
            {
                if (mouse.mouseY == 23 && mouse.mouseX > 0 && mouse.mouseX < 5)
                {
                    settings.currentApp = "menu";
                    return true;
                }
            }
            else if (app == "paint")
            {
                if (mouse.mouseY == 23 && mouse.mouseX > 0 && mouse.mouseX < 5)
                {
                    settings.currentApp = "menu";
                    return true;
                }
                if (mouse.mouseY > 21 && mouse.mouseY < 24)
                {
                    if (mouse.mouseX > 5 && mouse.mouseX < 10)
                    {
                        paint.currentColor = ConsoleColor.Red;
                        return true;
                    }
                    if (mouse.mouseX > 11 && mouse.mouseX < 16)
                    {
                        paint.currentColor = ConsoleColor.Yellow;
                        return true;
                    }
                    if (mouse.mouseX > 17 && mouse.mouseX < 22)
                    {
                        paint.currentColor = ConsoleColor.Green;
                        return true;
                    }
                    if (mouse.mouseX > 23 && mouse.mouseX < 28)
                    {
                        paint.currentColor = ConsoleColor.Cyan;
                        return true;
                    }
                    if (mouse.mouseX > 29 && mouse.mouseX < 34)
                    {
                        paint.currentColor = ConsoleColor.Blue;
                        return true;
                    }
                    if (mouse.mouseX > 35 && mouse.mouseX < 40)
                    {
                        paint.currentColor = ConsoleColor.Magenta;
                        return true;
                    }
                    if (mouse.mouseX > 41 && mouse.mouseX < 46)
                    {
                        if (paint.canvasColor == ConsoleColor.Black)
                        {
                            paint.currentColor = ConsoleColor.White;
                        } else if (paint.canvasColor == ConsoleColor.White)
                        {
                            paint.currentColor = ConsoleColor.Black;
                        }
                        return true;
                    }
                }
                if (mouse.mouseY > 22 && mouse.mouseY < 24)
                {
                    if (mouse.mouseX > 47 && mouse.mouseX < 60)
                    {
                        paint.canvasColor = ConsoleColor.White;
                        ShiftDrawingColor(ConsoleColor.Black);
                        return true;
                    }
                    if (mouse.mouseX > 61 && mouse.mouseX < 74)
                    {
                        paint.canvasColor = ConsoleColor.Black;
                        ShiftDrawingColor(ConsoleColor.White);
                        return true;
                    }
                    if (mouse.mouseX > 75 && mouse.mouseX < 79)
                    {
                        if (paint.canvasColor == ConsoleColor.Black)
                        {
                            paint.currentColor = ConsoleColor.Gray;
                        }
                        if (paint.canvasColor == ConsoleColor.White)
                        {
                            paint.currentColor = ConsoleColor.DarkGray;
                        }

                        return true;
                    }
                }
                {   //NOOO NOOOO
                    ConsoleColor tempColor = paint.currentColor;
                    if (paint.currentColor == ConsoleColor.DarkGray)
                    {
                        tempColor = ConsoleColor.Gray;
                    } else if (paint.currentColor == ConsoleColor.Gray)
                    {
                        tempColor = ConsoleColor.DarkGray;
                    }
                    if (mouse.mouseY == 1)
                    {
                        paint.drawDots1[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 2)
                    {
                        paint.drawDots2[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 3)
                    {
                        paint.drawDots3[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 4)
                    {
                        paint.drawDots4[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 5)
                    {
                        paint.drawDots5[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 6)
                    {
                        paint.drawDots6[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 7)
                    {
                        paint.drawDots7[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 8)
                    {
                        paint.drawDots8[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 9)
                    {
                        paint.drawDots9[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 10)
                    {
                        paint.drawDots10[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 11)
                    {
                        paint.drawDots11[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 12)
                    {
                        paint.drawDots12[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 13)
                    {
                        paint.drawDots13[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 14)
                    {
                        paint.drawDots14[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 15)
                    {
                        paint.drawDots15[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 16)
                    {
                        paint.drawDots16[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 17)
                    {
                        paint.drawDots17[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 18)
                    {
                        paint.drawDots18[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 19)
                    {
                        paint.drawDots19[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 20)
                    {
                        paint.drawDots20[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                    if (mouse.mouseY == 21)
                    {
                        paint.drawDots21[mouse.mouseX - 1] = tempColor;
                        return true;
                    }
                }
                
            }
            else if (app == "clock")
            {
                if (mouse.mouseY == 23 && mouse.mouseX > 0 && mouse.mouseX < 5)
                {
                    settings.currentApp = "menu";
                    return true;
                }
            }
            else if (app == "settings") //This was going to have to most sensing and you know it
            {
                if (mouse.mouseY == 23 && mouse.mouseX > 0 && mouse.mouseX < 5)
                {
                    settings.currentApp = "menu";
                    return true;
                }
                if (mouse.mouseY == 4)
                {
                    if (mouse.mouseX > 1 && mouse.mouseX < 5)
                    {
                        settings.TextColor = ConsoleColor.Red;
                        return true;
                    }
                    if (mouse.mouseX > 5 && mouse.mouseX < 9)
                    {
                        settings.TextColor = ConsoleColor.DarkRed;
                        return true;
                    }
                    if (mouse.mouseX > 9 && mouse.mouseX < 16)
                    {
                        settings.TextColor = ConsoleColor.Yellow;
                        return true;
                    }
                    if (mouse.mouseX > 16 && mouse.mouseX < 23)
                    {
                        settings.TextColor = ConsoleColor.DarkYellow;
                        return true;
                    }
                    if (mouse.mouseX > 23 && mouse.mouseX < 29)
                    {
                        settings.TextColor = ConsoleColor.Green;
                        return true;
                    }
                    if (mouse.mouseX > 29 && mouse.mouseX < 35)
                    {
                        settings.TextColor = ConsoleColor.DarkGreen;
                        return true;
                    }
                    if (mouse.mouseX > 35 && mouse.mouseX < 40)
                    {
                        settings.TextColor = ConsoleColor.Cyan;
                        return true;
                    }
                    if (mouse.mouseX > 40 && mouse.mouseX < 45)
                    {
                        settings.TextColor = ConsoleColor.DarkCyan;
                        return true;
                    }
                    if (mouse.mouseX > 45 && mouse.mouseX < 50)
                    {
                        settings.TextColor = ConsoleColor.Blue;
                        return true;
                    }
                    if (mouse.mouseX > 50 && mouse.mouseX < 55)
                    {
                        settings.TextColor = ConsoleColor.DarkBlue;
                        return true;
                    }
                    if (mouse.mouseX > 55 && mouse.mouseX < 63)
                    {
                        settings.TextColor = ConsoleColor.Magenta;
                        return true;
                    }
                    if (mouse.mouseX > 63 && mouse.mouseX < 71)
                    {
                        settings.TextColor = ConsoleColor.DarkMagenta;
                        return true;
                    }
                    if (mouse.mouseX > 71 && mouse.mouseX < 77)
                    {
                        settings.TextColor = ConsoleColor.White;
                        return true;
                    }
                }
                if (mouse.mouseY == 8)
                {
                    if (mouse.mouseX > 1 && mouse.mouseX < 5)
                    {
                        settings.BackgroundColor = ConsoleColor.Red;
                        Console.Clear();
                        ClearScreen();
                        return true;
                    }
                    if (mouse.mouseX > 5 && mouse.mouseX < 12)
                    {
                        settings.BackgroundColor = ConsoleColor.Yellow;
                        Console.Clear();
                        ClearScreen();
                        return true;
                    }
                    if (mouse.mouseX > 12 && mouse.mouseX < 18)
                    {
                        settings.BackgroundColor = ConsoleColor.Green;
                        Console.Clear();
                        ClearScreen();
                        return true;
                    }
                    if (mouse.mouseX > 18 && mouse.mouseX < 23)
                    {
                        settings.BackgroundColor = ConsoleColor.Cyan;
                        Console.Clear();
                        ClearScreen();
                        return true;
                    }
                    if (mouse.mouseX > 23 && mouse.mouseX < 28)
                    {
                        settings.BackgroundColor = ConsoleColor.Blue;
                        Console.Clear();
                        ClearScreen();
                        return true;
                    }
                    if (mouse.mouseX > 28 && mouse.mouseX < 36)
                    {
                        settings.BackgroundColor = ConsoleColor.Magenta;
                        Console.Clear();
                        ClearScreen();
                        return true;
                    }
                    if (mouse.mouseX > 36 && mouse.mouseX < 42)
                    {
                        settings.BackgroundColor = ConsoleColor.White;
                        Console.Clear();
                        ClearScreen();
                        return true;
                    }
                    if (mouse.mouseX > 42 && mouse.mouseX < 48)
                    {
                        settings.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        ClearScreen();
                        return true;
                    }
                }
                if (mouse.mouseY == 12)
                {
                    if (mouse.mouseX > 1 && mouse.mouseX < 5)
                    {
                        settings.showMouseCoodinates = true;
                        return true;
                    }
                    if (mouse.mouseX > 5 && mouse.mouseX < 8)
                    {
                        settings.showMouseCoodinates = false;
                        return true;
                    }
                }
                if (mouse.mouseY == 16)
                {
                    if (mouse.mouseX > 1 && mouse.mouseX < 5)
                    {
                        settings.showSystemVersion = true;
                        return true;
                    }
                    if (mouse.mouseX > 5 && mouse.mouseX < 8)
                    {
                        settings.showSystemVersion = false;
                        return true;
                    }
                }
                if (mouse.mouseY == 20)
                {
                    if (mouse.mouseX > 1 && mouse.mouseX < 5)
                    {
                        settings.militaryTime = false;
                        return true;
                    }
                    if (mouse.mouseX > 5 && mouse.mouseX < 8)
                    {
                        settings.militaryTime = true;
                        return true;
                    }
                }
            }
            else if (app == "sysinfo")
            {
                if (mouse.mouseY == 23 && mouse.mouseX > 0 && mouse.mouseX < 5)
                {
                    settings.currentApp = "menu";
                    return true;
                }
            }
            else if (app == "calc")
            {
                
                if (mouse.mouseY == 23 && mouse.mouseX > 0 && mouse.mouseX < 5)
                {
                    settings.currentApp = "menu";
                    return true;
                }
                if (mouse.mouseX > 1 && mouse.mouseX < 31 && mouse.mouseY > 6 && mouse.mouseY < 22)
                {
                    while (Sys.MouseManager.MouseState == Sys.MouseState.Left) //This exists to prevent number spam
                    {
                        PrintDebug("The system is waiting for the mouse button to be lifted");
                    }
                    ClearScreen();
                    if (mouse.mouseY > 6 && mouse.mouseY < 12)
                    {
                        if (mouse.mouseX > 1 && mouse.mouseX < 7)
                        {
                            if (calc.CalcEntry == 1)
                            {
                                calc.num1 = long.Parse(calc.num1.ToString() + "1");
                                return true;
                            }
                            if (calc.CalcEntry == 2)
                            {
                                calc.num2 = long.Parse(calc.num2.ToString() + "1");
                                return true;
                            }
                        }
                        if (mouse.mouseX > 7 && mouse.mouseX < 13)
                        {
                            if (calc.CalcEntry == 1)
                            {
                                calc.num1 = long.Parse(calc.num1.ToString() + "2");
                                return true;
                            }
                            if (calc.CalcEntry == 2)
                            {
                                calc.num2 = long.Parse(calc.num2.ToString() + "2");
                                return true;
                            }
                        }
                        if (mouse.mouseX > 13 && mouse.mouseX < 19)
                        {
                            if (calc.CalcEntry == 1)
                            {
                                calc.num1 = long.Parse(calc.num1.ToString() + "3");
                                return true;
                            }
                            if (calc.CalcEntry == 2)
                            {
                                calc.num2 = long.Parse(calc.num2.ToString() + "3");
                                return true;
                            }
                        }
                        if (mouse.mouseX > 19 && mouse.mouseX < 25)
                        {
                            if (calc.CalcEntry == 1)
                            {
                                calc.num1 = long.Parse(calc.num1.ToString() + "4");
                                return true;
                            }
                            if (calc.CalcEntry == 2)
                            {
                                calc.num2 = long.Parse(calc.num2.ToString() + "4");
                                return true;
                            }
                        }
                        if (mouse.mouseX > 25 && mouse.mouseX < 31)
                        {
                            if (calc.CalcEntry == 1)
                            {
                                calc.num1 = long.Parse(calc.num1.ToString() + "5");
                                return true;
                            }
                            if (calc.CalcEntry == 2)
                            {
                                calc.num2 = long.Parse(calc.num2.ToString() + "5");
                                return true;
                            }
                        }
                    } //First row
                    if (mouse.mouseY > 12 && mouse.mouseY < 18)
                    {
                        if (mouse.mouseX > 1 && mouse.mouseX < 7)
                        {
                            if (calc.CalcEntry == 1)
                            {
                                calc.num1 = long.Parse(calc.num1.ToString() + "6");
                                return true;
                            }
                            if (calc.CalcEntry == 2)
                            {
                                calc.num2 = long.Parse(calc.num2.ToString() + "6");
                                return true;
                            }
                        }
                        if (mouse.mouseX > 7 && mouse.mouseX < 13)
                        {
                            if (calc.CalcEntry == 1)
                            {
                                calc.num1 = long.Parse(calc.num1.ToString() + "7");
                                return true;
                            }
                            if (calc.CalcEntry == 2)
                            {
                                calc.num2 = long.Parse(calc.num2.ToString() + "7");
                                return true;
                            }
                        }
                        if (mouse.mouseX > 13 && mouse.mouseX < 19)
                        {
                            if (calc.CalcEntry == 1)
                            {
                                calc.num1 = long.Parse(calc.num1.ToString() + "8");
                                return true;
                            }
                            if (calc.CalcEntry == 2)
                            {
                                calc.num2 = long.Parse(calc.num2.ToString() + "8");
                                return true;
                            }
                        }
                        if (mouse.mouseX > 19 && mouse.mouseX < 25)
                        {
                            if (calc.CalcEntry == 1)
                            {
                                calc.num1 = long.Parse(calc.num1.ToString() + "9");
                                return true;
                            }
                            if (calc.CalcEntry == 2)
                            {
                                calc.num2 = long.Parse(calc.num2.ToString() + "9");
                                return true;
                            }
                        }
                        if (mouse.mouseX > 25 && mouse.mouseX < 31)
                        {
                            if (calc.CalcEntry == 1)
                            {
                                calc.num1 = long.Parse(calc.num1.ToString() + "0");
                                return true;
                            }
                            if (calc.CalcEntry == 2)
                            {
                                calc.num2 = long.Parse(calc.num2.ToString() + "0");
                                return true;
                            }
                        }
                    } //Second row
                    if (mouse.mouseY > 18 && mouse.mouseY < 22) //Buttons
                    {
                        if (mouse.mouseX > 2 && mouse.mouseX < 6)
                        {
                            calc.operation = "add";
                            calc.CalcEntry = 2;
                            return true;
                        }
                        if (mouse.mouseX > 8 && mouse.mouseX < 12)
                        {
                            calc.operation = "subtract";
                            calc.CalcEntry = 2;
                            return true;
                        }
                        if (mouse.mouseX > 14 && mouse.mouseX < 18)
                        {
                            calc.operation = "multiply";
                            calc.CalcEntry = 2;
                            return true;
                        }
                        if (mouse.mouseX > 20 && mouse.mouseX < 24)
                        {
                            calc.operation = "divide";
                            calc.CalcEntry = 2;
                            return true;
                        }
                        if (mouse.mouseX > 24 && mouse.mouseX < 30)
                        {
                            if (calc.CalcEntry == 2)
                            {
                                var ansold = calc.ans;
                                calc.CalcEntry = 3;
                                if (calc.operation == "add")
                                {
                                    calc.ans = (calc.num1 + calc.num2).ToString();
                                }
                                else if (calc.operation == "subtract")
                                {
                                    calc.ans = (calc.num1 - calc.num2).ToString();
                                }
                                else if (calc.operation == "multiply")
                                {
                                    calc.ans = (calc.num1 * calc.num2).ToString();
                                }
                                else if (calc.operation == "divide")
                                {
                                    calc.ans = ((calc.num1) / (calc.num2)).ToString();
                                    
                                }
                                if (ansold != calc.ans)
                                {
                                    calc.num1 = 0;
                                    calc.num2 = 0;
                                    return true;
                                }
                            }
                            if (calc.CalcEntry == 3)
                            {
                                calc.CalcEntry = 1;
                                return true;
                            }
                        }
                    }
                }
                
            }
            else if (app == "pong")
            {
                if (mouse.mouseY == 23 && mouse.mouseX > 0 && mouse.mouseX < 5)
                {
                    settings.currentApp = "menu";
                    pong.P1Score = 0;
                    pong.P2Score = 0;
                    pong.ballX = 39;
                    pong.gameOver = false;
                    return true;
                }
            }
            else if (app == "arkanoid")
            {
                if (mouse.mouseY == 23 && mouse.mouseX > 0 && mouse.mouseX < 5)
                {
                    settings.currentApp = "menu";
                    ResetArkanoid();
                    ClearScreen();
                    return true;
                }
            }
            return false;
        }

        protected override void Run() //Background loop, displays what is needed.
        {
            try
            {
                if (settings.showSystemVersion)
                {
                    settings.version = "    v1.0.0";
                }
                else
                {
                    settings.version = "          ";
                }
                mouse.mouseXOld = mouse.mouseX;
                mouse.mouseYOld = mouse.mouseY;
                settings.currentAppOld = settings.currentApp;
                if (settings.currentApp == "init")
                {
                    settings.currentApp = "menu";
                }
                string secOld = Sec;
                int PongTimeOld = PongTime;
                int ArkanoidTimeOld = ArkanoidTime;
                Sec = Time.Second.ToString();
                PongTime = (int)Cosmos.Core.CPU.GetCPUUptime() / 100000000;
                ArkanoidTime = (int)Cosmos.Core.CPU.GetCPUUptime() / 200000000;
                if (settings.currentApp == "clock" && secOld != Sec) //So time does not go out of sync
                {
                    settings.updateScreen = true;
                }
                if (settings.currentApp == "pong" && (PongTimeOld != PongTime && !pong.gameOver))
                {
                        pong.ballXOld = pong.ballX;
                        pong.ballYOld = pong.ballY;
                        PongBall();
                    

                }
                if (settings.currentApp == "arkanoid" && (ArkanoidTimeOld != ArkanoidTime && !arkanoid.gameOver))
                {
                    arkanoid.ballXOld = arkanoid.ballX;
                    arkanoid.ballYOld = arkanoid.ballY;
                    ArkanoidBall();


                }
                if (Sys.MouseManager.MouseState == Sys.MouseState.Left)
                {
                    settings.updateScreen = MouseSensing(settings.currentApp); //Trigger a screen update if a button has been clicked

                }
                if (Console.KeyAvailable && settings.currentApp == "memopad") //In case someone has typed something, we should check to see if that is a displayable key in the memopad
                {
                    settings.updateScreen = true;
                }
                if (settings.currentApp == "paint" && Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.C)
                    {
                        ResetCanvas();
                        settings.updateScreen = true;
                    }
                }
                
                mouse.mouseX = (int)Sys.MouseManager.X / 10 + 1;
                mouse.mouseY = (int)Sys.MouseManager.Y / 10 + 1;
                if (mouse.mouseXOld != mouse.mouseX || mouse.mouseYOld != mouse.mouseY)
                {
                    settings.updateScreen = true;
                }
                if (settings.updateScreen) //This if statement exists to prevent the screen from flipping out.
                {
                    settings.updateScreen = false;
                    if (settings.currentApp == "paint")
                    {
                       Console.BackgroundColor = paint.canvasColor;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    
                    if (settings.currentAppOld != settings.currentApp)
                    {
                        ClearScreen();
                    }

                    if (settings.currentApp == "menu")
                    {
                        Menu();
                    }
                    else if (settings.currentApp == "memopad")
                    {
                        MemoPad();
                    }
                    else if (settings.currentApp == "paint")
                    {
                        Paint();
                    }
                    else if (settings.currentApp == "clock")
                    {
                        Clock();
                    }
                    else if (settings.currentApp == "settings")
                    {
                        Settings();
                    }
                    else if (settings.currentApp == "sysinfo")
                    {
                        SysInfo();
                    }
                    else if (settings.currentApp == "calc")
                    {
                        Calc();
                    }
                    else if (settings.currentApp == "pong")
                    {
                        Pong();
                    }
                    else if (settings.currentApp == "arkanoid")
                    {
                        Arkanoid();
                    }
                    Console.SetCursorPosition(mouse.mouseXOld, mouse.mouseYOld);
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (settings.currentApp != "paint") //Paint has a pre-drawn background already
                    {
                        Console.Write(" ");
                    }
                    MouseCursor();
                    Console.BackgroundColor = settings.BackgroundColor;
                    Console.ForegroundColor = settings.TextColor;
                    if (settings.showMouseCoodinates)
                    {
                        Console.SetCursorPosition(50, 0);
                        Console.Write("Mouse X: " + mouse.mouseX + " Mouse Y: " + mouse.mouseY);
                    }
                    

                }

                if (Sys.MouseManager.MouseState != Sys.MouseState.Left)
                {
                    WaitSeconds(25);
                }
                
                if (settings.currentApp == "pong" && Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.W)
                    {
                        if (pong.P1 > 1)
                        {
                            pong.P1-=2;
                        }

                    }
                    if (key.Key == ConsoleKey.S)
                    {
                        if (pong.P1 < 19)
                        {
                            pong.P1+=2;
                        }
                    }
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (pong.P2 > 1)
                        {
                            pong.P2-=2;
                        }
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (pong.P2 < 19)
                        {
                            pong.P2+=2;
                        }
                    }
                    if (key.Key == ConsoleKey.N && pong.gameOver)
                    {
                        pong.gameOver = false;
                        pong.P1Score = 0;
                        pong.P2Score = 0;
                        pong.ballX = 39;
                        Console.Clear();
                        ClearScreen();

                    }
                    settings.updateScreen = true;
                }
                if (settings.currentApp == "arkanoid" && Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    /*if (key.Key == ConsoleKey.A || key.Key == ConsoleKey.RightArrow)
                    {
                        if (arkanoid.PX < 72)
                        {
                            arkanoid.PX+=2;
                        }

                    }
                    if (key.Key == ConsoleKey.D || key.Key == ConsoleKey.LeftArrow)
                    {
                        if (arkanoid.PX > 1)
                        {
                            arkanoid.PX-=2;
                        }
                    }
                    */
                    if (key.Key == ConsoleKey.N && arkanoid.gameOver)
                    {
                        ResetArkanoid();
                        ClearScreen();

                    }
                    settings.updateScreen = true;
                }

            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("The system has run into a problem and has been halted.");
                Console.WriteLine();
                Console.WriteLine("Press any key to restart your computer....");
                Console.ReadKey();
                Sys.Power.Reboot();
            }
            
            
        }
    }
}
