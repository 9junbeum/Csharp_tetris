using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace practice_3_테트리스
{
    internal class Preview
    {
        Block preview_Block = new Block().null_block(); //프리뷰에 있는 블럭

        public Graphics prev_g = null;// 프리뷰에 그리는 그래픽 객체

        public const int PVX = 4;//미리보기 가로 넓이
        public const int PVY = 4;//미리보기 세로 넓이
        public const int PVCS = 38;//미리보기 Cell Size

        private Color block_color = Color.OrangeRed;    //블록색
        private Color board_color = Color.OldLace;    //배경색

        public int[,] Preview_board = new int[PVX, PVY];//미리보기 보드의 속성값


        public void PV_Get_New_Block()
        {
            //새로운 블럭을 생성하여 프리뷰에 넣음
            Block new_block = new Block();
            new_block.Create_Block();

            this.preview_Block = new_block;
        }
        public void Draw_Block(Graphics g, Color c, int x, int y, int cs)
        {
            //네모 블럭 하나 그리는것.
            g.FillRectangle(new SolidBrush(c), x * cs, y * cs, cs, cs);
            g.DrawRectangle(new Pen(Color.DimGray), x * cs, y * cs, cs, cs);

        }
        public void Draw_Preview(Graphics g, Block b)
        {
            // 블럭을 프리뷰에 그린다.
            for (int i = 0; i < PVX; i++)
            {
                for (int j = 0; j < PVY; j++)
                {
                    if (b.shape[i, j] != 0)
                        Draw_Block(g, block_color, i, j, PVCS);
                    else
                        Draw_Block(g, board_color, i, j, PVCS);
                }
            }
        }

    }
}
