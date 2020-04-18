/**
* 命名空间: Matrix_Operations
*
* 功 能： N/A
* 类 名： MatrixOperate
*
* Ver 	变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2020/4/18 下午 09:50:59 M Jiang 初版
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
    class MatrixOperate {
        /// <summary>
        /// 矩阵加法
        /// </summary>
        /// <param name="Ma">矩阵A</param>
        /// <param name="Mb">矩阵B</param>
        /// <returns></returns>
        public static Matrix MatrixAdd(Matrix Ma, Matrix Mb) {
            int m1 = Ma.GetM;
            int n1 = Ma.GetN;
            int m2 = Mb.GetM;
            int n2 = Mb.GetN;
            if ((m1 != m2) || (n1 != n2)) {
                Exception exception = new Exception("所输入数组维度不匹配");
                throw exception;
            }
            Matrix Mc = new Matrix(m1, n1);

            double[,] a = Ma.GetMatrix;
            double[,] b = Mb.GetMatrix;
            double[,] c = Mc.GetMatrix;

            for (int i = 0; i < m1; i++) {
                for (int j = 0; j < n1; j++) {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }

            return Mc;

        }

        /// <summary>
        /// 矩阵减法
        /// </summary>
        /// <param name="Ma">矩阵A</param>
        /// <param name="Mb">矩阵B</param>
        /// <returns></returns>
        public static Matrix MatrixSub(Matrix Ma, Matrix Mb) {
            int m1 = Ma.GetM;
            int n1 = Ma.GetN;
            int m2 = Mb.GetM;
            int n2 = Mb.GetN;
            if ((m1 != m2) || (n1 != n2)) {
                Exception exception = new Exception("所输入数组维度不匹配");
                throw exception;
            }
            Matrix Mc = new Matrix(m1, n1);

            double[,] a = Ma.GetMatrix;
            double[,] b = Mb.GetMatrix;
            double[,] c = Mc.GetMatrix;

            for (int i = 0; i < m1; i++) {
                for (int j = 0; j < n1; j++) {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }

            return Mc;

        }

        /// <summary>
        /// 矩阵数乘
        /// </summary>
        /// <param name="Ma">矩阵A</param>
        /// <param name="Mb">矩阵B</param>
        /// <returns></returns>
        public static Matrix MatrixNumMulti(Matrix Ma, double n) {
            int m1 = Ma.GetM;
            int n1 = Ma.GetN;

            Matrix Mc = new Matrix(m1, n1);

            double[,] a = Ma.GetMatrix;

            double[,] c = Mc.GetMatrix;

            for (int i = 0; i < m1; i++) {
                for (int j = 0; j < n1; j++) {
                    c[i, j] = a[i, j] * n;
                }
            }

            return Mc;

        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        /// <param name="Ma">矩阵A</param>
        /// <param name="Mb">矩阵B</param>
        /// <returns></returns>
        public static Matrix MatrixMulti(Matrix Ma, Matrix Mb) {
            int m1 = Ma.GetM;
            int n1 = Ma.GetN;
            int m2 = Mb.GetM;
            int n2 = Mb.GetN;
            if (n1 != m2) {
                Exception exception = new Exception("所输入数组维度不匹配");
                throw exception;
            }
            Matrix Mc = new Matrix(m1, n2);

            double[,] a = Ma.GetMatrix;
            double[,] b = Mb.GetMatrix;
            double[,] c = Mc.GetMatrix;

            for (int i = 0; i < m1; i++) {
                for (int j = 0; j < n2; j++) {

                    for (int k = 0; k < n1; k++) {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return Mc;
        }

        /// <summary>
        /// 矩阵转置
        /// </summary>
        /// <param name="MatrixOrigin">原始矩阵</param>
        /// <returns></returns>
        public static Matrix MatrixTrans(Matrix MatrixOrigin) {
            int m = MatrixOrigin.GetM;
            int n = MatrixOrigin.GetN;
            Matrix MatrixNew = new Matrix(n, m);
            double[,] c = MatrixNew.GetMatrix;
            double[,] a = MatrixOrigin.GetMatrix;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    c[i, j] = a[j, i];
            return MatrixNew;
        }

        /// <summary>
        /// 矩阵求逆（伴随矩阵法）
        /// </summary>
        /// <param name="Ma">原始矩阵</param>
        /// <returns></returns>
        public static Matrix MatrixInvByCom(Matrix Ma) {
            double d = MatrixDet(Ma);
            if (d == 0) {
                Exception myException = new Exception("没有逆矩阵");
                throw myException;
            }
            Matrix Ax = MatrixCom(Ma);
            Matrix An = MatrixNumMulti(Ax, (1.0 / d));
            return An;
        }

        /// <summary>
        /// 对应行列式的代数余子式矩阵
        /// </summary>
        /// <param name="Ma"></param>
        /// <param name="ai"></param>
        /// <param name="aj"></param>
        /// <returns></returns>
        private static Matrix MatrixSpa(Matrix Ma, int ai, int aj) {
            int m = Ma.GetM;
            int n = Ma.GetN;
            if (m != n) {
                Exception myException = new Exception("矩阵不是方阵");
                throw myException;
            }
            int n2 = n - 1;
            Matrix Mc = new Matrix(n2, n2);
            double[,] a = Ma.GetMatrix;
            double[,] b = Mc.GetMatrix;

            //左上
            for (int i = 0; i < ai; i++)
                for (int j = 0; j < aj; j++) {
                    b[i, j] = a[i, j];
                }
            //右下
            for (int i = ai; i < n2; i++)
                for (int j = aj; j < n2; j++) {
                    b[i, j] = a[i + 1, j + 1];
                }
            //右上
            for (int i = 0; i < ai; i++)
                for (int j = aj; j < n2; j++) {
                    b[i, j] = a[i, j + 1];
                }
            //左下
            for (int i = ai; i < n2; i++)
                for (int j = 0; j < aj; j++) {
                    b[i, j] = a[i + 1, j];
                }
            //符号位
            if ((ai + aj) % 2 != 0) {
                for (int i = 0; i < n2; i++)
                    b[i, 0] = -b[i, 0];

            }
            return Mc;

        }

        /// <summary>
        /// 矩阵的行列式
        /// </summary>
        /// <param name="Ma">原始矩阵</param>
        /// <returns></returns>
        public static double MatrixDet(Matrix Ma) {
            int m = Ma.GetM;
            int n = Ma.GetN;
            if (m != n) {
                Exception myException = new Exception("数组维数不匹配");
                throw myException;
            }
            double[,] a = Ma.GetMatrix;
            if (n == 1) return a[0, 0];

            double D = 0;
            for (int i = 0; i < n; i++) {
                D += a[1, i] * MatrixDet(MatrixSpa(Ma, 1, i));
            }
            return D;
        }
        
        /// <summary>
        /// 矩阵的伴随矩阵
        /// </summary>
        /// <param name="Ma">原始矩阵</param>
        /// <returns></returns>
        private static Matrix MatrixCom(Matrix Ma) {
            int m = Ma.GetM;
            int n = Ma.GetN;
            Matrix Mc = new Matrix(m, n);
            double[,] c = Mc.GetMatrix;
            double[,] a = Ma.GetMatrix;

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    c[i, j] = MatrixDet(MatrixSpa(Ma, j, i));

            return Mc;
        }
    }
}
