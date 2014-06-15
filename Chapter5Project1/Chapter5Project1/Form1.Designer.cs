namespace Chapter5Project1
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.fancyDecorations = new System.Windows.Forms.CheckBox();
            this.healthyOption = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of people:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(16, 29);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // fancyDecorations
            // 
            this.fancyDecorations.AutoSize = true;
            this.fancyDecorations.Location = new System.Drawing.Point(16, 55);
            this.fancyDecorations.Name = "fancyDecorations";
            this.fancyDecorations.Size = new System.Drawing.Size(113, 17);
            this.fancyDecorations.TabIndex = 2;
            this.fancyDecorations.Text = "Fancy decorations";
            this.fancyDecorations.UseVisualStyleBackColor = true;
            this.fancyDecorations.CheckedChanged += new System.EventHandler(this.fancyDecorations_CheckedChanged);
            // 
            // healthyOption
            // 
            this.healthyOption.AutoSize = true;
            this.healthyOption.Location = new System.Drawing.Point(16, 80);
            this.healthyOption.Name = "healthyOption";
            this.healthyOption.Size = new System.Drawing.Size(94, 17);
            this.healthyOption.TabIndex = 3;
            this.healthyOption.Text = "Healthy option";
            this.healthyOption.UseVisualStyleBackColor = true;
            this.healthyOption.CheckedChanged += new System.EventHandler(this.healthyOption_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cost:";
            // 
            // costLabel
            // 
            this.costLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.costLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costLabel.Location = new System.Drawing.Point(54, 104);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(100, 14);
            this.costLabel.TabIndex = 5;
            this.costLabel.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 145);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.healthyOption);
            this.Controls.Add(this.fancyDecorations);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Party Planner";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox fancyDecorations;
        private System.Windows.Forms.CheckBox healthyOption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label costLabel;
    }
}

