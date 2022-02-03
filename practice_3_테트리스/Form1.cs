using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //thread 사용
using System.Diagnostics;//stopwatch 사용

namespace practice_3_테트리스
{
    public partial class Tetris : Form
    {
        Manage R = new Manage();
        Boolean Time_on = false;
        public Tetris()
        {
            InitializeComponent();
            //프로그램이 시작되어도 게임시작전 timer가 동작하면 안되기 때문에
            //downtimer.Stop(); //타이머 stop
        }

        //=================================================================================== Thread .쓰레드. ===================================================================================

        //Thread 설정...
        private void Tetris_Load(object sender, EventArgs e)
        {
            //Tetris가 Load 될때 실행
            //그리는 그래픽 g 인자를 넘겨주는 곳

            //스레드 선언
            //스레드 인스턴스 만들어서 시작
            CheckForIllegalCrossThreadCalls = false;
            Thread T_thread = new Thread(Timer_Thread);
            T_thread.IsBackground = true;
            T_thread.Start();

            R.game_g = flowLayoutPanel1.CreateGraphics();
            R.prev_g = pictureBox3.CreateGraphics();
            R.deliver_g();
        }
        public void Main_Thread()
        {

        }
        public void Timer_Thread()
        {
            //시간을 측정해서 일정시간 마다 tick 함수를 실행함.

            while (true)//게임 중일 때 계속 돌아감.
            {
                Thread.BeginCriticalRegion();
                tick();
                Thread.EndCriticalRegion();
                Thread.Sleep(1000);
            }
        }
        //=================================================================================== 시스템 레이아웃 ===================================================================================

        private void game_start_Btn_Click(object sender, EventArgs e)
        {
            //게임 시작 버튼
            //downtimer.Start();
            if (R.Is_Play)    //게임 중.
            {
                //게임중일때는 리셋할건지 물어본다.
                R.Is_Play = false;
                DialogResult result = MessageBox.Show("게임이 실행중입니다. 리셋할까요?", "중단", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //리셋
                    R.Reset_Game();
                    R.Start_Game();
                }
                else if (result == DialogResult.No)
                {
                    //게임 재개
                    R.Is_Play = true;
                    //downtimer.Enabled = true;
                    //downtimer.Start();
                }
            }
            else //게임 시작 이전.
            {
                //게임이 시작되면 게임판을 리셋하고
                R.Start_Game();
            }

        }

        private void game_finish_Btn_Click(object sender, EventArgs e)
        {
            //게임 종료 버튼
            Environment.Exit(0);
        }

        private void tick()
        {
            if (R.Is_Play)
            {
                R.Game_routine();
                label3.Text = R.score.ToString();
                if (R.Game_Over())
                {
                    //게임이 종료됨
                    R.Is_Play = false;
                    DialogResult result = MessageBox.Show("게임이 끝났습니다.\n 리셋할까요?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //리셋
                        R.Reset_Game();
                        R.Start_Game();
                    }
                    else if (result == DialogResult.No)
                    {
                        //게임 끝
                        R.Is_Play = false;
                        //downtimer.Enabled = true;
                        //downtimer.Stop();
                    }
                }
            }
            Invalidate();
        }
        /*
         * 타이머 사용하지 않고 작성.
        private void timer1_Tick(object sender, EventArgs e)
        {
            //타이머가 작동하면
            if (R.Is_Play)
            {
                R.Game_routine();
                label3.Text = R.score.ToString();
                if (R.Game_Over())
                {
                    //게임이 종료됨
                    R.Is_Play = false;
                    DialogResult result = MessageBox.Show("게임이 끝났습니다.\n 리셋할까요?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //리셋
                        R.Reset_Game();
                        R.Start_Game();
                    }
                    else if (result == DialogResult.No)
                    {
                        //게임 끝
                        R.Is_Play = false;
                        downtimer.Enabled = true;
                        downtimer.Stop();
                    }
                }
            }
            Invalidate();
        }
        */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //키보드 입력 받는 함수
            if (R.Is_Play)
            {
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
            else
            {
                return false;
            }
        }
    }
}
