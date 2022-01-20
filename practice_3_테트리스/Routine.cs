using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace practice_3_테트리스
{
    internal class Routine
    {
        public Game new_game = new Game(); //게임판 객체
        public Preview new_preview = new Preview();//프리뷰 객체

        public Boolean Is_Play = false; //게임중인가?
        public int score = 0;               //점수

        public void Reset_Game()
        {

        }

        public void Start_Game()
        {
            //게임시작시 최초 한번만 실행.

            new_game.Init_Game_Board();  //배경 초기화
            new_game.score = 0;     //점수 초기화
            new_game.Is_Play = true;//상태 -> 게임중

            //자..... 게임을 시작하지... ^@o@^
        }
    }
}
