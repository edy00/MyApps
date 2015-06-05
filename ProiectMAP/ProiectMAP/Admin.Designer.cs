namespace ProiectMAP
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.txtProd = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.lstEf = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrel
            // 
            this.btnPrel.Location = new System.Drawing.Point(12, 152);
            this.btnPrel.Name = "btnPrel";
            this.btnPrel.Size = new System.Drawing.Size(223, 31);
            this.btnPrel.TabIndex = 0;
            this.btnPrel.Text = "Preluare comanda";
            this.btnPrel.UseVisualStyleBackColor = true;
            this.btnPrel.Click += new System.EventHandler(this.btnPrel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(286, 300);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(191, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Adaugare produs";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(223, 121);
            this.listBox1.TabIndex = 2;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(286, 38);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(191, 251);
            this.listBox2.TabIndex = 3;
            // 
            // txtProd
            // 
            this.txtProd.Location = new System.Drawing.Point(286, 329);
            this.txtProd.Name = "txtProd";
            this.txtProd.Size = new System.Drawing.Size(191, 20);
            this.txtProd.TabIndex = 4;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(376, 8);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(101, 24);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "Stergere produs";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lstEf
            // 
            this.lstEf.FormattingEnabled = true;
            this.lstEf.Location = new System.Drawing.Point(12, 202);
            this.lstEf.Name = "lstEf";
            this.lstEf.Size = new System.Drawing.Size(223, 95);
            this.lstEf.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Produse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Comenzi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Comenzi efectuate";
            // 
            // btnGol
            // 
            this.btnGol.Location = new System.Drawing.Point(12, 303);
            this.btnGol.Name = "btnGol";
            this.btnGol.Size = new System.Drawing.Size(223, 23);
            this.btnGol.TabIndex = 10;
            this.btnGol.Text = "Golire lista";
            this.btnGol.UseVisualStyleBackColor = true;
            this.btnGol.Click += new System.EventHandler(this.btnGol_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 361);
            this.Controls.Add(this.btnGol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstEf);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.txtProd);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPrel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox txtProd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ListBox lstEf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGol;
    }
}