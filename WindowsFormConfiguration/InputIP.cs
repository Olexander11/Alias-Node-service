using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormConfiguration
{
    public partial class InputIP : Form
    {
        public InputIP()
        {
            InitializeComponent();

            textBox1.Validating += Ip_Validating;
            textBox2.Validating += Ip_Validating;
            textBox3.Validating += Ip_Validating;
            textBox4.Validating += Ip_Validating;
        }

        public InputIP(string text)
        {
            InitializeComponent();

            textBox1.Validating += Ip_Validating;
            textBox2.Validating += Ip_Validating;
            textBox3.Validating += Ip_Validating;
            textBox4.Validating += Ip_Validating;
            labelInputIp.Text = text;
        }

        private void Ip_Validating(object sender, CancelEventArgs e)
        {
            var box = sender as TextBox;
            try
            {
                if (Int32.Parse(box.Text) < 0 | Int32.Parse(box.Text) > 255)
                {
                    errorProvider1.SetError(box, "Number is out of renge!");
                    box.Select();
                }
                else 
                    errorProvider1.Clear();
            }
            catch (Exception)
            {
                errorProvider1.SetError(box, "Not correct inputing data!");
                box.Select();
            }
        }


        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" | errorProvider1.GetError(textBox4) != "")
            {
                errorProvider1.SetError(textBox4, "Not correct inputing data!");
                textBox4.Select();
                return;
            }

            labelInputIp.Text = textBox3.Text;
            if (textBox3.Text == "" | errorProvider1.GetError(textBox3) != "")
            {
                errorProvider1.SetError(textBox3, "Not correct inputing data!");
                textBox3.Select();
                return;
            }

            if (textBox2.Text == "" | errorProvider1.GetError(textBox2) != "")
            {
                errorProvider1.SetError(textBox2, "Not correct inputing data!");
                textBox2.Select();
                return;
            }

            if (textBox1.Text == "" | errorProvider1.GetError(textBox1) != "")
            {
                errorProvider1.SetError(textBox1, "Not correct inputing data!");
                textBox1.Select();
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}