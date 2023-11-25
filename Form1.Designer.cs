using System.Security.Cryptography.Pkcs;

namespace sudoku
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void init()
        {
            logic = new Logic();
            easy = new Button();
            medium = new Button();
            hard = new Button();
            check=new Button();
            empty=new Button(); 
            solu=new Button();
            easy.Text = "EASY";
            easy.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            easy.Size = new Size(200, 100);
            easy.Location = new Point(60, 650);
            easy.TextAlign = ContentAlignment.MiddleCenter;
            easy.Click += easy_click;
            medium.Text = "MEDIUM";
            medium.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            medium.Size = new Size(200, 100);
            medium.Location = new Point(300, 650);
            medium.TextAlign = ContentAlignment.MiddleCenter;
            medium.Click += medium_click;
            hard.Text = "HARD";
            hard.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            hard.Size = new Size(200, 100);
            hard.Location = new Point(540, 650);
            hard.TextAlign = ContentAlignment.MiddleCenter;
            hard.Click += hard_click;
            check.Text = "CHECK";
            check.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            check.Size = new Size(200, 100);
            check.Location = new Point(60, 750);
            check.TextAlign = ContentAlignment.MiddleCenter;
            check.Click += check_click;
            empty.Text = "EMPTY";
            empty.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            empty.Size = new Size(200, 100);
            empty.Location = new Point(300, 750);
            empty.TextAlign = ContentAlignment.MiddleCenter;
            empty.Click += empty_click;
            solu.Text = "SOLU";
            solu.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            solu.Size = new Size(200, 100);
            solu.Location = new Point(540, 750);
            solu.TextAlign = ContentAlignment.MiddleCenter;
            solu.Click += solu_click;
            win_or_not=new TextBox();
            win_or_not.Font= new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            win_or_not.TextAlign=HorizontalAlignment.Center;
            win_or_not.Text = "";
            win_or_not.Size=new Size(400, 100);
            win_or_not.Location = new Point(60,990);
            win_or_not.Enabled = false;

            grid = new TextBox[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j] = new TextBox();
                    grid[i, j].Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
                    grid[i, j].TabIndex = j + i * 9;
                    grid[i, j].TextAlign = HorizontalAlignment.Center;
                    grid[i, j].Text = "";
                    grid[i, j].Size = new Size(50, 61);
                    grid[i, j].Location = new Point(60 + j * 55, 15 + i * 66);
                }
        }

        private void Medium_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void add_to_control()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    Controls.Add(grid[i, j]);
            Controls.Add(easy);
            Controls.Add(hard);
            Controls.Add(medium);
            Controls.Add(check);
            Controls.Add(empty);
            Controls.Add(solu);
            Controls.Add(win_or_not);
        }
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 1090);
            Name = "Form1";
            Text = "SUDOKU";
            ResumeLayout(false);
        }

        public Button easy;
        public Button medium;
        public Button hard;
        public Button check;
        public Button empty;
        public Button solu;
        private Logic logic;
        public TextBox[,] grid;
        public TextBox win_or_not;
    }
}