namespace ConsoleDrawer.View
{
    partial class FormAddCircuit
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
            this.comboBoxCircuit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddElement = new System.Windows.Forms.Button();
            this.buttonCreateSubcircuit = new System.Windows.Forms.Button();
            this.treeViewSubcircuit = new System.Windows.Forms.TreeView();
            this.textBoxImpedance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFrequency = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCalculateZ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxCircuit
            // 
            this.comboBoxCircuit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCircuit.FormattingEnabled = true;
            this.comboBoxCircuit.Items.AddRange(new object[] {
            "Serial circuit",
            "Parallel circuit"});
            this.comboBoxCircuit.Location = new System.Drawing.Point(12, 29);
            this.comboBoxCircuit.Name = "comboBoxCircuit";
            this.comboBoxCircuit.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCircuit.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connection Type";
            // 
            // buttonAddElement
            // 
            this.buttonAddElement.Location = new System.Drawing.Point(270, 29);
            this.buttonAddElement.Name = "buttonAddElement";
            this.buttonAddElement.Size = new System.Drawing.Size(125, 23);
            this.buttonAddElement.TabIndex = 4;
            this.buttonAddElement.Text = "Element Add";
            this.buttonAddElement.UseVisualStyleBackColor = true;
            this.buttonAddElement.Click += new System.EventHandler(this.buttonAddElement_Click);
            // 
            // buttonCreateSubcircuit
            // 
            this.buttonCreateSubcircuit.Location = new System.Drawing.Point(139, 29);
            this.buttonCreateSubcircuit.Name = "buttonCreateSubcircuit";
            this.buttonCreateSubcircuit.Size = new System.Drawing.Size(125, 23);
            this.buttonCreateSubcircuit.TabIndex = 5;
            this.buttonCreateSubcircuit.Text = "Create Circuit";
            this.buttonCreateSubcircuit.UseVisualStyleBackColor = true;
            this.buttonCreateSubcircuit.Click += new System.EventHandler(this.buttonCreateSubcircuit_Click);
            // 
            // treeViewSubcircuit
            // 
            this.treeViewSubcircuit.Location = new System.Drawing.Point(12, 59);
            this.treeViewSubcircuit.Name = "treeViewSubcircuit";
            this.treeViewSubcircuit.Size = new System.Drawing.Size(383, 316);
            this.treeViewSubcircuit.TabIndex = 6;
            // 
            // textBoxImpedance
            // 
            this.textBoxImpedance.Location = new System.Drawing.Point(401, 322);
            this.textBoxImpedance.Name = "textBoxImpedance";
            this.textBoxImpedance.ReadOnly = true;
            this.textBoxImpedance.Size = new System.Drawing.Size(100, 22);
            this.textBoxImpedance.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Частота сигнала";
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.Location = new System.Drawing.Point(401, 79);
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.Size = new System.Drawing.Size(34, 22);
            this.textBoxFrequency.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Impedance";
            // 
            // buttonCalculateZ
            // 
            this.buttonCalculateZ.Location = new System.Drawing.Point(401, 350);
            this.buttonCalculateZ.Name = "buttonCalculateZ";
            this.buttonCalculateZ.Size = new System.Drawing.Size(100, 23);
            this.buttonCalculateZ.TabIndex = 12;
            this.buttonCalculateZ.Text = "Calculate";
            this.buttonCalculateZ.UseVisualStyleBackColor = true;
            this.buttonCalculateZ.Click += new System.EventHandler(this.buttonCalculateZ_Click);
            // 
            // FormAddCircuit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 385);
            this.Controls.Add(this.buttonCalculateZ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFrequency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxImpedance);
            this.Controls.Add(this.treeViewSubcircuit);
            this.Controls.Add(this.buttonCreateSubcircuit);
            this.Controls.Add(this.buttonAddElement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCircuit);
            this.Name = "FormAddCircuit";
            this.Text = "FormAddCircuit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCircuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddElement;
        private System.Windows.Forms.Button buttonCreateSubcircuit;
        private System.Windows.Forms.TreeView treeViewSubcircuit;
        private System.Windows.Forms.TextBox textBoxImpedance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFrequency;
        private System.Windows.Forms.Button buttonCalculateZ;
        private System.Windows.Forms.Label label3;
    }
}