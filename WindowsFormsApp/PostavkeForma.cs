using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCLibrary;
using WindowsFormsApp.Properties;
using WindowsFormsApp.Resources;

namespace WindowsFormsApp
{
    public partial class PostavkeForma : Form
    {
        public List<string> postavke = new List<string>();
        private string stariJezik;
        private string stariSpolpol;

        public PostavkeForma()
        {
            InitializeComponent();

            rbEngleski.CheckedChanged += new EventHandler(rbJezik_CheckedChanged);
            rbHrvatski.CheckedChanged += new EventHandler(rbJezik_CheckedChanged);
            rbMuski.CheckedChanged += new EventHandler(rbTim_CheckedChanged);
            rbZenski.CheckedChanged += new EventHandler(rbTim_CheckedChanged);


            if (WCPostavke.DatotekaPostoji())
            {
                postavke = WCPostavke.UcitajPostavke();

                stariJezik = postavke[0];
                stariSpolpol = postavke[1];

                //  jezik
                if (postavke[0] == "hr")
                {
                    rbHrvatski.Checked = true;
                }
                else
                {
                    rbEngleski.Checked = true;
                }

                //  spol
                if (postavke[1] == "MEN")
                {
                    rbMuski.Checked = true;
                }
                else
                {
                    rbZenski.Checked = true;
                }
            }
            else
            {
                //  inicijalne vrijednosti
                postavke.Clear();
                postavke.Add("hr");     //  jezik
                rbHrvatski.Checked = true;
                postavke.Add("MEN");    //  spol
                rbMuski.Checked = true;
                postavke.Add("");       //  tim
            };

            PostaviJezik();

        }

        private void PostaviJezik()
        {
            var kultura = new CultureInfo(postavke[0]);
            System.Threading.Thread.CurrentThread.CurrentUICulture = kultura;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Resource));
            resources.ApplyResources(this, "PostavkeForma");
            applyResources(resources, this.Controls);
        }

        private void applyResources(ComponentResourceManager resources, Control.ControlCollection ctls)
        {
            //resources.ApplyResources(Form1.Text, "Form1");
            foreach (Control ctl in ctls)
            {
                resources.ApplyResources(ctl, ctl.Name);
                applyResources(resources, ctl.Controls);
            }
        }

        private void rbTim_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (rbMuski.Checked)
            {
                postavke[1] = "MEN";
            }
            else if (rbZenski.Checked)
            {
                postavke[1] = "WOMEN";
            }

            if (stariSpolpol != postavke[1])
            {
                if (postavke.Count() > 2)
                {
                    postavke[2] = "";   //  brisanje odabranog tima
                }
            }
        }

        private void rbJezik_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (rbHrvatski.Checked)
            {
                postavke[0] = "hr";
            }
            else if (rbEngleski.Checked)
            {
                postavke[0] = "en";
            }

            PostaviJezik();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void Postavke_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnSpremi;
        }

        private void Postavke_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;

                case Keys.Enter:
                    this.DialogResult = DialogResult.OK;
                    SpremiPostavke();
                    break;

                default:
                    break;
            }
        }

        private void SpremiPostavke()
        {
            WCPostavke.SpremiPostavke(postavke);
            this.Close();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SpremiPostavke();
        }
    }
}
