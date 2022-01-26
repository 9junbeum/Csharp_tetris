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
        public int x, y;//블럭의 위치
        public int[,] shape = new int[4, 4];       // 블럭의 모양 (총 7가지)
        public int Bnum;//블록 넘버
        public int Snum;//모양 넘버

        public Block()//생성자
        {
            this.x = 0;
            this.y = 0;
            this.Bnum = -1;
            this.Snum = 0;
        }

        public Boolean Is_null_block()
        {
            //빈 블럭이면 true
            //
            if (Bnum == -1)
                return true;
            else
                return false;
        }
        public Block null_block()
        {
            //빈블럭 만들어서 블럭을 반환한다.
            this.x = 0;
            this.y = 0;
            this.Bnum = -1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.shape[i, j] = 0;
                }
            }
            return this;
        }

        public Block Create_Block() //블럭을 새로 만든다.
        {
            Random random = new Random();       //random 클래스 생성
            int new_block = random.Next(0, 7);   //random 클래스로 부터 0~6 난수 생성
            this.Bnum = new_block;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.shape[i, j] = BLOCK_SHAPE[new_block, Snum, i, j];
                }
            }
            return this; //랜덤 모양의 블록 객체를 반환한다.
        }

        public void mb_left()
        {
            this.x--;
        }
        public void mb_right()
        {
            this.x++;
        }
        public void mb_down()
        {
            this.y++;
        }
        public void rotate()
        {
            this.Snum++;
            if (this.Snum == 4)
            {
                this.Snum = 0;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.shape[i, j] = BLOCK_SHAPE[this.Bnum, this.Snum, i, j];
                }
            }
        }

        public void rotate_()
        {
            this.Snum--;
            if (this.Snum == -1)
            {
                this.Snum = 3;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.shape[i, j] = BLOCK_SHAPE[this.Bnum, this.Snum, i, j];
                }
            }
        }
        public static readonly int[,,,] BLOCK_SHAPE = new int[7, 4, 4, 4] //블럭 모양, 회전 모양, 가로pixel, 세로 pixel 
        {
            {               //ㅁㅁㅁㅁ
                {
                    {0, 0, 1, 0 },
                    {0, 0, 1, 0 },
                    {0, 0, 1, 0 },
                    {0, 0, 1, 0 }
                },
                {
                    {0, 0, 0, 0 },
                    {1, 1, 1, 1 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 1, 0, 0 },
                    {0, 1, 0, 0 },
                    {0, 1, 0, 0 },
                    {0, 1, 0, 0 }
                },
                {
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 },
                    {1, 1, 1, 1 },
                    {0, 0, 0, 0 }
                }
            },


            {             //ㅁㅁ                           
                {        // ㅁㅁ
                    {0, 0, 0, 0 },
                    {0, 1, 1, 0 },
                    {0, 1, 1, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 0, 0 },
                    {0, 1, 1, 0 },
                    {0, 1, 1, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 0, 0 },
                    {0, 1, 1, 0 },
                    {0, 1, 1, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 0, 0 },
                    {0, 1, 1, 0 },
                    {0, 1, 1, 0 },
                    {0, 0, 0, 0 }
                }
            },
            
                         //   ㅁ
            {            // ㅁㅁ
                {        // ㅁ
                    {0, 0, 1, 0 },
                    {0, 1, 1, 0 },
                    {0, 1, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 1, 1, 0 },
                    {0, 0, 1, 1 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 1, 0 },
                    {0, 1, 1, 0 },
                    {0, 1, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 1, 1, 0 },
                    {0, 0, 1, 1 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 }
                }
            },

                        //ㅁ
            {           //ㅁㅁ
                {       //  ㅁ
                    {0, 1, 0, 0 },
                    {0, 1, 1, 0 },
                    {0, 0, 1, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 0, 0 },
                    {0, 0, 1, 1 },
                    {0, 1, 1, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 1, 0, 0 },
                    {0, 1, 1, 0 },
                    {0, 0, 1, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 0, 0 },
                    {0, 0, 1, 1 },
                    {0, 1, 1, 0 },
                    {0, 0, 0, 0 }
                }
            },

            {            //ㅁ
                {        //ㅁㅁㅁ
                    {0, 0, 0, 0 },
                    {0, 1, 0, 0 },
                    {0, 1, 1, 1 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 1, 1, 0 },
                    {0, 1, 0, 0 },
                    {0, 1, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 0, 0 },
                    {0, 1, 1, 1 },
                    {0, 0, 0, 1 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 0, 1 },
                    {0, 0, 0, 1 },
                    {0, 0, 1, 1 },
                    {0, 0, 0, 0 }
                }
            },


            {         //    ㅁ
                {     //ㅁㅁㅁ
                    {0, 0, 0, 0 },
                    {0, 0, 0, 1 },
                    {0, 1, 1, 1 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 1, 0 },
                    {0, 0, 1, 0 },
                    {0, 0, 1, 1 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 0, 0 },
                    {0, 1, 1, 1 },
                    {0, 1, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 1, 1, 0 },
                    {0, 0, 1, 0 },
                    {0, 0, 1, 0 },
                    {0, 0, 0, 0 }
                }
            },



            {           //  ㅁ
                {       //ㅁㅁㅁ
                    {0, 0, 1, 0 },
                    {0, 1, 1, 1 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 1, 0 },
                    {0, 0, 1, 1 },
                    {0, 0, 1, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 0, 0 },
                    {0, 1, 1, 1 },
                    {0, 0, 1, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 0, 1, 0 },
                    {0, 1, 1, 0 },
                    {0, 0, 1, 0 },
                    {0, 0, 0, 0 }
                }
            }

        };
    }
}
