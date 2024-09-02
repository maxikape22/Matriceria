namespace Matriceria
{
    partial class RegistrarEntrega
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
            this.btRegresoInicio = new System.Windows.Forms.Button();
            this.btGuardar = new System.Windows.Forms.Button();
            this.txtEstadoEntrega = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHorarioEntrega = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMedioPago = new System.Windows.Forms.ComboBox();
            this.dateTimeFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.cmbEntregado = new System.Windows.Forms.ComboBox();
            this.btListaEntregas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btRegresoInicio
            // 
            this.btRegresoInicio.Location = new System.Drawing.Point(391, 126);
            this.btRegresoInicio.Name = "btRegresoInicio";
            this.btRegresoInicio.Size = new System.Drawing.Size(86, 62);
            this.btRegresoInicio.TabIndex = 52;
            this.btRegresoInicio.Text = "Volver a inicio";
            this.btRegresoInicio.UseVisualStyleBackColor = true;
            this.btRegresoInicio.Click += new System.EventHandler(this.btRegresoInicio_Click);
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(391, 64);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(86, 46);
            this.btGuardar.TabIndex = 51;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // txtEstadoEntrega
            // 
            this.txtEstadoEntrega.Location = new System.Drawing.Point(142, 175);
            this.txtEstadoEntrega.Name = "txtEstadoEntrega";
            this.txtEstadoEntrega.Size = new System.Drawing.Size(197, 20);
            this.txtEstadoEntrega.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Estado entrega";
            // 
            // txtHorarioEntrega
            // 
            this.txtHorarioEntrega.Location = new System.Drawing.Point(142, 137);
            this.txtHorarioEntrega.Name = "txtHorarioEntrega";
            this.txtHorarioEntrega.Size = new System.Drawing.Size(197, 20);
            this.txtHorarioEntrega.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Horario entrega";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Fecha entrega";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(142, 64);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(197, 20);
            this.txtCodigo.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Código";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Medio de pago";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Entregado";
            // 
            // cmbMedioPago
            // 
            this.cmbMedioPago.FormattingEnabled = true;
            this.cmbMedioPago.Location = new System.Drawing.Point(142, 210);
            this.cmbMedioPago.Name = "cmbMedioPago";
            this.cmbMedioPago.Size = new System.Drawing.Size(197, 21);
            this.cmbMedioPago.TabIndex = 57;
            // 
            // dateTimeFechaEntrega
            // 
            this.dateTimeFechaEntrega.Location = new System.Drawing.Point(142, 102);
            this.dateTimeFechaEntrega.Name = "dateTimeFechaEntrega";
            this.dateTimeFechaEntrega.Size = new System.Drawing.Size(197, 20);
            this.dateTimeFechaEntrega.TabIndex = 58;
            // 
            // cmbEntregado
            // 
            this.cmbEntregado.FormattingEnabled = true;
            this.cmbEntregado.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.cmbEntregado.Location = new System.Drawing.Point(142, 250);
            this.cmbEntregado.Name = "cmbEntregado";
            this.cmbEntregado.Size = new System.Drawing.Size(197, 21);
            this.cmbEntregado.TabIndex = 59;
            // 
            // btListaEntregas
            // 
            this.btListaEntregas.Location = new System.Drawing.Point(391, 209);
            this.btListaEntregas.Name = "btListaEntregas";
            this.btListaEntregas.Size = new System.Drawing.Size(86, 62);
            this.btListaEntregas.TabIndex = 60;
            this.btListaEntregas.Text = "Lista de entregas";
            this.btListaEntregas.UseVisualStyleBackColor = true;
            this.btListaEntregas.Click += new System.EventHandler(this.btListaEntregas_Click);
            // 
            // RegistrarEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 309);
            this.Controls.Add(this.btListaEntregas);
            this.Controls.Add(this.cmbEntregado);
            this.Controls.Add(this.dateTimeFechaEntrega);
            this.Controls.Add(this.cmbMedioPago);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btRegresoInicio);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.txtEstadoEntrega);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHorarioEntrega);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Name = "RegistrarEntrega";
            this.Text = "RegistrarEntrega";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRegresoInicio;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.TextBox txtEstadoEntrega;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHorarioEntrega;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMedioPago;
        private System.Windows.Forms.DateTimePicker dateTimeFechaEntrega;
        private System.Windows.Forms.ComboBox cmbEntregado;
        private System.Windows.Forms.Button btListaEntregas;
    }
}