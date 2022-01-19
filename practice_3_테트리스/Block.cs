using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_3_테트리스
{
    internal class Block
    {
        //멤버 변수
        public int x;
        public int y;       // (x,y) 좌표
        public int shape;   // 블럭의 모양 (총 7가지)

        

        public Block() {} //생성자

        string Block_Shape = "";
        string Block_Color = "";

        private void Create_Block() 
        {
            Random random = new Random();

        }

        private void MoveLeft()
        {
            this.x--;
        }
        private void MoveRight()
        {
            this.x++;
        }
        private void MoveDown()
        {
            this.y++;
        }


    }
}
