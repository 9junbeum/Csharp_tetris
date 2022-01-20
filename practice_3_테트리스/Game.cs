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
        Block on_game_Block = new Block().null_block(); //게임판에 있는 블럭

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

        public void Draw_Block(Graphics g, Color c, int x, int y, int cs)
        {
            //buffer = new Bitmap(BX,BY);
            //네모 블럭 하나 그리는것.
            g.FillRectangle(new SolidBrush(c), x * cs, y * cs, cs, cs);
            g.DrawRectangle(new Pen(Color.DimGray), x * cs, y * cs, cs, cs);
            
        }

        public void Draw_Board(Graphics g)
        {
            //현재 값으로 게임판 그리기 
            for (int i = 0; i < BX; i++)
            {
                for (int j = 0; j < BY; j++)
                {
                    if (Game_board[i, j] != 0)
                        Draw_Block(g, block_color, i, j, CS);
                    else
                        Draw_Block(g, board_color, i, j, CS);
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

        public void shift_block()
        {
            //새 블럭 -> 프리뷰 블럭 -> 온게임 블럭 -> 소비
            Block new_block = Get_New_Block();
            //프리뷰 블럭을 게임 블럭에 넣고 
            on_game_Block = preview_Block;
            //프리뷰 블럭에는 새 블럭을 넣는다.
            preview_Block = new_block;
            Draw_Preview(prev_g,preview_Block);
        }

        private void show_block()
        {
            int x = 3;
            int y = 0;
            for(int i = 0;i<4;i++)
            {
                for(int j = 0;j<4;j++)
                {
                    //블럭을 해당 위치에 꺼낸다
                    Game_board[i+3,j] = on_game_Block.shape[i,j];
                    
                }
            }
               
        }

        public void Move_Block(int key)
        {
            //키보드로 블럭 제어하는 것( <- , V , -> )
            // 0 : left
            // 1 : right
            // 2 : down

            switch(key)
            {
                case 0:
                    on_game_Block.mb_left();
                    break;

                case 1:
                    on_game_Block.mb_right();
                    break;

                case 2:
                    on_game_Block.mb_down();
                    break;
            }
        }
        public void Rotate_Block()
        {
            //회전
        }

        public void Drop_Block()
        {
            //떨어트리는것
        }

        //=================================================================================== 게임 컨트롤 ===================================================================================
        public void Game_routine() // 1tick
        {
            //1tick 마다 실행하는 함수.
            //기능 : 블록 가져오기, 블록을 한칸 아래로 움직이기, 점수 올리기 

            if(on_game_Block.Is_null_block())//블록이 없으면
            {
                shift_block();
                show_block();
            }
            else//블록이 있으면,
            {
                on_game_Block.mb_down();
            }

            Draw_Board(game_g);
        }


        public void block_landing()
        {
            //블록이 땅에 닿으면 실행되는 함수.
            //기능 : 가득찬 한줄 없애기, 없어진 한줄 위의 모든 블럭 한칸씩 내리기, 점수 올리기(한번에 없어진 줄 만큼 점수가 두배)

        }

    }
}
