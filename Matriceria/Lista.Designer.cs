namespace Matriceria
{
    partial class Lista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFiltroOT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgListaOrdenes = new System.Windows.Forms.DataGridView();
            this.btEliminarOT = new System.Windows.Forms.Button();
            this.btFiltroOT = new System.Windows.Forms.Button();
            this.btImprimirOT = new System.Windows.Forms.Button();
            this.listaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaOrdenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFiltroOT
            // 
            this.txtFiltroOT.Location = new System.Drawing.Point(79, 35);
            this.txtFiltroOT.Name = "txtFiltroOT";
            this.txtFiltroOT.Size = new System.Drawing.Size(254, 20);
            this.txtFiltroOT.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Busqueda";
            // 
            // dgListaOrdenes
            // 
            this.dgListaOrdenes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgListaOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgListaOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListaOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Prioridad,
            this.Column4,
            this.Column5,
            this.Column2,
            this.Column3});
            this.dgListaOrdenes.Location = new System.Drawing.Point(21, 113);
            this.dgListaOrdenes.Margin = new System.Windows.Forms.Padding(0);
            this.dgListaOrdenes.Name = "dgListaOrdenes";
            this.dgListaOrdenes.Size = new System.Drawing.Size(645, 137);
            this.dgListaOrdenes.TabIndex = 2;
            // 
            // btEliminarOT
            // 
            this.btEliminarOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarOT.Location = new System.Drawing.Point(453, 22);
            this.btEliminarOT.Name = "btEliminarOT";
            this.btEliminarOT.Size = new System.Drawing.Size(113, 43);
            this.btEliminarOT.TabIndex = 3;
            this.btEliminarOT.Text = "Eliminar OT";
            this.btEliminarOT.UseVisualStyleBackColor = true;
            this.btEliminarOT.Click += new System.EventHandler(this.btEliminarOT_Click);
            // 
            // btFiltroOT
            // 
            this.btFiltroOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFiltroOT.Location = new System.Drawing.Point(359, 22);
            this.btFiltroOT.Name = "btFiltroOT";
            this.btFiltroOT.Size = new System.Drawing.Size(88, 43);
            this.btFiltroOT.TabIndex = 4;
            this.btFiltroOT.Text = "Filtrar OT";
            this.btFiltroOT.UseVisualStyleBackColor = true;
            this.btFiltroOT.Click += new System.EventHandler(this.btFiltroOT_Click);
            // 
            // btImprimirOT
            // 
            this.btImprimirOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImprimirOT.Location = new System.Drawing.Point(572, 22);
            this.btImprimirOT.Name = "btImprimirOT";
            this.btImprimirOT.Size = new System.Drawing.Size(94, 58);
            this.btImprimirOT.TabIndex = 5;
            this.btImprimirOT.Text = "Imprimir OT";
            this.btImprimirOT.UseVisualStyleBackColor = true;
            this.btImprimirOT.Click += new System.EventHandler(this.btImprimirOT_Click);
            // 
            // listaBindingSource
            // 
            this.listaBindingSource.DataSource = typeof(Matriceria.Lista);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Codigo";
            this.Column1.Name = "Column1";
            // 
            // Prioridad
            // 
            this.Prioridad.HeaderText = "Prioridad";
            this.Prioridad.Name = "Prioridad";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Descripcion";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Estado";
            this.Column5.Name = "Column5";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fecha de inicio";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha de prometido";
            this.Column3.Name = "Column3";
            // 
            // Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 436);
            this.Controls.Add(this.btImprimirOT);
            this.Controls.Add(this.btFiltroOT);
            this.Controls.Add(this.btEliminarOT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiltroOT);
            this.Controls.Add(this.dgListaOrdenes);
            this.Name = "Lista";
            this.Text = "Lista";
            ((System.ComponentModel.ISupportInitialize)(this.dgListaOrdenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltroOT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btEliminarOT;
        public System.Windows.Forms.DataGridView dgListaOrdenes;
        private System.Windows.Forms.Button btFiltroOT;
        private System.Windows.Forms.Button btImprimirOT;
        private System.Windows.Forms.BindingSource listaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prioridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}