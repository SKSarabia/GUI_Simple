using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Simple
{
    public partial class Form1 : Form
    {
        private Label lblTitle;
        private TextBox txtNombre;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private ListBox lstContactos;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuArchivo;
        private ToolStripMenuItem menuSalir;
        private ToolStripMenuItem menuAyuda;
        private ToolStripMenuItem menuAcercaDe;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form
            this.Text = "Gestión de Contactos";
            this.Size = new Size(400, 460);

            // Label
            lblTitle = new Label();
            lblTitle.Text = "Gestión de Contactos";
            lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitle.Location = new Point(10, 25);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            // TextBox
            txtNombre = new TextBox();
            txtNombre.ForeColor = Color.Gray;
            txtNombre.Text = "Nombre";
            txtNombre.Location = new Point(10, 50);
            txtNombre.Enter += new EventHandler(RemovePlaceholderText);
            txtNombre.Leave += new EventHandler(AddPlaceholderText);
            this.Controls.Add(txtNombre);

            txtTelefono = new TextBox();
            txtTelefono.ForeColor = Color.Gray;
            txtTelefono.Text = "Teléfono";
            txtTelefono.Location = new Point(10, 90);
            txtTelefono.Enter += new EventHandler(RemovePlaceholderText);
            txtTelefono.Leave += new EventHandler(AddPlaceholderText);
            this.Controls.Add(txtTelefono);

            txtEmail = new TextBox();
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Text = "Correo Electrónico";
            txtEmail.Location = new Point(10, 130);
            txtEmail.Enter += new EventHandler(RemovePlaceholderText);
            txtEmail.Leave += new EventHandler(AddPlaceholderText);
            this.Controls.Add(txtEmail);

            // Button
            btnAgregar = new Button();
            btnAgregar.Text = "Agregar Contacto";
            btnAgregar.Location = new Point(10, 170);
            btnAgregar.Click += new EventHandler(BtnAgregar_Click);
            this.Controls.Add(btnAgregar);

            btnEliminar = new Button();
            btnEliminar.Text = "Eliminar Contacto";
            btnEliminar.Location = new Point(150, 170);
            btnEliminar.Click += new EventHandler(BtnEliminar_Click);
            this.Controls.Add(btnEliminar);

            btnLimpiar = new Button();
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.Location = new Point(290, 170);
            btnLimpiar.Click += new EventHandler(BtnLimpiar_Click);
            this.Controls.Add(btnLimpiar);

            // ListBox
            lstContactos = new ListBox();
            lstContactos.Location = new Point(10, 210);
            lstContactos.Size = new Size(360, 200);
            this.Controls.Add(lstContactos);

            // MenuStrip
            menuStrip = new MenuStrip();
            menuArchivo = new ToolStripMenuItem("Archivo");
            menuSalir = new ToolStripMenuItem("Salir");
            menuSalir.Click += new EventHandler(MenuSalir_Click);
            menuArchivo.DropDownItems.Add(menuSalir);

            menuAyuda = new ToolStripMenuItem("Ayuda");
            menuAcercaDe = new ToolStripMenuItem("Acerca de");
            menuAcercaDe.Click += new EventHandler(MenuAcercaDe_Click);
            menuAyuda.DropDownItems.Add(menuAcercaDe);

            menuStrip.Items.Add(menuArchivo);
            menuStrip.Items.Add(menuAyuda);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.ForeColor == Color.Gray)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.ForeColor = Color.Gray;
                switch (textBox.Name)
                {
                    case "txtNombre":
                        textBox.Text = "Nombre";
                        break;
                    case "txtTelefono":
                        textBox.Text = "Teléfono";
                        break;
                    case "txtEmail":
                        textBox.Text = "Correo Electrónico";
                        break;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.ForeColor == Color.Gray || txtTelefono.ForeColor == Color.Gray || txtEmail.ForeColor == Color.Gray ||
                string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string contacto = $"{txtNombre.Text} - {txtTelefono.Text} - {txtEmail.Text}";
            lstContactos.Items.Add(contacto);
            MessageBox.Show("Contacto agregado exitosamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (lstContactos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un contacto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lstContactos.Items.Remove(lstContactos.SelectedItem);
            MessageBox.Show("Contacto eliminado exitosamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "Nombre";
            txtNombre.ForeColor = Color.Gray;
            txtTelefono.Text = "Teléfono";
            txtTelefono.ForeColor = Color.Gray;
            txtEmail.Text = "Correo Electrónico";
            txtEmail.ForeColor = Color.Gray;
            MessageBox.Show("Datos borrados exitosamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicación sobre Gestión de Contactos\nVersión 1.0\nDesarrollada por Luis Sarabia", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}


