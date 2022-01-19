using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace practice_3_테트리스
{
    internal class Game
    {
        public const int BX = 10;//게임판 가로 넓이
        public const int BY = 20;//게임판 세로 넓이
        public const int CS = 30;//Cell Size (한칸의 크기)

        Color block_color = Color.MistyRose;    //블록색 하늘
        Color board_color = Color.RosyBrown;    //배경색 블랙

        public Boolean[,] Game_board = new Boolean[BX,BY];    //게임보드의 속성값(false, true)
        public int score; //점수

        public Game() //생성자
        {
            this.score = 0;
        }
        public void Init_Game_Board()
        {
            //게임 보드의 모든 구성요소를 false로 변경하여 비어있는 상태로 만든다.
            for (int i = 0; i < BX; i++)
            {
                for (int j = 0; j < BY; j++)
                {
                    Game_board[i, j] = false;
                }
            }
        }
        public void Draw_Board(Graphics g)
        {
            for (int i = 0; i < BX; i++)
            {
                for (int j = 0; j < BY; j++)
                {
                    if (Game_board[i, j])
                        Draw_Block(g, board_color, i, j);
                    else
                        Draw_Block(g, block_color, i, j);
                }
            }
        }
        public void Draw_Block(Graphics g, Color c, int x, int y)
        {
            g.FillRectangle(new SolidBrush(c), x*CS ,y*CS,CS,CS);
            g.DrawRectangle(new Pen(Color.DimGray), x*CS, y*CS,CS,CS);
        }
    }
}
