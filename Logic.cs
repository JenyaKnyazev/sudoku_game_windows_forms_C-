using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    internal class Logic
    {
        private int[,] field;
        private bool[,] cols;
        private bool[,] rows;
        private bool[,] squares;
        private Random rnd;
        public int start_rec;
        public Logic() {
            field = new int[9, 9];
            cols = new bool[9, 9];
            rows = new bool[9, 9];
            squares = new bool[9, 9];
            rnd = new Random();
        }
        public int[,] generate_sudoku(int full_cells) {
            do {
                for (int i = 0; i < 81; i++)
                {
                    squares[i / 9, i % 9] = false;
                    cols[i / 9, i % 9] = false;
                    rows[i / 9, i % 9] = false;
                    field[i / 9, i % 9] = 0;
                }
                for (int i = 0; i < 12; i++) {
                    int num = rnd.Next(1, 10);
                    int row;
                    int col;
                    do
                    {
                        row = rnd.Next(1, 10);
                        col = rnd.Next(1, 10);
                    } while (is_posible(num, row - 1, col - 1) == false);
                    add_to_matrixes(num, row - 1, col - 1);
                    field[row - 1, col - 1] = num;
                }
                start_rec=Environment.TickCount;
            }while(rec(field, 0, 0)==false);
            int empty_cells = 81 - full_cells;
            while (empty_cells > 0) {
                int row, col;
                do
                {
                    row=rnd.Next(1, 10);
                    col=rnd.Next(1, 10);
                } while (field[row-1, col-1] == 0);
                field[row-1, col-1] = 0;
                empty_cells--;
            }
            return field;
        }
        public void clean_mat() {

            for (int i = 0; i < 81; i++)
            {
                squares[i / 9, i % 9] = false;
                cols[i / 9, i % 9] = false;
                rows[i / 9, i % 9] = false;
                field[i / 9, i % 9] = 0;
            }
        }
        public int check(int[,]field) {
            for (int i = 0; i < 81; i++)
            {
                cols[i / 9, i % 9] = false;
                rows[i / 9, i % 9] = false;
                squares[i / 9, i % 9] = false;
            }
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++) {
                    if (field[i, j] == 0)
                        return 0;
                    if (is_posible(field[i, j], i, j))
                    {
                        add_to_matrixes(field[i, j], i, j);
                    }
                    else
                        return -1;
                }
            return 1;
        }
        bool is_posible(int num, int row, int col) {
            return (!rows[row, num - 1]) && (!cols[col, num - 1]) &&
                (!squares[row / 3 * 3 + col / 3, num-1]);
        }
        public void add_to_matrixes(int num, int row, int col) {
            rows[row , num - 1] = true;
            cols[col, num - 1] = true;
            squares[row  / 3 * 3  + col / 3, num - 1] = true;
        }
        void remove_from_matrixes(int num, int row, int col) {
            rows[row , num - 1] = false;
            cols[col, num - 1] = false;
            squares[row / 3 * 3 + col / 3, num - 1] = false;
        }
        public bool rec(int[,]field,int row,int col) {
            bool solved = false;
            if (Environment.TickCount - start_rec > 200)
                return false;
            if (col == 9)
            {
                col = 0;
                row++;
            }
            if (row == 9)
                return true;
                if (field[row, col]==0)
                {
                    
                    for (int i = 1; i < 10&&!solved; i++)
                    {

                        if (is_posible(i, row, col) && (solved == false))
                        {
                            add_to_matrixes(i, row, col);
                            field[row , col ] = i;
                            solved = rec(field, row, col + 1);
                            if (!solved)
                            {
                                remove_from_matrixes(i, row, col);
                                field[row, col] = 0;
                            }
                        }
                        
                    }
                    return solved;
                }else
                    solved= rec(field, row, col+1);
            return solved;
        }
    }
}
