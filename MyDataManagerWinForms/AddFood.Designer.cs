namespace MyDataManagerWinForms
{
    partial class AddFood
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
            this.btnSaveFood = new System.Windows.Forms.Button();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.txtAddFood = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Food:";
            // 
            // btnSaveFood
            // 
            this.btnSaveFood.Location = new System.Drawing.Point(106, 93);
            this.btnSaveFood.Name = "btnSaveFood";
            this.btnSaveFood.Size = new System.Drawing.Size(94, 29);
            this.btnSaveFood.TabIndex = 2;
            this.btnSaveFood.Text = "Save";
            this.btnSaveFood.UseVisualStyleBackColor = true;
            this.btnSaveFood.Click += new System.EventHandler(this.btnSaveFood_Click);
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.Location = new System.Drawing.Point(106, 128);
            this.btnCancelAdd.Name = "btnCancelAdd";
            this.btnCancelAdd.Size = new System.Drawing.Size(94, 29);
            this.btnCancelAdd.TabIndex = 3;
            this.btnCancelAdd.Text = "Cancel";
            this.btnCancelAdd.UseVisualStyleBackColor = true;
            // 
            // txtAddFood
            // 
            this.txtAddFood.Location = new System.Drawing.Point(96, 60);
            this.txtAddFood.Name = "txtAddFood";
            this.txtAddFood.Size = new System.Drawing.Size(125, 27);
            this.txtAddFood.TabIndex = 7;
            this.txtAddFood.TextChanged += new System.EventHandler(this.txtAddFood_TextChanged);
            // 
            // AddFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 255);
            this.Controls.Add(this.txtAddFood);
            this.Controls.Add(this.btnCancelAdd);
            this.Controls.Add(this.btnSaveFood);
            this.Controls.Add(this.label1);
            this.Name = "AddFood";
            this.Text = "AddFood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Button btnSaveFood;
        private Button btnCancelAdd;
        private TextBox txtAddFood;
    }
}