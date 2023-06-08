namespace BattleShipApp
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnMain1 = new Button();
            txtConsola = new TextBox();
            btnConsola = new Button();
            btnMain2 = new Button();
            btnMain3 = new Button();
            btnBattle4 = new Button();
            btn = new Button();
            SuspendLayout();
            // 
            // btnMain1
            // 
            btnMain1.Location = new Point(7, 51);
            btnMain1.Name = "btnMain1";
            btnMain1.Size = new Size(86, 29);
            btnMain1.TabIndex = 5;
            btnMain1.Text = "Main 1";
            btnMain1.UseVisualStyleBackColor = true;
            // 
            // txtConsola
            // 
            txtConsola.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtConsola.Location = new Point(118, 13);
            txtConsola.Margin = new Padding(3, 4, 3, 4);
            txtConsola.Multiline = true;
            txtConsola.Name = "txtConsola";
            txtConsola.ScrollBars = ScrollBars.Vertical;
            txtConsola.Size = new Size(777, 540);
            txtConsola.TabIndex = 4;
            // 
            // btnConsola
            // 
            btnConsola.Location = new Point(7, 13);
            btnConsola.Margin = new Padding(3, 4, 3, 4);
            btnConsola.Name = "btnConsola";
            btnConsola.Size = new Size(86, 31);
            btnConsola.TabIndex = 3;
            btnConsola.Text = "Consola";
            btnConsola.UseVisualStyleBackColor = true;
            // 
            // btnMain2
            // 
            btnMain2.Location = new Point(7, 86);
            btnMain2.Name = "btnMain2";
            btnMain2.Size = new Size(86, 29);
            btnMain2.TabIndex = 6;
            btnMain2.Text = "Main 2";
            btnMain2.UseVisualStyleBackColor = true;
            btnMain2.Click += btnMain2_Click;
            // 
            // btnMain3
            // 
            btnMain3.Location = new Point(7, 121);
            btnMain3.Name = "btnMain3";
            btnMain3.Size = new Size(86, 29);
            btnMain3.TabIndex = 7;
            btnMain3.Text = "Main 3";
            btnMain3.UseVisualStyleBackColor = true;
            btnMain3.Click += btnMain3_Click_1;
            // 
            // btnBattle4
            // 
            btnBattle4.Location = new Point(7, 156);
            btnBattle4.Name = "btnBattle4";
            btnBattle4.Size = new Size(86, 29);
            btnBattle4.TabIndex = 8;
            btnBattle4.Text = "Battle P4";
            btnBattle4.UseVisualStyleBackColor = true;
            btnBattle4.Click += btnBattle4_Click_1;
            // 
            // btn
            // 
            btn.Location = new Point(7, 191);
            btn.Name = "btn";
            btn.Size = new Size(86, 29);
            btn.TabIndex = 9;
            btn.Text = "Main 4";
            btn.UseVisualStyleBackColor = true;
            btn.Click += btn4Main_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 680);
            Controls.Add(btn);
            Controls.Add(btnBattle4);
            Controls.Add(btnMain3);
            Controls.Add(btnMain2);
            Controls.Add(btnMain1);
            Controls.Add(txtConsola);
            Controls.Add(btnConsola);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMain1;
        private TextBox txtConsola;
        private Button btnConsola;
        private Button btnMain2;
        private Button btnMain3;
        private Button btnBattle4;
        private Button btn;
    }
}