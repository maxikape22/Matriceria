namespace Matriceria
{
    partial class Entregas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvEntrega = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btFiltroEntrega = new System.Windows.Forms.Button();
            this.btEliminarEntrega = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntrega = new System.Windows.Forms.TextBox();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrega)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEntrega
            // 
            this.dgvEntrega.AllowUserToOrderColumns = true;
            this.dgvEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntrega.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEntrega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntrega.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column3,
            this.Column2});
            this.dgvEntrega.Location = new System.Drawing.Point(51, 197);
            this.dgvEntrega.Name = "dgvEntrega";
            this.dgvEntrega.Size = new System.Drawing.Size(846, 141);
            this.dgvEntrega.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(244, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Listado de entregas";
            // 
            // btFiltroEntrega
            // 
            this.btFiltroEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFiltroEntrega.Location = new System.Drawing.Point(529, 104);
            this.btFiltroEntrega.Name = "btFiltroEntrega";
            this.btFiltroEntrega.Size = new System.Drawing.Size(123, 43);
            this.btFiltroEntrega.TabIndex = 6;
            this.btFiltroEntrega.Text = "Filtrar entrega";
            this.btFiltroEntrega.UseVisualStyleBackColor = true;
            this.btFiltroEntrega.Click += new System.EventHandler(this.button2_Click);
            // 
            // btEliminarEntrega
            // 
            this.btEliminarEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarEntrega.Location = new System.Drawing.Point(749, 104);
            this.btEliminarEntrega.Name = "btEliminarEntrega";
            this.btEliminarEntrega.Size = new System.Drawing.Size(148, 43);
            this.btEliminarEntrega.TabIndex = 5;
            this.btEliminarEntrega.Text = "Eliminar entrega";
            this.btEliminarEntrega.UseVisualStyleBackColor = true;
            this.btEliminarEntrega.Click += new System.EventHandler(this.btEliminarEntrega_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Busqueda";
            // 
            // txtEntrega
            // 
            this.txtEntrega.Location = new System.Drawing.Point(121, 117);
            this.txtEntrega.Name = "txtEntrega";
            this.txtEntrega.Size = new System.Drawing.Size(254, 20);
            this.txtEntrega.TabIndex = 7;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Código de entrega";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Código de orden";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Razon social cliente";
            this.Column8.Name = "Column8";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Fecha de entrega";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Hora de entrega";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Estado de la entrega";
            this.Column5.Name = "Column5";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Medio de pago elegido";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Entregado";
            this.Column2.Name = "Column2";
            // 
            // Entregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEntrega);
            this.Controls.Add(this.btFiltroEntrega);
            this.Controls.Add(this.btEliminarEntrega);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEntrega);
            this.Name = "Entregas";
            this.Text = "Entregas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrega)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvEntrega;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFiltroEntrega;
        private System.Windows.Forms.Button btEliminarEntrega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}