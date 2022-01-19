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

        public const int PVX = 6;//미리보기 가로 넓이
        public const int PVY = 6;//미리보기 세로 넓이
        public const int PVCS = 25;//미리보기 Cell Size

        Color block_color = Color.MistyRose;    //블록색 하늘
        Color board_color = Color.RosyBrown;    //배경색 블랙

        public Boolean[,] Game_board = new Boolean[BX,BY];      //게임보드의 속성값(false, true)
        public Boolean[,] Preview_board = new Boolean[PVX, PVY];//미리보기 보드의 속성값
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


        public void Draw_Block(Graphics g, Color c, int x, int y, int cs)
        {
            g.FillRectangle(new SolidBrush(c), x * cs, y * cs, cs, cs);
            g.DrawRectangle(new Pen(Color.DimGray), x * cs, y * cs, cs, cs);
        }

        public void Draw_Preview(Graphics g)
        {
            for (int i = 0; i < PVX; i++)
            {
                for (int j = 0; j < PVY; j++)
                {
                    if (Game_board[i, j])
                        Draw_Block(g, board_color, i, j, PVCS);
                    else
                        Draw_Block(g, block_color, i, j, PVCS);
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
                        Draw_Block(g, board_color, i, j, CS);
                    else
                        Draw_Block(g, block_color, i, j, CS);
                }
            }
        }
    }
}
