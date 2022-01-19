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

        private void Create_Block() //블럭을 새로 만든다.
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
