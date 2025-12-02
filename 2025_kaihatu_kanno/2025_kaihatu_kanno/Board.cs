using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_kaihatu_kanno
{
    public class Board
    {
        //オセロの盤面８×８をつくる
        public const int SIZE = 8;
        public char[,] Cells = new char[SIZE, SIZE];
        public char CurrentPlayer = '●';    
    }
}
