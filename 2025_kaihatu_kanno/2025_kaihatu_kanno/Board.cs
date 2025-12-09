using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_kaihatu_kanno
{
    public class Board
    {
        // オセロの盤面８×８をつくる
        public const int SIZE = 8;
        public char[,] Cells = new char[SIZE, SIZE];
        
        // 一手目の色 黒 = ● 白 = ○
        public char Player = '黒';

        public Board()
        {
            InitializeBoard();
        }

        // 盤の初期配置
        public void InitializeBoard()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    // 空白
                    Cells[i, j] = '・'; 

                    // 真ん中の初期位置に黒と白を配置
                    Cells[3, 3] = '白';
                    Cells[3, 4] = '黒';
                    Cells[4, 3] = '黒';
                    Cells[4, 4] = '白';
                }
            }
        }
        

        // 石が置けるか判定
        // row 横　col 縦
        public bool isihantei(int row, int col)
        {

            char opponent = (Player == '黒') ? '白' : '黒';

            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int d = 0; d < 8; d++)
            {
                int x = row + dx[d];
                int y = col + dy[d];
                bool hasOpponent = false;

                while (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
                {
                    if (Cells[x, y] == opponent)
                    {
                        hasOpponent = true;
                        x += dx[d];
                        y += dy[d];
                    }
                    else if (hasOpponent && Cells[x, y] == Player)
                    {
                        return true;
                    }
                    else break;
                }
            }
            return false;

        }


        // 石を置いてひっくり返す
        public void PlaceDisk(int row, int col)
        {
            Cells[row, col] = Player;
            char opponent = (Player == '黒') ? '白' : '黒';

            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int d = 0; d < 8; d++)
            {
                int x = row + dx[d];
                int y = col + dy[d];
                var toFlip = new List<(int, int)>();

                while (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
                {
                    if (Cells[x, y] == opponent)
                    {
                        toFlip.Add((x, y));
                        x += dx[d];
                        y += dy[d];
                    }
                    else if (Cells[x, y] == Player)
                    {
                        foreach (var pos in toFlip)
                        {
                            Cells[pos.Item1, pos.Item2] = Player;
                        }
                        break;
                    }
                    else break;
                }
            }
            


            // プレイヤー交代
            Player = (Player  == '黒') ? '白' : '黒'; 
        }
    }
       
}
