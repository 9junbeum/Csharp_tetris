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

        public const int PVX = 4;//미리보기 가로 넓이
        public const int PVY = 4;//미리보기 세로 넓이
        public const int PVCS = 38;//미리보기 Cell Size

        Color block_color = Color.OrangeRed;    //블록색
        Color board_color = Color.OldLace;    //배경색

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
            //네모 블럭 하나 그리는것.
            //
            g.FillRectangle(new SolidBrush(c), x * cs, y * cs, cs, cs);
            g.DrawRectangle(new Pen(Color.DimGray), x * cs, y * cs, cs, cs);
        }

        public void Draw_Preview(Graphics g)
        {
            // 블럭을 하나 생성해 프리뷰에 그린다.
            Block prev_b = Get_Block();
            prev_b.set_Block_Position(1, 1);

            for (int i = 0; i < PVX; i++)
            {
                for (int j = 0; j < PVY; j++)
                {
                    if (prev_b.shape[i,j])
                        Draw_Block(g, block_color, i, j, PVCS);
                    else
                        Draw_Block(g, board_color, i, j, PVCS);
                }
            }
        }

        public void Place_on_board()
        {
            //프리뷰의 블럭을 가지고 와 보드에 가지고 온다.
        }

        public void Draw_Board(Graphics g)
        {
            for (int i = 0; i < BX; i++)
            {
                for (int j = 0; j < BY; j++)
                {
                    if (Game_board[i, j])
                        Draw_Block(g, block_color, i, j, CS);
                    else
                        Draw_Block(g, board_color, i, j, CS);
                }
            }
        }

        public Block Get_Block()
        {
            //새로운 블럭을 생성하여 반환함.

            Block new_block = new Block();
            new_block.Create_Block();

            return new_block;
        }
    }
}
