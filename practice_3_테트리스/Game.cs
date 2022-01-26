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

        public int[,] Game_board = new int[BX, BY];      //게임보드의 속성값(false, true)


        Bitmap buffer = new Bitmap(302, 602);

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

        private void Draw_in_buffer(Color c, int x, int y, int cs)
        {
            x *= cs;
            y *= cs;
            for (int i = 0; i < cs; i++)
            {
                for (int j = 0; j < cs; j++)
                {
                    if(i ==0 || j == 0 || i == (cs-1) || j == (cs-1))
                    {
                        buffer.SetPixel(i + x, j + y, Color.DimGray);
                    }
                    else
                    {
                        buffer.SetPixel(i + x, j + y, c);
                    }
                }
            }
        }
        private void Drawing(Color c, int x, int y, int cs)
        {
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
                    {
                        //Drawing(block_color, i, j, CS);
                        Draw_in_buffer(block_color, i, j, CS);
                    }
                    else
                    {
                        //Drawing(board_color, i, j, CS);
                        Draw_in_buffer(board_color, i, j, CS);
                    }
                }
            }
        }

        public void Draw_Block()
        {
            //블럭의 x,y좌표
            int x = on_game_Block.x;
            int y = on_game_Block.y;

            //이전 값으로 블록 지우기 

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (on_game_Block.shape[i, j] != 0)
                    {
                        //Drawing(board_color, i + x, j + y - 1, CS);
                        Draw_in_buffer(board_color, i + x, j + y - 1, CS);
                    }
                }
            }
            //현재 값으로 블록 그리기 
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (on_game_Block.shape[i, j] != 0)
                    {
                        //Drawing(block_color, i + x, j + y, CS);
                        Draw_in_buffer(block_color, i + x, j + y, CS);
                    }
                }
            }

        }
        public void Real_Draw()
        {
            this.game_g.DrawImageUnscaled(this.buffer, Point.Empty);
            //buffer.Dispose();
        }
        //=================================================================================== 조건 판독 ===================================================================================
        public int is_side_empty()
        {
            //빈 곳이 없으면 -1
            //왼쪽이 비었으면, 0
            //오른쪽이 비었으면, 1
            //양쪽이 비었으면, 2

            Boolean left_full = false;
            Boolean right_full = false;

            int block_x = on_game_Block.x;
            int block_y = on_game_Block.y;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (on_game_Block.shape[i, j] != 0) //4개의 색칠된 블럭에 관하여
                    {
                        //벽일 때
                        if (block_x + i == 0)
                        {
                            //제일 왼쪽일 때 
                            left_full = true;
                        }
                        else if (block_x + i == 9)
                        {
                            //제일 오른쪽일 때
                            right_full = true;
                        }
                        else
                        {
                            //벽은 아닐 때
                            if (Game_board[block_x + i - 1, block_y + j] != 0)
                            {
                                left_full = true;
                            }

                            if (Game_board[block_x + i + 1, block_y + j] != 0)
                            {
                                //오른쪽만 비었을 때
                                right_full = true;
                            }
                        }
                    }
                }
            }
            if (left_full)
            {
                if (right_full)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (right_full)
            {
                return 0;
            }
            return 2;
        }
        public Boolean is_land()
        {
            //땅이나 블록에 내려앉을때 true 리턴

            //색칠된 블럭의 시작 x,y 좌표
            int block_x = on_game_Block.x;
            int block_y = on_game_Block.y;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (on_game_Block.shape[i, j] != 0) //4개의 색칠된 블럭에 관하여
                    {
                        //땅에 닿았을 때
                        if ((j + block_y + 1) == 20)
                        {
                            marking(block_x, block_y);
                            return true;
                        }
                        //블럭에 닿았을 때
                        else if ((this.Game_board[i + block_x, j + block_y + 1] != 0))// 이부분 잘 고쳐야함
                        {
                            //하나라도 겹치면
                            marking(block_x, block_y);
                            return true;
                        }
                    }
                }
            }
            return false;

        }
        private void marking(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (on_game_Block.shape[i, j] != 0)
                    {
                        this.Game_board[x + i, y + j] = 1;
                    }
                }
            }
        }
        public Boolean is_overlap()
        {
            //현재 겹치는 상태인지, 아닌지 확인하여 
            //true false 로 반환하는 함수.

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (on_game_Block.shape[i, j] != 0)
                    {
                        if ((on_game_Block.x + i) >= 0 && (on_game_Block.x + i <= 9) && (on_game_Block.y + j >= 0) && (on_game_Block.y + j <= 19))
                        {
                            //정상범위
                            if (this.Game_board[on_game_Block.x + i, on_game_Block.y + j] != 0)
                            {
                                //겹치면,
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public int is_collect()
        {
            int score = 0;
            //한줄 완성되면, 점수 올리기.
            for (int i = 0; i < BY; i++)
            {
                int count = 0;
                for (int j = 0; j < BX; j++)
                {
                    if (this.Game_board[j, i] == 1)
                    {
                        count++;
                        if (count == 10)
                        {
                            delete_line(i);
                            score += 1;
                        }
                    }
                }
            }
            return score;
        }

        //=================================================================================== 계산  ===================================================================================
        private void delete_line(int i)
        {
            //i번째 한줄 지우고 땡기는 함수
            for (int j = 0; j < BX; j++)
            {
                //한줄 지워!
                this.Game_board[j, i] = 0;
            }
            for (int k = i - 1; k >= 0; k--)
            {
                for (int q = 0; q < BX; q++)
                {
                    this.Game_board[q, k + 1] = this.Game_board[q, k];
                }
            }

        }

        public void Drop()
        {
            //끝까지 떨어트리는 함수.
            for (int i = 0; i < BY; i++)
            {
                //계속 1씩 증가하면서 검사.
                if (is_land())
                {
                    marking(on_game_Block.x, on_game_Block.y);
                    break;
                }
                on_game_Block.y += 1;
            }
        }
        public void adjust_xy()
        {
            //rotate시 겹침방지를 위해 
            //좌우로 먼저 조정후 불가능하면, 위로 한칸
            //위로도 불가능하면, 원래대로 돌려놓는다.

            //색칠된 블럭의 시작 x,y 좌표
            int block_x = on_game_Block.x;
            int block_y = on_game_Block.y;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (on_game_Block.shape[i, j] != 0)//블럭에 한해
                    {
                        if (Game_board[block_x + i, block_y + j] != 0)
                        {
                            //겹치면,

                        }
                    }
                }
            }
        }
    }
}
