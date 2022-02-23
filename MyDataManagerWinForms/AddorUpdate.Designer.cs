namespace MyDataManagerWinForms
{
    partial class AddorUpdate
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
            this.txtfoodName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtfoodName
            // 
            this.txtfoodName.Location = new System.Drawing.Point(192, 199);
            this.txtfoodName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfoodName.Name = "txtfoodName";
            this.txtfoodName.Size = new System.Drawing.Size(250, 23);
            this.txtfoodName.TabIndex = 0;
            this.txtfoodName.TextChanged += new System.EventHandler(this.txtfoodName_TextChanged);
            this.txtfoodName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfoodName_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnSave.Location = new System.Drawing.Point(46, 287);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 37);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancel.Location = new System.Drawing.Point(437, 284);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Food Name";
            //this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // addComboBox
            // 
            this.addComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addComboBox.FormattingEnabled = true;
            this.addComboBox.Location = new System.Drawing.Point(192, 105);
            this.addComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addComboBox.Name = "addComboBox";
            this.addComboBox.Size = new System.Drawing.Size(250, 23);
            this.addComboBox.TabIndex = 4;
            this.addComboBox.SelectedIndexChanged += new System.EventHandler(this.addComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Food Group";
            //this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // AddorUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtfoodName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddorUpdate";
            this.Text = "AddorUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtfoodName;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private ComboBox addComboBox;
        private Label label2;
    }
}