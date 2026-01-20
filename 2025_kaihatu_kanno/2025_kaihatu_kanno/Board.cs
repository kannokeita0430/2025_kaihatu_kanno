using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        // 石が置けるか判定　　row 横　col 縦
        public bool isihantei(int row, int col)
        {
            // 置いたところに置けないように
            if (Cells[row, col] != '・')
            {
                return false;
            }

            char aiteNoisi = (Player == '黒') ? '白' : '黒';

           // 押したところの上下左右斜めを見る
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
                
            // 一個ずつ増やしてみる
            for (int d = 0; d < 8; d++)
            {

                // 挟めるか
                int x = row + dx[d];
                int y = col + dy[d];
                bool isiHasamu = false;

                // 盤面の中で全部見る
                while (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
                {
                    // 相手の意思だったらきろく
                    if (Cells[x, y] == aiteNoisi)
                    {
                        isiHasamu = true;
                        x += dx[d];
                        y += dy[d];
                    }
                    // 自分の石だったらおけ
                    else if (isiHasamu && Cells[x, y] == Player)
                    {
                        return true;
                    }
                    else break;
                }
            }
            // 全部だめだった
            return false;

        }


        // 石を置いてひっくり返す
        public void hikkurikaesu(int row, int col)
        {
            Cells[row, col] = Player;

            // Player 黒 = aiteNoisi 白　逆の時はその逆
            //黒だったら白を、白だったら黒をひっくり返す
            char aiteNoisi = (Player == '黒') ? '白' : '黒';

            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int d = 0; d < 8; d++)
            {
                int x = row + dx[d];
                int y = col + dy[d];
                // 後でひっくり返す予定をきろく
                var atodekaeru = new List<(int, int)>();

                while (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
                {
                    if (Cells[x, y] == aiteNoisi)
                    {
                        // 後で変える候補
                        atodekaeru.Add((x, y));
                        x += dx[d];
                        y += dy[d];
                    }
                    // 自分の意思
                    else if (Cells[x, y] == Player)
                    {
                        // 全部ひっくり返っす
                        foreach (var pos in atodekaeru)
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


        // 石の数を数える
        public (int black, int white) isiCount()
        {
            int black = 0;
            int white = 0;

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (Cells[i, j] == '黒') black++;
                    else if (Cells[i, j] == '白') white++;
                }
            }
            return (black, white);
        }

        // 指定したプレイヤーがどこ かに置けるか
        public bool isiOkeruka(char player)
        {
            // 手番保存
            char current = Player;
            // 一瞬交代
            Player = player;

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    // 置ける場所がある
                    if (isihantei(i, j))
                    {
                        Player = current;
                        return true;
                    }
                }
            }

            Player = current;
            return false;
        }

        // 勝利判定
        public string Winner()
        {
            var (black, white) = isiCount();

            if (black > white)
                return $"黒の勝ち！ 黒:{black} 白:{white}";
            else if (white > black)
                return $"白の勝ち！ 黒:{black} 白:{white}";
            else
                return $"引き分け！ 黒:{black} 白:{white}";
        }

    }

}
