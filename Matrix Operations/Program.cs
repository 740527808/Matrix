using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Operations {
    class Program {
        static void Main(string[] args) {
            double[,] d1 = new double[2, 2] { { 1, 2 }, { -1, -3 } };
            Matrix Ma = new Matrix(2, 2) {
                GetMatrix = d1
            };

            double[,] d2 = new double[3, 2] { { 10, 5 }, { 8, 2 }, { 15, 3 } };
            Matrix Mb = new Matrix(3, 2) {
                GetMatrix = d2
            };


            Matrix Mc = MatrixOperate.MatrixInvByCom(Ma);
            double[,] d3 = Mc.GetMatrix;
            for (int i = 0; i < Mc.GetM; i++) {
                for (int j = 0; j < Mc.GetN; j++) {
                    Console.Write(d3[i, j] + " ");
                }
                Console.WriteLine();
            }
        }



    }
}
