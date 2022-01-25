namespace practice_3_테트리스
{
    partial class Tetris
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.game_finish_Btn = new System.Windows.Forms.Button();
            this.game_start_Btn = new System.Windows.Forms.Button();
            this.label_score = new System.Windows.Forms.Label();
            this.downtimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.howtoplaypicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.howtoplaypicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 11);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(302, 602);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // game_finish_Btn
            // 
            this.game_finish_Btn.Location = new System.Drawing.Point(318, 574);
            this.game_finish_Btn.Name = "game_finish_Btn";
            this.game_finish_Btn.Size = new System.Drawing.Size(164, 38);
            this.game_finish_Btn.TabIndex = 0;
            this.game_finish_Btn.TabStop = false;
            this.game_finish_Btn.Text = "게임 종료";
            this.game_finish_Btn.UseVisualStyleBackColor = true;
            this.game_finish_Btn.Click += new System.EventHandler(this.game_finish_Btn_Click);
            // 
            // game_start_Btn
            // 
            this.game_start_Btn.Location = new System.Drawing.Point(318, 529);
            this.game_start_Btn.Name = "game_start_Btn";
            this.game_start_Btn.Size = new System.Drawing.Size(164, 39);
            this.game_start_Btn.TabIndex = 0;
            this.game_start_Btn.TabStop = false;
            this.game_start_Btn.Text = "게임 시작";
            this.game_start_Btn.UseVisualStyleBackColor = true;
            this.game_start_Btn.Click += new System.EventHandler(this.game_start_Btn_Click);
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold);
            this.label_score.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_score.Location = new System.Drawing.Point(318, 69);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(51, 15);
            this.label_score.TabIndex = 6;
            this.label_score.Text = "Score";
            // 
            // downtimer
            // 
            this.downtimer.Enabled = true;
            this.downtimer.Interval = 1000;
            this.downtimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(350, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "How to Play";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(355, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Next Block";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("새굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(325, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::practice_3_테트리스.Properties.Resources.점수판;
            this.pictureBox2.Location = new System.Drawing.Point(318, 97);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(164, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(324, 166);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(154, 154);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // howtoplaypicture
            // 
            this.howtoplaypicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.howtoplaypicture.Image = global::practice_3_테트리스.Properties.Resources.how_to_play_tetris;
            this.howtoplaypicture.Location = new System.Drawing.Point(318, 352);
            this.howtoplaypicture.Name = "howtoplaypicture";
            this.howtoplaypicture.Size = new System.Drawing.Size(164, 165);
            this.howtoplaypicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.howtoplaypicture.TabIndex = 7;
            this.howtoplaypicture.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::practice_3_테트리스.Properties.Resources.테트리스_배경_로고;
            this.pictureBox1.Location = new System.Drawing.Point(318, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(489, 624);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.howtoplaypicture);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.game_finish_Btn);
            this.Controls.Add(this.game_start_Btn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Tetris";
            this.Text = "TETRIS";
            this.Load += new System.EventHandler(this.Tetris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.howtoplaypicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;//테트리스 로고
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button game_finish_Btn;
        private System.Windows.Forms.Button game_start_Btn;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.PictureBox howtoplaypicture;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Timer downtimer;
    }
}

