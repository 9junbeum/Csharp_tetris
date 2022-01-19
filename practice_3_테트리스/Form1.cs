using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice_3_테트리스
{
    public partial class Tetris : Form
    {
        public Tetris()
        {
            InitializeComponent();
        }

        Game new_game = new Game();


        private void game_finish_Btn_Click(object sender, EventArgs e)
        {
            //무슨 차이인지 모르겠으니, 모두 구현후 알아보자.
            //Environment.Exit();
            //Application.Exit();
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //타이머가 한번 깜빡이면, 
            Block block = new Block();
        }

        private void game_start_Btn_Click(object sender, EventArgs e)
        {

        }

        private void Score_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            new_game.Init_Game_Board();
            new_game.Draw_Board(e.Graphics);
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            new_game.Draw_Preview(e.Graphics);
        }
    }
}
