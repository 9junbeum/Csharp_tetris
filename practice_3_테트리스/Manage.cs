﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace practice_3_테트리스
{
    internal class Manage
    {
        public Game new_game = new Game(); //게임판 객체
        public Preview new_preview = new Preview();//프리뷰 객체

        public Graphics game_g = null;// 게임판에 그리는 그래픽 객체
        public Graphics prev_g = null;// 프리뷰에 그리는 그래픽 객체

        public Boolean Is_Play = false; //게임중인가?
        public int score = 0;               //점수

        public void Reset_Game()
        {
            //게임 리셋
            this.new_game = new Game();
            this.new_preview = new Preview();
            deliver_g();

            Start_Game();
        }

        public void Start_Game()
        {
            //게임시작시 최초 한번만 실행.

            //그리기 Graphics 넘겨줌.

            new_game.Init_Game_Board();  //배경 초기화
            this.score = 0;     //점수 초기화
            this.Is_Play = true;//상태 -> 게임중

            //다르게 manage하자
            new_preview.PV_Get_New_Block(); //최초 1회 프리뷰에 블럭을 넣는다.
            new_preview.Draw_Preview();
            //자..... 게임을 시작하지... ^@o@^
        }

        public void deliver_g()
        {
            this.new_game.game_g = this.game_g;
            this.new_preview.prev_g = this.prev_g;
        }

        public void shift_block()
        {
            //새 블럭 -> 프리뷰 블럭 -> 온게임 블럭 -> 소비
            Block new_block = new Block();
            new_block.Create_Block();
            //프리뷰 블럭을 게임 블럭에 넣고 
            new_game.on_game_Block = new_preview.preview_Block;
            //프리뷰 블럭에는 새 블럭을 넣는다.
            new_preview.preview_Block = new_block;
            this.new_preview.Draw_Preview();
        }


        public void Move_Block(int key)
        {
            //키보드로 블럭 제어하는 것( <- , V , -> )
            // 0 : left
            // 1 : right
            // 2 : down

            switch (key)
            {
                case 0:
                    if(new_game.is_side_empty() == 0 || new_game.is_side_empty() == 2)//왼쪽이 비었으면, 
                    {
                        new_game.on_game_Block.mb_left();
                        new_game.Draw_Board();
                        new_game.Draw_Block();
                    }
                    break;

                case 1:
                    if (new_game.is_side_empty() == 1 || new_game.is_side_empty() == 2)//오른쪽이 비었으면, 
                    {
                        new_game.on_game_Block.mb_right();
                        new_game.Draw_Board();
                        new_game.Draw_Block();
                    }
                    break;

                case 2:
                    if (new_game.is_land())
                    {
                        //움직여서 내려앉으면
                        calc_score();
                        shift_block();
                    }
                    else
                    {
                        new_game.on_game_Block.mb_down();
                        new_game.Draw_Board();
                        new_game.Draw_Block();
                    }
                    break;
            }
        }
        public void Rotate_Block()
        {
            //회전
            new_game.on_game_Block.rotate();
            new_game.Draw_Board();
            new_game.Draw_Block();
        }

        public void Drop_Block()
        {
            //떨어트리는것
            new_game.Drop();
            new_game.Draw_Board();
            new_game.Draw_Block();
            calc_score();
            shift_block();
        }

        //=================================================================================== 게임 컨트롤 ===================================================================================
        public void Game_routine() // 1tick
        {
            score += 1;
            //1tick 마다 실행하는 함수.
            //기능 : 블록 가져오기, 블록을 한칸 아래로 움직이기, 점수 올리기 

            if (new_game.on_game_Block.Is_null_block())//블록이 없으면
            {
                shift_block();
                new_game.Draw_Board();
                //show_block();
            }
            else//블록이 있으면,
            {
                //땅에 닿거나 블럭에 닿으면,
                if(new_game.is_land())
                {
                    //한줄이 완성됐다면, 점수계산하는 함수
                    calc_score();
                    //블럭을 교체해주는 함수.
                    shift_block();
                }
                new_game.on_game_Block.mb_down();
            }
            new_game.Draw_Board();
            new_game.Draw_Block();
        }

        private void calc_score()
        {
            //점수 계산하는 함수
            for (int i = 0; i < new_game.is_collect(); i++)
            {
                int xx = new_game.is_collect();
                //점수 차등 배분
                switch (xx)
                {
                    case 0:
                        break;
                    case 1:
                        score += 100;
                        break;
                    case 2:
                        score += 300;
                        break;
                    case 3:
                        score += 600;
                        break;
                    case 4:
                        score += 1000;
                        break;
                }
            }
        }
        public void block_landing()
        {
            //블록이 땅에 닿으면 실행되는 함수.
            //기능 : 가득찬 한줄 없애기, 없어진 한줄 위의 모든 블럭 한칸씩 내리기, 점수 올리기(한번에 없어진 줄 만큼 점수가 두배)

        }
    }
}
