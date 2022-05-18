namespace PosOnLine.Src.AdministradorDoc.Principal
{
    partial class AdmDocFrm
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BT_ANULAR = new System.Windows.Forms.Button();
            this.BT_NOTA_CREDITO = new System.Windows.Forms.Button();
            this.BT_IMPRIMIR = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.BT_BAJAR = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.BT_SUBIR = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BT_SALIDA = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.L_ITEMS = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_ANULAR
            // 
            this.BT_ANULAR.BackgroundImage = global::PosOnLine.Properties.Resources.bt_eliminar;
            this.BT_ANULAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_ANULAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_ANULAR.Location = new System.Drawing.Point(2, 2);
            this.BT_ANULAR.Name = "BT_ANULAR";
            this.BT_ANULAR.Size = new System.Drawing.Size(96, 94);
            this.BT_ANULAR.TabIndex = 2;
            this.toolTip1.SetToolTip(this.BT_ANULAR, "Anular Documento");
            this.BT_ANULAR.UseVisualStyleBackColor = true;
            this.BT_ANULAR.Click += new System.EventHandler(this.BT_ANULAR_Click);
            // 
            // BT_NOTA_CREDITO
            // 
            this.BT_NOTA_CREDITO.BackgroundImage = global::PosOnLine.Properties.Resources.bt_undo;
            this.BT_NOTA_CREDITO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_NOTA_CREDITO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_NOTA_CREDITO.Location = new System.Drawing.Point(2, 2);
            this.BT_NOTA_CREDITO.Name = "BT_NOTA_CREDITO";
            this.BT_NOTA_CREDITO.Size = new System.Drawing.Size(96, 94);
            this.BT_NOTA_CREDITO.TabIndex = 2;
            this.toolTip1.SetToolTip(this.BT_NOTA_CREDITO, "Aplicar Nota Crédito ");
            this.BT_NOTA_CREDITO.UseVisualStyleBackColor = true;
            this.BT_NOTA_CREDITO.Click += new System.EventHandler(this.BT_NOTA_CREDITO_Click);
            // 
            // BT_IMPRIMIR
            // 
            this.BT_IMPRIMIR.BackgroundImage = global::PosOnLine.Properties.Resources.bt_print_document;
            this.BT_IMPRIMIR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_IMPRIMIR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_IMPRIMIR.Location = new System.Drawing.Point(2, 2);
            this.BT_IMPRIMIR.Name = "BT_IMPRIMIR";
            this.BT_IMPRIMIR.Size = new System.Drawing.Size(96, 94);
            this.BT_IMPRIMIR.TabIndex = 2;
            this.toolTip1.SetToolTip(this.BT_IMPRIMIR, "ReImprimir  Documento");
            this.BT_IMPRIMIR.UseVisualStyleBackColor = true;
            this.BT_IMPRIMIR.Click += new System.EventHandler(this.BT_IMPRIMIR_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel14, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1084, 541);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 63);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1082, 425);
            this.panel5.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.22646F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.77354F));
            this.tableLayoutPanel3.Controls.Add(this.panel7, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel13, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1082, 425);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tableLayoutPanel4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(977, 1);
            this.panel7.Margin = new System.Windows.Forms.Padding(1);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(1);
            this.panel7.Size = new System.Drawing.Size(104, 423);
            this.panel7.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel12, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.panel11, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.panel10, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.panel9, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel8, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(102, 421);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.BT_BAJAR);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(1, 361);
            this.panel12.Margin = new System.Windows.Forms.Padding(1);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(2);
            this.panel12.Size = new System.Drawing.Size(100, 59);
            this.panel12.TabIndex = 4;
            // 
            // BT_BAJAR
            // 
            this.BT_BAJAR.BackgroundImage = global::PosOnLine.Properties.Resources.bt_subir;
            this.BT_BAJAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_BAJAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_BAJAR.FlatAppearance.BorderSize = 0;
            this.BT_BAJAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_BAJAR.Location = new System.Drawing.Point(2, 2);
            this.BT_BAJAR.Name = "BT_BAJAR";
            this.BT_BAJAR.Size = new System.Drawing.Size(96, 55);
            this.BT_BAJAR.TabIndex = 2;
            this.BT_BAJAR.UseVisualStyleBackColor = true;
            this.BT_BAJAR.Click += new System.EventHandler(this.BT_BAJAR_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.BT_ANULAR);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(1, 261);
            this.panel11.Margin = new System.Windows.Forms.Padding(1);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(2);
            this.panel11.Size = new System.Drawing.Size(100, 98);
            this.panel11.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.BT_NOTA_CREDITO);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(1, 161);
            this.panel10.Margin = new System.Windows.Forms.Padding(1);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(2);
            this.panel10.Size = new System.Drawing.Size(100, 98);
            this.panel10.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.BT_IMPRIMIR);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(1, 61);
            this.panel9.Margin = new System.Windows.Forms.Padding(1);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2);
            this.panel9.Size = new System.Drawing.Size(100, 98);
            this.panel9.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.BT_SUBIR);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(1, 1);
            this.panel8.Margin = new System.Windows.Forms.Padding(1);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(2);
            this.panel8.Size = new System.Drawing.Size(100, 58);
            this.panel8.TabIndex = 0;
            // 
            // BT_SUBIR
            // 
            this.BT_SUBIR.BackgroundImage = global::PosOnLine.Properties.Resources.bt_bajar;
            this.BT_SUBIR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_SUBIR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_SUBIR.FlatAppearance.BorderSize = 0;
            this.BT_SUBIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_SUBIR.Location = new System.Drawing.Point(2, 2);
            this.BT_SUBIR.Name = "BT_SUBIR";
            this.BT_SUBIR.Size = new System.Drawing.Size(96, 54);
            this.BT_SUBIR.TabIndex = 1;
            this.BT_SUBIR.UseVisualStyleBackColor = true;
            this.BT_SUBIR.Click += new System.EventHandler(this.BT_SUBIR_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.DGV);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(1, 1);
            this.panel13.Margin = new System.Windows.Forms.Padding(1);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(6);
            this.panel13.Size = new System.Drawing.Size(974, 423);
            this.panel13.TabIndex = 0;
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(6, 6);
            this.DGV.Margin = new System.Windows.Forms.Padding(1);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(962, 411);
            this.DGV.TabIndex = 0;
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            this.DGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGV_DataBindingComplete);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.tableLayoutPanel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 490);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1082, 50);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Controls.Add(this.panel6, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1082, 50);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BT_SALIDA);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(811, 1);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2);
            this.panel6.Size = new System.Drawing.Size(270, 48);
            this.panel6.TabIndex = 0;
            // 
            // BT_SALIDA
            // 
            this.BT_SALIDA.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_SALIDA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_SALIDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIDA.Image = global::PosOnLine.Properties.Resources.bt_salida_2;
            this.BT_SALIDA.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BT_SALIDA.Location = new System.Drawing.Point(2, 2);
            this.BT_SALIDA.Name = "BT_SALIDA";
            this.BT_SALIDA.Size = new System.Drawing.Size(266, 44);
            this.BT_SALIDA.TabIndex = 2;
            this.BT_SALIDA.Text = "Salir";
            this.BT_SALIDA.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BT_SALIDA.UseVisualStyleBackColor = true;
            this.BT_SALIDA.Click += new System.EventHandler(this.BT_SALIDA_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 48);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.panel16, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.panel15, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(268, 48);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.L_ITEMS);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(135, 1);
            this.panel16.Margin = new System.Windows.Forms.Padding(1);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(2);
            this.panel16.Size = new System.Drawing.Size(132, 46);
            this.panel16.TabIndex = 1;
            // 
            // L_ITEMS
            // 
            this.L_ITEMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_ITEMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ITEMS.ForeColor = System.Drawing.Color.Yellow;
            this.L_ITEMS.Location = new System.Drawing.Point(2, 2);
            this.L_ITEMS.Name = "L_ITEMS";
            this.L_ITEMS.Size = new System.Drawing.Size(128, 42);
            this.L_ITEMS.TabIndex = 0;
            this.L_ITEMS.Text = "label3";
            this.L_ITEMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label2);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(1, 1);
            this.panel15.Margin = new System.Windows.Forms.Padding(1);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(2);
            this.panel15.Size = new System.Drawing.Size(132, 46);
            this.panel15.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Items Encontrados";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.OliveDrab;
            this.panel14.Controls.Add(this.tableLayoutPanel1);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(1, 1);
            this.panel14.Margin = new System.Windows.Forms.Padding(1);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1082, 60);
            this.panel14.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1082, 60);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(62, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(1019, 58);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1015, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administrador Documentos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(59, 58);
            this.panel4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PosOnLine.Properties.Resources.bt_documentos;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 54);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AdmDocFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_SALIDA;
            this.ClientSize = new System.Drawing.Size(1084, 541);
            this.Controls.Add(this.tableLayoutPanel2);
            this.KeyPreview = true;
            this.Name = "AdmDocFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ListartFrm_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button BT_BAJAR;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button BT_ANULAR;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button BT_NOTA_CREDITO;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button BT_IMPRIMIR;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button BT_SUBIR;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button BT_SALIDA;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label L_ITEMS;
        private System.Windows.Forms.Label label2;

    }

}