using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NotificationCenter
{
    public partial class panelAdministracion : Form
    {

        //checkBoxes contendra todos los CheckBox que se generen en base a los usuarios existentes
        List<object> checkBoxes = new List<object>();

        List<string> tokensUsuarios = new List<string>();
        List<string> usuarios = File.ReadAllLines(@"Usuarios.txt").ToList();

        Enviador enviar = new Enviador();



        public panelAdministracion()
        {
            InitializeComponent();

            TabPage tp3 = tabPage3;
            TabPage tp2 = tabPage2;
            TabPage tp1 = tabPage1;

            /*
             * Cada linea del fichero esta compues por Nombre, Token y Rol
             * Vamos iterar cada linea del fichero:
             *  separando cada uno de los 3 elementos para luego guardarlos en una lista
             *  Generamos los CheckBox y luego los colocamos en su respectiva TabPage dependiendo de su Rol
             */

            for (int x = 0; x < usuarios.Count; x++)
            {
                
                string[] elementosUsuarioSplit = usuarios[x].Split(',');
                List<string> elementosUsuario = new List<string>(elementosUsuarioSplit.Length);
                elementosUsuario.AddRange(elementosUsuarioSplit);

                CheckBox box;
                box = new CheckBox();
                box.Tag = elementosUsuario[1]; 
                checkBoxes.Add(box);
                box.Text = string.Join("", elementosUsuario[0]);
                box.AutoSize = true;
                box.Location = new Point(10, 0 * 20);


                if (elementosUsuario[2] == "IT")
                {
                    tp3.Controls.Add(box);
                }
                if (elementosUsuario[2] == "Finanzas")
                {
                    tp1.Controls.Add(box);
                }
                if (elementosUsuario[2] == "Recursos Humanos")
                {
                    tp2.Controls.Add(box);
                }

                
            }
        }


        private void enviar_btn_Click(object sender, EventArgs e)
        {

            //Cuando hacemos click en enviar, verificamos si el usuario ha ingresado información valida

            string titulo = textBox1.Text; 
            string cuerpo = richTextBox1.Text; 

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(cuerpo))
            {
                MessageBox.Show("Revisa el titulo y mensaje, por favor", "NotificationCenter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /**
             * En caso que la data este bien, se comienzan a iterar todos los Checkboxes que se generaron previamente
             * si el checkbox ha sido marcado, se saca su Tag cuyo valor es el token del usuario
             * se verifica si ese token ya esta metido en nuestra lista tokensUsuarios, caso contrario se agrega.
             * Ademas, se contempla el caso en que un Checkbox se marque y luego se deseleccione, su Token se elimina de la lista
             * */

            else
            {
                
                foreach (CheckBox checkbox in checkBoxes)
                {
                    if (checkbox.Checked)
                    {
                        bool alreadyExist = tokensUsuarios.Contains(checkbox.Tag);
                        if (alreadyExist==false) {
                            tokensUsuarios.Add(string.Join("", checkbox.Tag));
                        }
                        
                    }
                    else {
                        tokensUsuarios.Remove(string.Join("", checkbox.Tag));
                    }
                   
                }

                if (tokensUsuarios.Count != 0)
                {
                    enviar.Enviar(titulo, cuerpo, tokensUsuarios);
                }
                else {
                    MessageBox.Show("Selecciona un empleado, por favor", "NotificationCenter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    

            }


        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
