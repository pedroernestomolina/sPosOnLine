namespace PosVerificador.Src.Principal
{
    partial class PrincipalFrm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuArchivoSalida = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReporteDocumetosVerificados = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.P_TITULO = new System.Windows.Forms.Panel();
            this.L_TITULO = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.TB_CODIGO = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.BT_LEER = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PB_RESULT = new System.Windows.Forms.PictureBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.L_MSG_ERROR = new System.Windows.Forms.Label();
            this.P_PIE = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.L_USUARIO = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.L_TITULO_2 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.P_TITULO.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_RESULT)).BeginInit();
            this.panel12.SuspendLayout();
            this.P_PIE.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(615, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuArchivoSalida});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // MenuArchivoSalida
            // 
            this.MenuArchivoSalida.Image = global::PosVerificador.Properties.Resources.bt_salida_2;
            this.MenuArchivoSalida.Name = "MenuArchivoSalida";
            this.MenuArchivoSalida.Size = new System.Drawing.Size(105, 22);
            this.MenuArchivoSalida.Text = "Salida";
            this.MenuArchivoSalida.Click += new System.EventHandler(this.MenuArchivoSalida_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuReporteDocumetosVerificados});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // MenuReporteDocumetosVerificados
            // 
            this.MenuReporteDocumetosVerificados.Image = global::PosVerificador.Properties.Resources.bt_imprimir_3;
            this.MenuReporteDocumetosVerificados.Name = "MenuReporteDocumetosVerificados";
            this.MenuReporteDocumetosVerificados.Size = new System.Drawing.Size(203, 22);
            this.MenuReporteDocumetosVerificados.Text = "Documentos Verificados";
            this.MenuReporteDocumetosVerificados.Click += new System.EventHandler(this.MenuReporteDocumetosVerificados_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 482);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.P_TITULO, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.P_PIE, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(615, 482);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // P_TITULO
            // 
            this.P_TITULO.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.P_TITULO.Controls.Add(this.L_TITULO);
            this.P_TITULO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_TITULO.Location = new System.Drawing.Point(1, 1);
            this.P_TITULO.Margin = new System.Windows.Forms.Padding(1);
            this.P_TITULO.Name = "P_TITULO";
            this.P_TITULO.Padding = new System.Windows.Forms.Padding(2);
            this.P_TITULO.Size = new System.Drawing.Size(613, 48);
            this.P_TITULO.TabIndex = 0;
            // 
            // L_TITULO
            // 
            this.L_TITULO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TITULO.ForeColor = System.Drawing.Color.White;
            this.L_TITULO.Location = new System.Drawing.Point(2, 2);
            this.L_TITULO.Name = "L_TITULO";
            this.L_TITULO.Size = new System.Drawing.Size(609, 44);
            this.L_TITULO.TabIndex = 1;
            this.L_TITULO.Text = "VERIFICADOR DE DOCUMENTOS";
            this.L_TITULO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 51);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(613, 370);
            this.panel3.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(613, 370);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 1);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(611, 110);
            this.panel5.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel8, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(611, 110);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gold;
            this.tableLayoutPanel3.SetColumnSpan(this.panel6, 2);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(1, 1);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2);
            this.panel6.Size = new System.Drawing.Size(609, 30);
            this.panel6.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(605, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "INTRODUZCA CODIGO A VERIFICAR:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.panel7, 2);
            this.panel7.Controls.Add(this.TB_CODIGO);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(1, 33);
            this.panel7.Margin = new System.Windows.Forms.Padding(1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(609, 27);
            this.panel7.TabIndex = 1;
            // 
            // TB_CODIGO
            // 
            this.TB_CODIGO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TB_CODIGO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_CODIGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_CODIGO.Location = new System.Drawing.Point(0, 0);
            this.TB_CODIGO.Name = "TB_CODIGO";
            this.TB_CODIGO.Size = new System.Drawing.Size(609, 26);
            this.TB_CODIGO.TabIndex = 6;
            this.TB_CODIGO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CTRL_KeyDown);
            this.TB_CODIGO.Leave += new System.EventHandler(this.TB_CODIGO_Leave);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.BT_LEER);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(367, 62);
            this.panel8.Margin = new System.Windows.Forms.Padding(1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(243, 47);
            this.panel8.TabIndex = 2;
            // 
            // BT_LEER
            // 
            this.BT_LEER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_LEER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_LEER.Image = global::PosVerificador.Properties.Resources.bt_buscar;
            this.BT_LEER.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BT_LEER.Location = new System.Drawing.Point(0, 0);
            this.BT_LEER.Name = "BT_LEER";
            this.BT_LEER.Size = new System.Drawing.Size(243, 47);
            this.BT_LEER.TabIndex = 5;
            this.BT_LEER.Text = "BUSCAR ";
            this.BT_LEER.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BT_LEER.UseVisualStyleBackColor = true;
            this.BT_LEER.Click += new System.EventHandler(this.BT_LEER_Click);
            this.BT_LEER.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CTRL_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.Controls.Add(this.tableLayoutPanel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 113);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 256);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel12, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(611, 256);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.PB_RESULT);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(364, 254);
            this.panel4.TabIndex = 0;
            // 
            // PB_RESULT
            // 
            this.PB_RESULT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PB_RESULT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_RESULT.InitialImage = null;
            this.PB_RESULT.Location = new System.Drawing.Point(2, 2);
            this.PB_RESULT.Name = "PB_RESULT";
            this.PB_RESULT.Size = new System.Drawing.Size(360, 250);
            this.PB_RESULT.TabIndex = 0;
            this.PB_RESULT.TabStop = false;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.L_MSG_ERROR);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(367, 1);
            this.panel12.Margin = new System.Windows.Forms.Padding(1);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(4);
            this.panel12.Size = new System.Drawing.Size(243, 254);
            this.panel12.TabIndex = 1;
            // 
            // L_MSG_ERROR
            // 
            this.L_MSG_ERROR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_MSG_ERROR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_MSG_ERROR.Location = new System.Drawing.Point(4, 4);
            this.L_MSG_ERROR.Name = "L_MSG_ERROR";
            this.L_MSG_ERROR.Size = new System.Drawing.Size(235, 246);
            this.L_MSG_ERROR.TabIndex = 0;
            this.L_MSG_ERROR.Text = "label3";
            this.L_MSG_ERROR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P_PIE
            // 
            this.P_PIE.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.P_PIE.Controls.Add(this.tableLayoutPanel4);
            this.P_PIE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_PIE.Location = new System.Drawing.Point(1, 423);
            this.P_PIE.Margin = new System.Windows.Forms.Padding(1);
            this.P_PIE.Name = "P_PIE";
            this.P_PIE.Size = new System.Drawing.Size(613, 58);
            this.P_PIE.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Controls.Add(this.panel9, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel10, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel11, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(613, 58);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tableLayoutPanel7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(1, 1);
            this.panel9.Margin = new System.Windows.Forms.Padding(1);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2);
            this.panel9.Size = new System.Drawing.Size(212, 56);
            this.panel9.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.22222F));
            this.tableLayoutPanel7.Controls.Add(this.panel18, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.panel19, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(208, 52);
            this.tableLayoutPanel7.TabIndex = 4;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.label3);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(1, 1);
            this.panel18.Margin = new System.Windows.Forms.Padding(1);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel7.SetRowSpan(this.panel18, 2);
            this.panel18.Size = new System.Drawing.Size(55, 50);
            this.panel18.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Image = global::PosVerificador.Properties.Resources.bt_usuario__2_;
            this.label3.Location = new System.Drawing.Point(2, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 46);
            this.label3.TabIndex = 0;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.L_USUARIO);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(58, 1);
            this.panel19.Margin = new System.Windows.Forms.Padding(1);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel7.SetRowSpan(this.panel19, 2);
            this.panel19.Size = new System.Drawing.Size(149, 50);
            this.panel19.TabIndex = 1;
            // 
            // L_USUARIO
            // 
            this.L_USUARIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_USUARIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_USUARIO.ForeColor = System.Drawing.Color.Yellow;
            this.L_USUARIO.Location = new System.Drawing.Point(2, 2);
            this.L_USUARIO.Name = "L_USUARIO";
            this.L_USUARIO.Size = new System.Drawing.Size(145, 46);
            this.L_USUARIO.TabIndex = 5;
            this.L_USUARIO.Text = "01\r\nPedro Molina\r\nAdministrador";
            this.L_USUARIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.L_TITULO_2);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(215, 1);
            this.panel10.Margin = new System.Windows.Forms.Padding(1);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(2);
            this.panel10.Size = new System.Drawing.Size(212, 56);
            this.panel10.TabIndex = 1;
            // 
            // L_TITULO_2
            // 
            this.L_TITULO_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_TITULO_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TITULO_2.Location = new System.Drawing.Point(2, 2);
            this.L_TITULO_2.Name = "L_TITULO_2";
            this.L_TITULO_2.Size = new System.Drawing.Size(208, 52);
            this.L_TITULO_2.TabIndex = 2;
            this.L_TITULO_2.Text = "VER";
            this.L_TITULO_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.BT_SALIR);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(429, 1);
            this.panel11.Margin = new System.Windows.Forms.Padding(1);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(2);
            this.panel11.Size = new System.Drawing.Size(183, 56);
            this.panel11.TabIndex = 2;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Image = global::PosVerificador.Properties.Resources.bt_salida_2;
            this.BT_SALIR.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BT_SALIR.Location = new System.Drawing.Point(2, 2);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(179, 52);
            this.BT_SALIR.TabIndex = 0;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // PrincipalFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrincipalFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrincipalFrm_FormClosing);
            this.Load += new System.EventHandler(this.PrincipalFrm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.P_TITULO.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_RESULT)).EndInit();
            this.panel12.ResumeLayout(false);
            this.P_PIE.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel P_TITULO;
        private System.Windows.Forms.Label L_TITULO;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox TB_CODIGO;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button BT_LEER;
        private System.Windows.Forms.Panel P_PIE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuArchivoSalida;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox PB_RESULT;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label L_MSG_ERROR;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Label L_USUARIO;
        private System.Windows.Forms.ToolStripMenuItem MenuReporteDocumetosVerificados;
        private System.Windows.Forms.Label L_TITULO_2;


    }
}