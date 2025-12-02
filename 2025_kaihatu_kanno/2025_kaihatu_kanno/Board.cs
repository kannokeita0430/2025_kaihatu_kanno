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
        public char CurrentPlayer = '●';

        public Board()
        {
            InitializeBoard();
        }

        // 盤の初期配置
        public void InitializeBoard()
        {
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    Cells[i, j] = '・'; // 空白
            // 真ん中の初期位置に黒と白を配置
            Cells[3, 3] = '○';
            Cells[3, 4] = '●';
            Cells[4, 3] = '●';
            Cells[4, 4] = '○';
        }
    }
}
