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
        // 8*8のボタン配置
        Button[,] buttons = new Button[Board.SIZE, Board.SIZE];
        Board board = new Board();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // 画面サイズ
            this.ClientSize = new Size(650, 650);
            
            // そもそものボード
            CreateBoardUI();

            // ボードの色とか
            UpdateBoardUI();
        }

        // ボタン生成
        private void CreateBoardUI()
        {
            // ボタンのサイズ
            int size = 80;

            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    Button btn = new Button();
                    
                    // 縦横のサイズ
                    btn.Width = btn.Height = size;
                    
                    // 場所
                    btn.Location = new Point(j * size, i * size);

                    // ボタンの位置を記録
                    btn.Tag = (i, j);

                    btn.Click += BoardButton_Click;
                    
                    // 画面に追加
                    this.Controls.Add(btn);
                    
                    // 配列に保持する
                    buttons[i, j] = btn;
                }
            }
        }

        // ボタンクリックで石を置く
        private void BoardButton_Click(object sender, EventArgs e)
        {
            var (row, col) = ((int, int))((Button)sender).Tag;
            
            //置けない場所をクリックしたとき
            if (!board.IsValidMove(row, col))
            {
                MessageBox.Show("ここはおけないよ～ん");
                return;
            }

            // 石をひっくり返す
            board.PlaceDisk(row, col);

            // ボタンの色変える
            UpdateBoardUI();
        }

        // 見た目更新
        private void UpdateBoardUI()
        {
            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    if (board.Cells[i, j] == '黒')
                        buttons[i, j].BackColor = Color.Black;
                    else if (board.Cells[i, j] == '白')
                        buttons[i, j].BackColor = Color.White;
                    else
                        buttons[i, j].BackColor = Color.Green;

                    
                }
            }

            // for (int i = 0; i < Board.SIZE; i++)
            // {
            //     for (int j = 0; j < Board.SIZE; j++)
            //     {
            //         if (board.Cells[i, j] = Color.Green)
            //             buttons[i, j].BackColor = Color.Black;
            //         else if (board.Cells[i, j] == '白')
            //             buttons[i, j].BackColor = Color.White;
            //         else
            //             buttons[i, j].BackColor = Color.Green;
            //     }
            // }


        }
    }
}
