/**
* 命名空间: Matrix_Operations
*
* 功 能： N/A
* 类 名： Matrix
*
* Ver 	变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2020/4/18 下午 09:36:28 M Jiang 初版
*
* Copyright (c) 2019 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本人书面同意禁止向第三方披露．　│
*│　版权所有：*****有限公司 　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Operations {
    public class Matrix {
        public int GetM { get; }
        public int GetN { get; }
        public double[,] GetMatrix { get; set; }

        public Matrix(int row, int col) {
            GetM = row;
            GetN = col;
            GetMatrix = new double[GetM, GetN];
        }
    }
}
