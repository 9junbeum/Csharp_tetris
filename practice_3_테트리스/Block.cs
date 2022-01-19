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
        public int y;           // (x,y) 좌표
        public Boolean[,] shape = new Boolean[4,4];       // 블럭의 모양 (총 7가지)
        public Boolean Is_new;  //새 블럭인지 확인(떨어지는 개체)
        

        public Block() {} //생성자

        public Block Create_Block() //블럭을 새로 만든다.
        {
            Random random = new Random();       //random 클래스 생성
            int new_block = random.Next(0,7);   //random 클래스로 부터 0~6 난수 생성

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    this.shape[i,j] = BLOCK_SHAPE[new_block, 0,i,j];
                }
            }
            this.Is_new = true; //새거

            return this; //랜덤 모양의 블록 객체를 반환한다.
        }

        public void set_Block_Position(int x, int y)
        {
            this.x = x;
            this.y = y;
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

        public static readonly bool[,,,] BLOCK_SHAPE = new bool[7, 4, 4, 4] //블럭 모양, 회전 모양, 가로pixel, 세로 pixel 
        {
            {               //ㅁㅁㅁㅁ
                {
                    {false, false, true, false },
                    {false, false, true, false },
                    {false, false, true, false },
                    {false, false, true, false }
                },
                {
                    {false, false, false, false },
                    {true,  true,  true , true  },
                    {false, false, false, false },
                    {false, false, false, false }
                },
                {
                    {false, true, false, false },
                    {false, true, false, false },
                    {false, true, false, false },
                    {false, true, false, false }
                },
                {
                    {false, false, false, false },
                    {false, false, false, false },
                    {true,  true,  true,  true  },
                    {false, false, false, false }
                }
            },


            {             //ㅁㅁ                           
                {        // ㅁㅁ
                    {false, false, false, false },
                    {false, true,  true,  false },
                    {false, true,  true,  false },
                    {false, false, false, false }
                },
                {
                    {false, false, false, false },
                    {false, true,  true,  false },
                    {false, true,  true,  false },
                    {false, false, false, false }
                },
                {
                    {false, false, false, false },
                    {false, true,  true,  false },
                    {false, true,  true,  false },
                    {false, false, false, false }
                },
                {
                    {false, false, false, false },
                    {false, true,  true,  false },
                    {false, true,  true,  false },
                    {false, false, false, false }
                }
            },
            
                         //   ㅁ
            {            // ㅁㅁ
                {        // ㅁ
                    {false, false, true, false },
                    {false, true, true, false },
                    {false, true, false, false },
                    {false, false, false, false }
                },
                {
                    {false, true,  true,  false},
                    {false, false, true,  true },
                    {false, false, false, false},
                    {false, false, false, false}
                },
                {
                    {false, false, true, false },
                    {false, true, true, false },
                    {false, true, false, false },
                    {false, false, false, false }
                },
                {
                    {false, true,  true,  false},
                    {false, false, true,  true },
                    {false, false, false, false},
                    {false, false, false, false}
                }
            },

                        //ㅁ
            {           //ㅁㅁ
                {       //  ㅁ
                    {false, true, false, false },
                    {false, true, true, false },
                    {false, false, true, false },
                    {false, false, false, false }
                },
                {
                    {false, false, false, false },
                    {false, false, true, true },
                    {false, true, true, false },
                    {false, false, false, false }
                },
                {
                    {false, true, false, false },
                    {false, true, true, false },
                    {false, false, true, false },
                    {false, false, false, false }
                },
                {
                    {false, false, false, false },
                    {false, false, true, true },
                    {false, true, true, false },
                    {false, false, false, false }
                }
            },

            {            //ㅁ
                {        //ㅁㅁㅁ
                    {false, false, false, false },
                    {false, true,  false, false },
                    {false, true,  true,  true  },
                    {false, false, false, false }
                },
                {
                    {false, true,  true,  false },
                    {false, true,  false, false },
                    {false, true,  false, false },
                    {false, false, false, false }
                },
                {
                    {false, false, false, false },
                    {false, true,  true,  true },
                    {false, false, false, true },
                    {false, false, false, false }
                },
                {
                    {false, false, false, true },
                    {false, false, false, true },
                    {false, false, true,  true },
                    {false, false, false, false }
                }
            },


            {         //    ㅁ
                {     //ㅁㅁㅁ
                    {false, false, false, false },
                    {false, false, false, true },
                    {false, true, true, true },
                    {false, false, false, false }
                },
                {
                    {false, false, true, false },
                    {false, false, true, false },
                    {false, false, true, true },
                    {false, false, false, false }
                },
                {
                    {false, false, false, false },
                    {false, true, true, true },
                    {false, true, false, false },
                    {false, false, false, false }
                },
                {
                    {false, true, true, false },
                    {false, false, true, false },
                    {false, false, true, false },
                    {false, false, false, false }
                }
            },



            {           //  ㅁ
                {       //ㅁㅁㅁ
                    {false, false, true, false },
                    {false, true, true, true },
                    {false, false, false, false },
                    {false, false, false, false }
                },
                {
                    {false, false, true, false },
                    {false, false, true, true },
                    {false, false, true, false },
                    {false, false, false, false }
                },
                {
                    {false, false, false, false },
                    {false, true, true, true },
                    {false, false, true, false },
                    {false, false, false, false }
                },
                {
                    {false, false, true, false },
                    {false, true, true, false },
                    {false, false, true, false },
                    {false, false, false, false }
                }
            }

        };
    }
}
