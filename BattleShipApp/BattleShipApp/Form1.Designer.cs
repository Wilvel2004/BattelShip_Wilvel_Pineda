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
            btnMain1.Click += btnMain1_Click;
            // 
            // txtConsola
            // 
            txtConsola.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtConsola.Location = new Point(118, 13);
            txtConsola.Margin = new Padding(3, 4, 3, 4);
            txtConsola.Multiline = true;
            txtConsola.Name = "txtConsola";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 680);
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
    }
}