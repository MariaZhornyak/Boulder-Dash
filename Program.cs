using System;
using System.Diagnostics;

namespace BoulderDash
{
    class Program
    {
        static void Main(string[] args)
        {
            Process music = new Process();
            music.EnableRaisingEvents = false; 
            music.StartInfo.FileName = "powershell";
            music.StartInfo.Arguments = "-c (New-Object Media.SoundPlayer 'music.wav').PlaySync();";
            music.Start();

            char player = 'I';
            char sand = '.';
            char stone = 'o';
            char diamond = 'D';

            int width = 12;
            int height = 12;

            char[,] field = new char[width, height];
            Random rnd = new Random();
            int numberOfDiamonds = 0;
            int posX = 0;
            int posY = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int random = rnd.Next(0, 100);
                    if (random < 80 || (i == posX && j == posY))
                    {
                        field[i, j] = sand;
                    }
                    else if (random < 90)
                    {
                        field[i, j] = stone;
                    }
                    else
                    {
                        field[i, j] = diamond;
                        numberOfDiamonds++;
                    }
                }
            }
            Console.WriteLine(numberOfDiamonds);

            field[posX, posY] = player;

            int points = 0;
            bool gameEnded = false; 
            while (true)
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine($"Your points: {points}");
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write(field[j, i]);
                    }
                    Console.WriteLine();
                }

                if (gameEnded)
                {
                    Console.Write("You won!");
                    Console.ReadKey();
                    break;
                }

                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.RightArrow:
                        if (posX != width - 1)
                        {
                            if (field[posX + 1, posY] == diamond)
                            {
                                Process sound = new Process();
                                sound.EnableRaisingEvents = false; 
                                sound.StartInfo.FileName = "powershell";
                                sound.StartInfo.Arguments = "-c (New-Object Media.SoundPlayer 'C:/Users/User/Downloads/BoulderDash/Crystall.wav').PlaySync();";
                                sound.Start();

                                field[posX + 1, posY] = player;
                                field[posX, posY] = ' ';
                                points++;
                                if (points == numberOfDiamonds)
                                {
                                    gameEnded = true;
                                }
                                posX += 1;
                            }
                            else if (field[posX + 1, posY] == stone)
                            {
                                if (posX != width - 2 && field[posX + 2, posY] != stone && field[posX + 2, posY] != diamond)
                                {
                                    field[posX + 2, posY] = stone;
                                    field[posX + 1, posY] = player;
                                    field[posX, posY] = ' ';
                                    posX += 1;
                                }
                            }
                            else if (field[posX + 1, posY] == sand || field[posX + 1, posY] == ' ')
                            {
                                field[posX + 1, posY] = player;
                                field[posX, posY] = ' ';
                                posX += 1;
                            }
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (posX != 0)
                        {
                            if (field[posX - 1, posY] == diamond)
                            {
                                Process sound = new Process();
                                sound.EnableRaisingEvents = false; 
                                sound.StartInfo.FileName = "powershell";
                                sound.StartInfo.Arguments = "-c (New-Object Media.SoundPlayer 'C:/Users/User/Downloads/BoulderDash/Crystall.wav').PlaySync();";
                                sound.Start();

                                field[posX - 1, posY] = player;
                                field[posX, posY] = ' ';
                                points++;
                                if (points == numberOfDiamonds)
                                {
                                    gameEnded = true;
                                }
                                posX -= 1;
                            }
                            else if (field[posX - 1, posY] == stone)
                            {
                                if (posX != 1 && field[posX - 2, posY] != stone && field[posX - 2, posY] != diamond)
                                {
                                    field[posX - 2, posY] = stone;
                                    field[posX - 1, posY] = player;
                                    field[posX, posY] = ' ';
                                    posX -= 1;
                                }
                            }
                            else if (field[posX - 1, posY] == sand || field[posX - 1, posY] == ' ')
                            {
                                field[posX - 1, posY] = player;
                                field[posX, posY] = ' ';
                                posX -= 1;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (posY != 0)
                        {
                            if (field[posX, posY - 1] == diamond)
                            {
                                Process sound = new Process();
                                sound.EnableRaisingEvents = false; 
                                sound.StartInfo.FileName = "powershell";
                                sound.StartInfo.Arguments = "-c (New-Object Media.SoundPlayer 'C:/Users/User/Downloads/BoulderDash/Crystall.wav').PlaySync();";
                                sound.Start();

                                field[posX, posY - 1] = player;
                                field[posX, posY] = ' ';
                                points++;
                                if (points == numberOfDiamonds)
                                {
                                    gameEnded = true;
                                }
                                posY -= 1;
                            }
                            else if (field[posX, posY - 1] == stone)
                            {
                                if (posY != 1 && field[posX, posY - 2] != stone && field[posX, posY - 2] != diamond)
                                {
                                    field[posX, posY - 2] = stone;
                                    field[posX, posY - 1] = player;
                                    field[posX, posY] = ' ';
                                    posY -= 1;
                                }
                            }
                            else if (field[posX, posY - 1] == sand || field[posX, posY - 1] == ' ')
                            {
                                field[posX, posY - 1] = player;
                                field[posX, posY] = ' ';
                                posY -= 1;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (posY != height - 1)
                        {
                            if (field[posX, posY + 1] == diamond)
                            {
                                Process sound = new Process();
                                sound.EnableRaisingEvents = false; 
                                sound.StartInfo.FileName = "powershell";
                                sound.StartInfo.Arguments = "-c (New-Object Media.SoundPlayer 'C:/Users/User/Downloads/BoulderDash/Crystall.wav').PlaySync();";
                                sound.Start();

                                field[posX, posY + 1] = player;
                                field[posX, posY] = ' ';
                                points++;
                                if (points == numberOfDiamonds)
                                {
                                    gameEnded = true;
                                }
                                posY += 1;
                            }
                            else if (field[posX, posY + 1] == stone)
                            {
                                if (posY != height - 2 && field[posX, posY + 2] != stone && field[posX, posY + 2] != diamond)
                                {
                                    field[posX, posY + 2] = stone;
                                    field[posX, posY + 1] = player;
                                    field[posX, posY] = ' ';
                                    posY += 1;
                                }
                            }
                            else if (field[posX, posY + 1] == sand || field[posX, posY + 1] == ' ')
                            {
                                field[posX, posY + 1] = player;
                                field[posX, posY] = ' ';
                                posY += 1;
                            }
                        }
                        break;
                }
            }
            
            music.Kill();
        }
    }
}