namespace Sudoku
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
            this.vyresit = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // vyresit
            // 
            this.vyresit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vyresit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.vyresit.Location = new System.Drawing.Point(621, 86);
            this.vyresit.Name = "vyresit";
            this.vyresit.Size = new System.Drawing.Size(99, 36);
            this.vyresit.TabIndex = 0;
            this.vyresit.Text = "Vyřešit";
            this.vyresit.UseVisualStyleBackColor = true;
            this.vyresit.Click += new System.EventHandler(this.vyresit_Click);
            // 
            // reset
            // 
            this.reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reset.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reset.Location = new System.Drawing.Point(621, 128);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(99, 37);
            this.reset.TabIndex = 0;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(318, -9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sudoku";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(515, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Do tabulky zadej čísla, pro která chceš najít řešení. Stisknutím vyřešit dostaneš" +
    " se objeví výsledek.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.vyresit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button vyresit;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

