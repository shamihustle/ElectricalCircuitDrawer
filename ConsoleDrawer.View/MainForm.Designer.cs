namespace ConsoleDrawer.View
{
    partial class MainForm
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
            this.comboBoxCircuit = new System.Windows.Forms.ComboBox();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.textBoxReal = new System.Windows.Forms.TextBox();
            this.textBoxIm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFrequency = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.dataGridViewCircuit = new System.Windows.Forms.DataGridView();
            this.buttonModify = new System.Windows.Forms.Button();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialCircuitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resistorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCircuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serialCircuitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resistorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCircuit
            // 
            this.comboBoxCircuit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCircuit.FormattingEnabled = true;
            this.comboBoxCircuit.Items.AddRange(new object[] {
            "1 circuit",
            "2 circuit",
            "3 circuit",
            "4 circuit",
            "5 circuit"});
            this.comboBoxCircuit.Location = new System.Drawing.Point(4, 310);
            this.comboBoxCircuit.Name = "comboBoxCircuit";
            this.comboBoxCircuit.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCircuit.TabIndex = 2;
            this.comboBoxCircuit.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(4, 281);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(75, 23);
            this.buttonDraw.TabIndex = 3;
            this.buttonDraw.Text = "Draw";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(431, 281);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 4;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // textBoxReal
            // 
            this.textBoxReal.Location = new System.Drawing.Point(431, 327);
            this.textBoxReal.Name = "textBoxReal";
            this.textBoxReal.Size = new System.Drawing.Size(75, 22);
            this.textBoxReal.TabIndex = 5;
            // 
            // textBoxIm
            // 
            this.textBoxIm.Location = new System.Drawing.Point(431, 372);
            this.textBoxIm.Name = "textBoxIm";
            this.textBoxIm.Size = new System.Drawing.Size(75, 22);
            this.textBoxIm.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Re:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Im:";
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.Location = new System.Drawing.Point(386, 282);
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.Size = new System.Drawing.Size(39, 22);
            this.textBoxFrequency.TabIndex = 9;
            this.textBoxFrequency.Text = "1";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(4, 340);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 11;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // dataGridViewCircuit
            // 
            this.dataGridViewCircuit.AllowUserToAddRows = false;
            this.dataGridViewCircuit.AutoGenerateColumns = false;
            this.dataGridViewCircuit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCircuit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCircuit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.dataGridViewCircuit.DataSource = this.serialCircuitBindingSource;
            this.dataGridViewCircuit.Location = new System.Drawing.Point(4, 12);
            this.dataGridViewCircuit.Name = "dataGridViewCircuit";
            this.dataGridViewCircuit.RowTemplate.Height = 24;
            this.dataGridViewCircuit.Size = new System.Drawing.Size(502, 235);
            this.dataGridViewCircuit.TabIndex = 12;
            this.dataGridViewCircuit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCircuit_CellDoubleClick);
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(4, 369);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(75, 23);
            this.buttonModify.TabIndex = 13;
            this.buttonModify.Text = "Modify";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serialCircuitBindingSource
            // 
            this.serialCircuitBindingSource.DataSource = typeof(Elemnts.Curcuit.SerialCircuit);
            // 
            // resistorBindingSource
            // 
            this.resistorBindingSource.DataSource = typeof(Elemnts.Elements.Resistor);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 408);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.dataGridViewCircuit);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.textBoxFrequency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIm);
            this.Controls.Add(this.textBoxReal);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.comboBoxCircuit);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCircuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serialCircuitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resistorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxCircuit;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.TextBox textBoxReal;
        private System.Windows.Forms.TextBox textBoxIm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFrequency;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.BindingSource serialCircuitBindingSource;
        private System.Windows.Forms.BindingSource resistorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridViewCircuit;
        private System.Windows.Forms.Button buttonModify;
    }
}