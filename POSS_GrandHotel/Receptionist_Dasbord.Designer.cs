namespace POSS_GrandHotel
{
    partial class Receptionist_Dasbord
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.flp_kamar = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "register tamu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flp_kamar
            // 
            this.flp_kamar.Location = new System.Drawing.Point(182, 12);
            this.flp_kamar.Name = "flp_kamar";
            this.flp_kamar.Size = new System.Drawing.Size(597, 438);
            this.flp_kamar.TabIndex = 1;
            this.flp_kamar.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 65);
            this.button2.TabIndex = 2;
            this.button2.Text = "reservasi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 247);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 72);
            this.button3.TabIndex = 3;
            this.button3.Text = "check in and out";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(28, 352);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 72);
            this.button4.TabIndex = 4;
            this.button4.Text = "extraservice";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Receptionist_Dasbord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flp_kamar);
            this.Name = "Receptionist_Dasbord";
            this.Text = "Receptionist_Dasbord";
            this.Load += new System.EventHandler(this.Receptionist_Dasbord_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flp_kamar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
    }
}