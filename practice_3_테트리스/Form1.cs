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
        Manage R = new Manage();
        public Tetris()
        {
            InitializeComponent();
            //프로그램이 시작되어도 게임시작전 timer가 동작하면 안되기 때문에 
            downtimer.Stop(); //타이머 stop
        }

        private void Tetris_Load(object sender, EventArgs e)
        {
            //Tetris가 Load 될때 실행
            //그리는 그래픽 g 인자를 넘겨주는 곳
            R.game_g = flowLayoutPanel1.CreateGraphics();
            R.prev_g = pictureBox3.CreateGraphics();
            R.deliver_g();
        }

        private void game_start_Btn_Click(object sender, EventArgs e)
        {
            //게임 시작 버튼
            if (R.Is_Play)    //게임 중.
            {
                //게임중일때는 리셋할건지 물어본다.
                downtimer.Stop();
                DialogResult result = MessageBox.Show("게임이 실행중입니다. 리셋할까요?", "중단", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //리셋
                    R.Reset_Game();
                    downtimer.Start();
                }
                else if (result == DialogResult.No)
                {
                    //게임 재개
                    downtimer.Start();
                }
            }
            else //게임 시작 이전.
            {
                //게임이 시작되면 게임판을 리셋하고
                R.Start_Game();
                downtimer.Start();
            }
            this.Focus();

        }

        private void game_finish_Btn_Click(object sender, EventArgs e)
        {
            //게임 종료 버튼
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //타이머가 작동하면
            R.Game_routine();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //키보드 입력 받는 함수
            switch (keyData)
            {
                case Keys.Left:
                    R.Move_Block(0);
                    break;

                case Keys.Right:
                    R.Move_Block(1);
                    break;

                case Keys.Down:
                    R.Move_Block(2);
                    break;

                case Keys.Up:
                    R.Rotate_Block();
                    break;

                case Keys.Z:
                    R.Drop_Block();
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
