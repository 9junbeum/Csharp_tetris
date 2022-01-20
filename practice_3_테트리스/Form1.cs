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
        Game new_game = new Game();

        public Tetris()
        {
            InitializeComponent();
            downtimer.Stop();
        }

        private void game_finish_Btn_Click(object sender, EventArgs e)
        {
            //무슨 차이인지 모르겠으니, 모두 구현후 알아보자.
            //Environment.Exit();
            //Application.Exit();
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            new_game.Game_routine();
        }

        private void game_start_Btn_Click(object sender, EventArgs e)
        {

            if(new_game.Is_Play)    //게임 중.
            {
                //게임중일때는 리셋할건지 물어본다.
                downtimer.Stop();
                DialogResult result = MessageBox.Show("게임이 실행중입니다. 리셋할까요?", "중단", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    //리셋
                }
                else if(result == DialogResult.No)
                {
                    //게임 재개
                    downtimer.Start();
                }
            }
            else                    //게임 시작 이전.
            {
                //게임이 시작되면 게임판을 리셋하고
                new_game.Start_Game();
                downtimer.Start();
            }
            this.Focus();
            
        }


        private void Tetris_Load(object sender, EventArgs e)
        {
            //그리는 그래픽 g 인자를 넘겨주는 곳
            new_game.game_g = flowLayoutPanel1.CreateGraphics();
            new_game.prev_g = pictureBox3.CreateGraphics();
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    new_game.Move_Block(0);
                    break;

                case Keys.Right:
                    new_game.Move_Block(1);
                    break;

                case Keys.Down:
                    new_game.Move_Block(2);
                    break;

                case Keys.Up:
                    new_game.Rotate_Block();
                    break;

                case Keys.Space:
                    new_game.Drop_Block();
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
