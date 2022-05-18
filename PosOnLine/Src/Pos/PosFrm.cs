using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pos
{

    public partial class PosFrm : Form
    {

        private Gestion _controlador; 
        private Timer _hora;

     
        public PosFrm()
        {
            InitializeComponent();

            _hora = new Timer();
            _hora.Interval = 1000;
            _hora.Start();
            _hora.Tick+=_hora_Tick;

            InicializarGrid();
            Limpiar();
        }

        private void _venta_ProcesarOk(object sender, EventArgs e)
        {
            Limpiar();
            Actualizar();
        }

        private void _hora_Tick(object sender, EventArgs e)
        {
            L_HORA.Text = DateTime.Now.ToLongTimeString();
        }

        private void _ctrItem_PrdAcutalCambioOk(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void Limpiar()
        {
            L_IMPORTE.Text = "0.00";
            L_TOTAL_ITEMS.Text = "0";
            L_TOTAL_KILOS.Text = "0.00";
            L_TOTAL_RENGLONES.Text = "0";
            L_PRODUCTO.Text = "";
            L_PRD_NETO.Text = "0.00";
            L_PRD_TASA.Text = "Ex";
            L_PRD_IVA.Text = "0.00";
            L_PRD_CONT.Text = "1";
            L_CLIENTE.Text = "";
            L_MONTO_DIVISA.Text = "0.00";
            L_IMPORTE_DIVISA.Text = "0.00";
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var f2 = new Font("Serif", 8, FontStyle.Regular);

            DGV_DETALLE.AllowUserToAddRows = false;
            DGV_DETALLE.AllowUserToDeleteRows = false;
            DGV_DETALLE.AutoGenerateColumns = false;
            DGV_DETALLE.AllowUserToResizeRows = false;
            DGV_DETALLE.AllowUserToResizeColumns = false;
            DGV_DETALLE.AllowUserToOrderColumns = false;
            DGV_DETALLE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_DETALLE.MultiSelect = false;
            DGV_DETALLE.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "NombrePrd";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.MinimumWidth = 140;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Cantidad";
            c2.Name = "Cantidad";
            c2.HeaderText = "Cant";
            c2.Visible = true;
            c2.Width = 60;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "EmpaqueCont";
            c9.HeaderText = "Empaque";
            c9.Visible = true;
            c9.Width = 120;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f1;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Importe";
            c3.HeaderText = "Precio/Full";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "ImporteDivisa";
            c7.HeaderText = "$";
            c7.Visible = true;
            c7.Width = 80;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "TasaIvaDescripcion";
            c4.HeaderText = "%Tasa";
            c4.Visible = true;
            c4.Width = 60;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "TotalItem";
            c5.HeaderText = "Importe";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "TotalItemDivisa";
            c8.HeaderText = "$";
            c8.Visible = true;
            c8.Width = 80;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewCheckBoxColumn();
            c6.DataPropertyName = "EsPesado";
            c6.HeaderText = "Kg";
            c6.Name = "EsPesado";
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.Width = 30;

            DGV_DETALLE.Columns.Add(c1);
            DGV_DETALLE.Columns.Add(c2);
            DGV_DETALLE.Columns.Add(c9);
            DGV_DETALLE.Columns.Add(c3);
            DGV_DETALLE.Columns.Add(c7);
            DGV_DETALLE.Columns.Add(c4);
            DGV_DETALLE.Columns.Add(c5);
            DGV_DETALLE.Columns.Add(c8);
            DGV_DETALLE.Columns.Add(c6);
        }
    
        private void DGV_DETALLE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_DETALLE.Columns[e.ColumnIndex].Name.Equals("EsPesado"))
            {
                DataGridViewCell cell = this.DGV_DETALLE.Rows[e.RowIndex].Cells[1];
                if ((bool)e.Value)
                {
                    cell.Style.Format = "n3";
                }
                else
                {
                    cell.Style.Format = "n0";
                }
            }
        }


        private void PosVenta_Load(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;

            L_MONTO_DIVISA.Text = _controlador.TasaCambioActual.ToString("n2");
            L_FECHA.Text = "Hoy : "+DateTime.Now.ToShortDateString();
            L_HORA.Text = "";
            L_USUARIO.Text = _controlador.UsuarioActual;
            L_ESTACION.Text = _controlador.EquipoEstacion;
            DGV_DETALLE.DataSource = _controlador.ItemSource;
            Actualizar();
        }

        private void BT_CONSULTAR_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            _controlador.Consultor();
            Actualizar();
        }

        private void ActivarBuscar()
        {
            TB_BUSCAR.Text = "";
            TB_BUSCAR.Focus();
        }

        private void TB_BUSCAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                BuscarProducto();
            }
        }
        private void BuscarProducto()
        {
            _controlador.BuscarProducto(TB_BUSCAR.Text.Trim().ToUpper());
            Actualizar();
            ActivarBuscar();
        }

        private void ActualizarTotal()
        {
            L_CTAS_PEND.Text = _controlador.CntCtasPendientes.ToString("n0");
            L_TOTAL_ITEMS.Text = _controlador.CantItem.ToString("n0");
            L_TOTAL_KILOS.Text = _controlador.TotalPeso.ToString("n3");
            L_TOTAL_RENGLONES.Text = _controlador.CantRenglones.ToString("n0");
            L_IMPORTE.Text=_controlador.Importe.ToString("n2");
            L_IMPORTE_DIVISA.Text = "$"+_controlador.ImporteDivisa.ToString("n2");
            ActualizarItem();
            DGV_DETALLE.Refresh();
        }

        private void BT_CLIENTE_Click(object sender, EventArgs e)
        {
            Cliente();
        }
        private void Cliente()
        {
            _controlador.ClienteBuscar();
            ActualizarCliente();
            IrFoco();
        }

        private void ActualizarCliente()
        {
            L_CLIENTE.Text = _controlador.ClienteData;
        }

        private void TB_BUSCAR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==  (char)43 || e.KeyChar== (char)Keys.Oemplus )
            {
                if (TB_BUSCAR.Text == "")
                {
                    IncrementarItem();
                    e.Handled = true;
                }
            }
            if (e.KeyChar == (char)45 || e.KeyChar == (char)Keys.OemMinus)
            {
                if (TB_BUSCAR.Text == "")
                {
                    Restar();
                    e.Handled = true;
                }
            }
            //if (e.KeyChar == (char)42)
            //{
            //    if (TB_BUSCAR.Text == "")
            //    {
            //        Multiplicar();
            //        e.Handled = true;
            //    }
            //}
        }

        private void BT_SUMAR_Click(object sender, EventArgs e)
        {
            IncrementarItem();
        }
        private void IncrementarItem()
        {
            _controlador.IncrementarItem();
            Actualizar();
        }

        private void AnularVenta()
        {
            _controlador.AnularVenta();
            Actualizar();
        }

        private void ActualizarModo() 
        {
            L_MODO_FUNCION.Text = "Facturación :)";
            L_MODO_FUNCION.ForeColor = Color.Yellow;

            if (_controlador.IsNotaCredito)
            {
                L_MODO_FUNCION.Text = ":( Nt/Crédito";
                L_MODO_FUNCION.ForeColor = Color.Red;
            }
            else if (_controlador.IsNotaEntrega)
            {
                L_MODO_FUNCION.Text = ":) Nt/Entrega ):";
                L_MODO_FUNCION.ForeColor = Color.Black;
            }
        }

        private void IrFoco()
        {
            TB_BUSCAR.Focus();
        }

        private void BT_MULTIPLICA_Click(object sender, EventArgs e)
        {
            Multiplicar();
        }

        private void Multiplicar()
        {
            _controlador.Multiplicar();
            Actualizar();
        }

        private void BT_RESTAR_Click(object sender, EventArgs e)
        {
            Restar();
        }

        private void Restar()
        {
            _controlador.DecrementarItem();
            Actualizar();
        }

        private void BT_TOTAL_Click(object sender, EventArgs e)
        {
            Totalizar();
        }
     
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void PosVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_controlador.SalirIsOk)
            {
                MessageBox.Show("HAY ITEMS EN PROCESO !!!", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                e.Cancel = true;
            }
        }
    

        private void BT_CALCULADORA_Click(object sender, EventArgs e)
        {
            ActivarCalculadora();
        }

        private void ActivarCalculadora()
        {
            _controlador.ActivarCalculadora();
            Actualizar();
        }

        private void BT_LISTA_OFERTA_Click(object sender, EventArgs e)
        {
            ListaOferta();
        }

        private void ListaOferta()
        {
            //_venta.ListaOferta();
            Actualizar();
        }

        private void BT_LISTA_PLU_Click(object sender, EventArgs e)
        {
            ListaPlu();
        }

        private void ListaPlu()
        {
            _controlador.ListaPlu();
            Actualizar();
        }

        private void BT_DEVOLUCION_Click(object sender, EventArgs e)
        {
            DevolucionItem();
        }

        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            AnularVenta();
        }

        private void Totalizar()
        {
            _controlador.Totalizar();
            if (_controlador.IsTickeraOk) 
            {
                printDocument1.Print();
            }
            Actualizar();
        }

        private void BT_PENDIENTE_Click(object sender, EventArgs e)
        {
            DejarCtaEnPendiente();
        }

        private void DejarCtaEnPendiente()
        {
            _controlador.DejarCtaPendiente();
            Actualizar();
        }

        private void BT_ABRIR_PENDIENTE_Click(object sender, EventArgs e)
        {
            AbrirCtaEnPendiente();
        }
        private void AbrirCtaEnPendiente()
        {
            _controlador.AbriCtaPendiente();
            Actualizar();
        }

        private void DevolucionItem()
        {
            _controlador.DevolucionItem();
            Actualizar();
        }

        private void PosVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.KeyCode == Keys.N) 
            {
                NotaEntrega();
            }
            if (e.KeyCode == Keys.F1) 
            {
                IrFoco();
            }
            if (e.KeyCode == Keys.F2)
            {
                Cliente();
            }
            if (e.KeyCode == Keys.F3)
            {
                Consultar();
            }
            if (e.KeyCode == Keys.F4)
            {
                DevolucionItem();
            }
            if (e.KeyCode == Keys.F5)
            {
                DejarCtaEnPendiente();
            }
            if (e.KeyCode == Keys.F6)
            {
                AbrirCtaEnPendiente();
            }
            if (e.KeyCode == Keys.Delete)
            {
                AnularVenta();
            }
            if (e.KeyCode == Keys.F10)
            {
                Totalizar();
            }
        }

        private void NotaEntrega()
        {
            _controlador.NotaEntrega();
            ActualizarModo();
        }

        private void _bs_CurrentChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar() 
        {
            ActualizarCliente();
            ActualizarTotal();
            ActualizarModo();
            IrFoco();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        public void ActualizarItem()
        {
            L_PRODUCTO.Text = _controlador.ProductoNombre;
            L_PRD_NETO.Text = _controlador.ProductoPrecioNeto.ToString("n2");
            L_PRD_TASA.Text = _controlador.ProductoTasaIva;
            L_PRD_IVA.Text = _controlador.ProductoIva.ToString("n2");
            L_PRD_CONT.Text = _controlador.ProductoContenido.ToString("n0");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Cancel = false;
            _controlador.Imprimir(e);
        }

        private void DGV_DETALLE_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                CambiarPrecio();
            }
        }
        private void CambiarPrecio()
        {
            _controlador.CambiarPrecio();
            Actualizar();
        }

    }

}