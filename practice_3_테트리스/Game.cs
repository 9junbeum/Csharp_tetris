﻿using System;
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

        private void Drawing(Color c, int x, int y, int cs)
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
                        Drawing(block_color, i, j, CS);
                    else
                        Drawing(board_color, i, j, CS);
                }
            }
            //buffer.
            //buffer.Dispose();
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
                        Drawing(board_color, i + x, j + y - 1, CS);
                    }
                }
            }
            //현재 값으로 블록 그리기 
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(on_game_Block.shape[i,j] != 0)
                    {
                        Drawing(block_color, i + x, j + y, CS);
                    }
                }
            }

            //buffer.
            //buffer.Dispose();
        }

        public Boolean is_land()
        {
            //땅이나 블록에 내려앉을때 true 리턴
            //색칠된 블럭의 x,y 좌표

            int block_x = on_game_Block.x;
            int block_y = on_game_Block.y;

            for (int i = 0; i < 4;i++)
            {
                for(int j = 0; j < 4;j++)
                {
                    if(on_game_Block.shape[i,j] != 0)
                    {
                        if((this.Game_board[i+block_x,j+block_y] != 0) ||(j+block_y)>=BY)
                        {
                            //하나라도 겹치면
                            marking(block_x, block_y-1);
                            return true;
                        }
                    }
                }
            }
            return false;

        }
        private void marking(int x, int y)
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0;j < 4;j++)
                {
                    this.Game_board[x+i,y+j] = 1;
                }
            }
        }

        public int is_collect()
        {
            int score = 0;
            //한줄 완성되면, 점수 올리기.
            for(int i = 0;i < BY;i++)
            {
                int count = 0;
                for(int j = 0;j < BX;j++)
                {
                    if(this.Game_board[j,i] == 1)
                    {
                        count++;
                        if(count == 10)
                        {
                            delete_line();
                            score += 1;
                        }
                    }
                }
            }
            return score;
        }
        private void delete_line()
        {
            //한줄 지우고 땡기는 함수
        }
    }
}
