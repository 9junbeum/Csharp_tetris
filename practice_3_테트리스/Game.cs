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
        public Block on_game_Block = new Block().null_block(); //게임판에 있는 블럭

        public Graphics game_g = null;// 게임판에 그리는 그래픽 객체

        public const int BX = 10;//게임판 가로 넓이
        public const int BY = 20;//게임판 세로 넓이
        public const int CS = 30;//Cell Size (한칸의 크기)

        private Color block_color = Color.OrangeRed;    //블록색
        private Color board_color = Color.OldLace;    //배경색

        public int[,] Game_board = new int[BX,BY];      //게임보드의 속성값(false, true)


        //Bitmap buffer = new Bitmap(BX,BY);

        public void Init_Game_Board()
        {
            //게임 보드의 모든 구성요소를 0 으로 변경하여 비어있는 상태로 만든다.
            for (int i = 0; i < BX; i++)
            {
                for (int j = 0; j < BY; j++)
                {
                    Game_board[i, j] = 0;
                }
            }
        }
        


        //=================================================================================== 그림 그리기 ===================================================================================

        private void Draw_Block(Color c, int x, int y, int cs)
        {
            //buffer = new Bitmap(BX,BY);
            //네모 블럭 하나 그리는것.
            this.game_g.FillRectangle(new SolidBrush(c), x * cs, y * cs, cs, cs);
            this.game_g.DrawRectangle(new Pen(Color.DimGray), x * cs, y * cs, cs, cs);
            
        }

        public void Draw_Board()
        {
            //현재 값으로 게임판 그리기 
            for (int i = 0; i < BX; i++)
            {
                for (int j = 0; j < BY; j++)
                {
                    if (Game_board[i, j] != 0)
                        Draw_Block(block_color, i, j, CS);
                    else
                        Draw_Block(board_color, i, j, CS);
                }
            }
            //buffer.
            //buffer.Dispose();
        }


        //=================================================================================== 블록 컨트롤 ===================================================================================

        public Block Get_New_Block()
        {
            //새로운 블럭을 생성하여 반환함.
            Block new_block = new Block();
            new_block.Create_Block();

            return new_block;
        }

    }
}
