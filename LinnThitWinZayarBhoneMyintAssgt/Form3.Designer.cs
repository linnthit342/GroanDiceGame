﻿
namespace LinnThitWinZayarBhoneMyintAssgt
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.back_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Aqua;
            this.richTextBox1.Location = new System.Drawing.Point(-1, -3);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1504, 914);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // back_btn
            // 
            this.back_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.ForeColor = System.Drawing.Color.Red;
            this.back_btn.Location = new System.Drawing.Point(1222, 804);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(119, 64);
            this.back_btn.TabIndex = 3;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1467, 903);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Rules";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button back_btn;
    }
}