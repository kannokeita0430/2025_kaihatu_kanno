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
            
        }
    }
}
