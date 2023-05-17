using System;

namespace Algorithm
{
    public class Board
    {
        public TileType[,] Tile { get; private set; }
        public int Size { get; private set; }
        public int DestY { get; private set; }
        public int DestX { get; private set; }

        Player _player;

        const char CIRCLE = '\u25cf';

        public enum TileType
        {
            Empty,
            Wall,
        }

        public void Initialize(int size, Player player)
        {
            //우리가 만들 미로는 벽에 둘러 쌓여있어야 되기에 size는 홀수여야함
            if (size % 2 == 0)
                return;

            Tile = new TileType[size, size];
            Size = size;
            _player = player;

            DestY = size - 2;
            DestX = size - 2;

            //GenerateByBinaryTree();
            GenerateBySideWinder();
        }

        void GenerateBySideWinder()
        {
            //일단 길을 다 막아버리는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        Tile[y, x] = TileType.Empty;
                    }
                }
            }

            //연속되는 3개의 길 중 하나를 아래로 뚫음
            //0101010
            //0000000
            //이런 맵이 있으면 저 1들 중에서 하나를 랜덤으로 고르고 그 아래를 뚫음

            Random rand = new Random();

            for (int y = 0; y < Size; y++)
            {
                int count = 1;

                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }

                    if (y == Size - 2 && x == Size - 2)
                        continue;

                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        Tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }


        }

        //Binary Tree Algorithm (미로 알고리즘 명칭)
        void GenerateByBinaryTree()
        {
            //일단 길을 다 막아버리는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        Tile[y, x] = TileType.Empty;
                    }
                }
            }

            //랜덤으로 우측 혹은 아래로 길을 뚫는 작업
            Random rand = new Random();

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    #region 외각 벽은 뚫리지 않게 하기 위해서 조건을 추가함
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }

                    //미로의 끝 부분이면 막히게함
                    if (y == Size - 2 && x == Size - 2)   
                        continue;

                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    #endregion


                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        Tile[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    //플레이어 좌표를 가져와서 그 좌표랑 현재 y, x가 일치하면 플레이어 전용 색상으로 표시.
                    if(x == _player.PosX && y == _player.PosY)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if(x == DestX && y == DestY)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);

                    Console.Write(CIRCLE);
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch(type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
            }

            return ConsoleColor.Green;
        }
    }
}