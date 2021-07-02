namespace Presentacion
{
    partial class FrmPrestamos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFechaPrimeraCuota = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.spiMonto = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.spiInteres = new System.Windows.Forms.NumericUpDown();
            this.spiCuotas = new System.Windows.Forms.NumericUpDown();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtPersona = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvListaHoras = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spiMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiInteres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiCuotas)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaHoras)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFechaPrimeraCuota);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.spiMonto);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.spiInteres);
            this.groupBox1.Controls.Add(this.spiCuotas);
            this.groupBox1.Controls.Add(this.txtMontoTotal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtPersona);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de préstamo";
            // 
            // dtpFechaPrimeraCuota
            // 
            this.dtpFechaPrimeraCuota.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaPrimeraCuota.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaPrimeraCuota.Location = new System.Drawing.Point(346, 45);
            this.dtpFechaPrimeraCuota.Name = "dtpFechaPrimeraCuota";
            this.dtpFechaPrimeraCuota.Size = new System.Drawing.Size(116, 20);
            this.dtpFechaPrimeraCuota.TabIndex = 47;
            this.dtpFechaPrimeraCuota.Value = new System.DateTime(2021, 4, 20, 0, 0, 0, 0);
            this.dtpFechaPrimeraCuota.ValueChanged += new System.EventHandler(this.stpFechaPrimeraCuota_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(233, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Fecha primera cuota:";
            // 
            // spiMonto
            // 
            this.spiMonto.DecimalPlaces = 2;
            this.spiMonto.Location = new System.Drawing.Point(91, 72);
            this.spiMonto.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.spiMonto.Name = "spiMonto";
            this.spiMonto.Size = new System.Drawing.Size(126, 20);
            this.spiMonto.TabIndex = 45;
            this.spiMonto.ValueChanged += new System.EventHandler(this.spiMonto_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(346, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "%";
            // 
            // spiInteres
            // 
            this.spiInteres.DecimalPlaces = 2;
            this.spiInteres.Location = new System.Drawing.Point(281, 72);
            this.spiInteres.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spiInteres.Name = "spiInteres";
            this.spiInteres.Size = new System.Drawing.Size(59, 20);
            this.spiInteres.TabIndex = 43;
            this.spiInteres.ValueChanged += new System.EventHandler(this.spiInteres_ValueChanged);
            // 
            // spiCuotas
            // 
            this.spiCuotas.Location = new System.Drawing.Point(91, 97);
            this.spiCuotas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spiCuotas.Name = "spiCuotas";
            this.spiCuotas.Size = new System.Drawing.Size(126, 20);
            this.spiCuotas.TabIndex = 42;
            this.spiCuotas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spiCuotas.ValueChanged += new System.EventHandler(this.spiCuotas_ValueChanged);
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Location = new System.Drawing.Point(91, 123);
            this.txtMontoTotal.MaxLength = 10;
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(126, 20);
            this.txtMontoTotal.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Monto total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Cuotas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Interés:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Monto:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(91, 45);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(126, 20);
            this.dtpFecha.TabIndex = 33;
            this.dtpFecha.Value = new System.DateTime(2021, 4, 20, 0, 0, 0, 0);
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(477, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(71, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtPersona
            // 
            this.txtPersona.Enabled = false;
            this.txtPersona.Location = new System.Drawing.Point(91, 19);
            this.txtPersona.MaxLength = 10;
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.ReadOnly = true;
            this.txtPersona.Size = new System.Drawing.Size(371, 20);
            this.txtPersona.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cliente:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLimpiar);
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Location = new System.Drawing.Point(932, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 157);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiar.Location = new System.Drawing.Point(20, 74);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(102, 39);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.Location = new System.Drawing.Point(20, 22);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 39);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(6, 19);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(1048, 349);
            this.dgvLista.TabIndex = 52;
            this.dgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvListaHoras);
            this.groupBox2.Location = new System.Drawing.Point(580, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 157);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fechas de pago";
            // 
            // dgvListaHoras
            // 
            this.dgvListaHoras.AllowUserToAddRows = false;
            this.dgvListaHoras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaHoras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaHoras.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvListaHoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaHoras.Location = new System.Drawing.Point(6, 17);
            this.dgvListaHoras.MultiSelect = false;
            this.dgvListaHoras.Name = "dgvListaHoras";
            this.dgvListaHoras.Size = new System.Drawing.Size(334, 134);
            this.dgvListaHoras.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgvLista);
            this.groupBox4.Location = new System.Drawing.Point(12, 175);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1060, 374);
            this.groupBox4.TabIndex = 54;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista de préstamos";
            // 
            // FrmPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPrestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Préstamos";
            this.Load += new System.EventHandler(this.FrmPrestamos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spiMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiInteres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiCuotas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaHoras)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtPersona;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.NumericUpDown spiCuotas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvListaHoras;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown spiInteres;
        private System.Windows.Forms.NumericUpDown spiMonto;
        private System.Windows.Forms.DateTimePicker dtpFechaPrimeraCuota;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}