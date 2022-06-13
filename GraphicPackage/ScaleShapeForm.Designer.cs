
namespace GraphicPackage
{
    partial class ScaleShapeForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.xBox = new System.Windows.Forms.CheckBox();
            this.yBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.scalarTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scaler:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(96, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "x:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(166, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "y:";
            // 
            // xBox
            // 
            this.xBox.AutoSize = true;
            this.xBox.Location = new System.Drawing.Point(125, 87);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(18, 17);
            this.xBox.TabIndex = 5;
            this.xBox.UseVisualStyleBackColor = true;
            // 
            // yBox
            // 
            this.yBox.AutoSize = true;
            this.yBox.Location = new System.Drawing.Point(195, 87);
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(18, 17);
            this.yBox.TabIndex = 6;
            this.yBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // scalarTextBox
            // 
            this.scalarTextBox.Location = new System.Drawing.Point(96, 34);
            this.scalarTextBox.Name = "scalarTextBox";
            this.scalarTextBox.Size = new System.Drawing.Size(170, 22);
            this.scalarTextBox.TabIndex = 8;
            // 
            // ScaleShapeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 180);
            this.Controls.Add(this.scalarTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.yBox);
            this.Controls.Add(this.xBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ScaleShapeForm";
            this.Text = "Scale";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox xBox;
        private System.Windows.Forms.CheckBox yBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox scalarTextBox;
    }
}