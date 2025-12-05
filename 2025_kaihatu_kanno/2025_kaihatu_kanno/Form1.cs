using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2025_kaihatu_kanno
{
    public partial class Form1 : Form
    {
        // Boardクラス使う
        Button[,] buttons = new Button[Board.SIZE, Board.SIZE];
        Board board = new Board();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // サイズ
            this.ClientSize = new Size(420, 420);
            
            // そもそものボード
            CreateBoardUI();

            // ボードの色とか
            UpdateBoardUI();
        }

        // UIボタン生成
        private void CreateBoardUI()
        {
            int size = 50;
            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    Button btn = new Button();
                    btn.Width = btn.Height = size;
                    btn.Location = new Point(j * size, i * size);
                    btn.Tag = (i, j);
                    btn.Click += BoardButton_Click;
                    this.Controls.Add(btn);
                    buttons[i, j] = btn;
                }
            }
        }

        // ボタンクリックで石を置く
        private void BoardButton_Click(object sender, EventArgs e)
        {
            var (row, col) = ((int, int))((Button)sender).Tag;
            
            // //置けない場所をクリックしたとき
            // if (!board.IsValidMove(row, col))
            // {
            //     MessageBox.Show("ここはおけないよ～ん");
            //     return;
            // }

            // ボードを更新するところにいく
            board.PlaceDisk(row, col);
            UpdateBoardUI();
        }

        // 見た目更新
        private void UpdateBoardUI()
        {
            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    if (board.Cells[j, i] == '黒')
                        buttons[i, j].BackColor = Color.Black;
                    else if (board.Cells[j,i] == '白')
                        buttons[i, j].BackColor = Color.White;
                    else
                        buttons[i, j].BackColor = Color.Green;
                }
            }

        }
    }
}
