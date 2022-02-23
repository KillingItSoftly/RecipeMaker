namespace MyDataManagerWinForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cboCategories = new System.Windows.Forms.ComboBox();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCategories
            // 
            this.cboCategories.BackColor = System.Drawing.Color.White;
            this.cboCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategories.FormattingEnabled = true;
            this.cboCategories.Location = new System.Drawing.Point(81, 39);
            this.cboCategories.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCategories.Name = "cboCategories";
            this.cboCategories.Size = new System.Drawing.Size(657, 28);
            this.cboCategories.TabIndex = 0;
            this.cboCategories.SelectedIndexChanged += new System.EventHandler(this.cboCategories_SelectedIndexChanged);
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToResizeColumns = false;
            this.dgItems.AllowUserToResizeRows = false;
            this.dgItems.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgItems.Location = new System.Drawing.Point(81, 111);
            this.dgItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgItems.Name = "dgItems";
            this.dgItems.RowHeadersWidth = 51;
            this.dgItems.RowTemplate.Height = 25;
            this.dgItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgItems.Size = new System.Drawing.Size(657, 365);
            this.dgItems.TabIndex = 1;
            this.dgItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellContentClick);
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAddFood.Location = new System.Drawing.Point(451, 477);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(142, 71);
            this.btnAddFood.TabIndex = 3;
            this.btnAddFood.Text = "Add Item";
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Location = new System.Drawing.Point(599, 477);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(139, 69);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Row";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(308, 478);
            this.btnLoadData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(142, 71);
            this.btnLoadData.TabIndex = 5;
            this.btnLoadData.Text = "LoadData";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(802, 560);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.cboCategories);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cboCategories;
        private DataGridView dgItems;
        private Button btnAddFood;
        private Button btnDelete;
        private Button btnLoadData;
    }
}