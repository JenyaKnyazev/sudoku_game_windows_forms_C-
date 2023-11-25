namespace sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
            add_to_control();
        }
        private void easy_click(object sender, EventArgs e)
        {
            win_or_not.Text = "";
            win_or_not.BackColor = Color.Empty;
            int[,] mat = logic.generate_sudoku(36);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j].Text = "";
                    grid[i, j].Enabled = true;
                    grid[i, j].BackColor = Color.Yellow;
                    if (mat[i, j] > 0)
                    {
                        grid[i, j].Text = mat[i, j].ToString();
                        grid[i, j].BackColor = Color.Orange;
                        grid[i, j].Enabled = false;
                    }
                }
            }
        }
        private void medium_click(object sender, EventArgs e)
        {
            win_or_not.Text = "";
            win_or_not.BackColor = Color.Empty;
            int[,] mat = logic.generate_sudoku(27);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j].Text = "";
                    grid[i, j].Enabled = true;
                    grid[i, j].BackColor = Color.Yellow;
                    if (mat[i, j] > 0)
                    {
                        grid[i, j].Text = mat[i, j].ToString();
                        grid[i, j].BackColor = Color.Orange;
                        grid[i, j].Enabled = false;
                    }
                }
            }
        }
        private void hard_click(object sender, EventArgs e)
        {
            win_or_not.Text = "";
            win_or_not.BackColor = Color.Empty;
            int[,] mat = logic.generate_sudoku(18);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j].Text = "";
                    grid[i, j].Enabled = true;
                    grid[i, j].BackColor = Color.Yellow;
                    if (mat[i, j] > 0)
                    {
                        grid[i, j].Text = mat[i, j].ToString();
                        grid[i, j].BackColor = Color.Orange;
                        grid[i, j].Enabled = false;
                    }
                }
            }
        }
        private void check_click(object sender, EventArgs e) {
            int[,] arr = new int[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j].Text == "")
                        arr[i, j] = 0;
                    else
                         arr[i, j] = int.Parse(grid[i, j].Text);
                }
            int k = logic.check(arr);
            switch (k) {
                case 0:
                    win_or_not.Text = "Not Complate";
                    break;
                case 1:
                    win_or_not.Text = "CORRECT!!!";
                    win_or_not.BackColor = Color.Blue;
                    break;
                case -1:
                    win_or_not.Text = "Wrong";
                    win_or_not.BackColor=Color.Red;
                    break;
            }
        }
        private void empty_click(object sender, EventArgs e) {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j].Text = "";
                    grid[i, j].Enabled = true;
                    grid[i, j].BackColor = Color.Yellow;
                }
            }
        }
        private void solu_click(object sender, EventArgs e) {
            logic.clean_mat();
            int[,] arr = new int[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j].Text == "")
                        arr[i, j] = 0;
                    else
                    {
                        arr[i, j] = int.Parse(grid[i, j].Text);
                        logic.add_to_matrixes(int.Parse(grid[i, j].Text), i, j);
                    }
                }
            logic.start_rec=Environment.TickCount;
            if (logic.rec(arr, 0, 0) == false) {
                win_or_not.Text = "mistakes";
                return;
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j].Text = "";
                    grid[i, j].Enabled = true;
                    grid[i, j].BackColor = Color.Yellow;
                    if (arr[i, j] > 0)
                    {
                        grid[i, j].Text = arr[i, j].ToString();
                        grid[i, j].BackColor = Color.Orange;
                        grid[i, j].Enabled = false;
                    }
                }
            }
        }
    }
}