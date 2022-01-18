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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        }

    }
}
