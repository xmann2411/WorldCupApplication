using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WCLibrary;
using WCLibrary.Modeli;
using WindowsFormsApp.Resources;
using WindowsFormsApp.UserControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp
{
    public partial class GlavnaForma : Form
    {
        private  List<string> postavke = new List<string>();
        private List<Team> timovi;
        public List<Player> igraci;
        private List<Match> utakmice;
        ContextMenuStrip cm = new ContextMenuStrip();

        public GlavnaForma()
        {
            InitializeComponent();

            //allow drop
            panelIgraci.AllowDrop= true;
            panelOmiljeni.AllowDrop= true;

            //kontrolira jesu li ti podaci kompatibilni za drop
            //omogucava dragEnter
            panelIgraci.DragEnter += Panel_DragEnter;
            panelOmiljeni.DragEnter += Panel_DragEnter;

            panelIgraci.DragDrop += Panel_DragDrop;
            panelOmiljeni.DragDrop += Panel_DragDrop;

            cm.Items.Add(Resource.ucitajSliku);
            cm.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);


            if (WCPostavke.DatotekaPostoji())
            {
                postavke = WCPostavke.UcitajPostavke();
            }
            else
            {
                var postavkeForma = new PostavkeForma();
                
                DialogResult dr = postavkeForma.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    Load += (s, e) => Close();
                    return;
                }
                postavke.Clear();
                postavke = postavkeForma.postavke;
            };

            PostaviJezik();

            UcitajTimove();
        }

        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            //provjerava podatke koje zelimo prebacit
            if (!e.Data.GetDataPresent(typeof(List<Igrac>)))
                return;

            //moze move sad
            e.Effect = DragDropEffects.Move;


            //if (!e.Data.GetDataPresent(typeof(string)))
            //    return;

            //var name = e.Data.GetData(typeof(string)) as string;
            //var control = this.Controls.Find(name, true).FirstOrDefault();
            //if (control != null)
            //{
            //    e.Effect = DragDropEffects.Move;
            //}
        }

        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            //opet provjerava jesu li okej podaci za dropat
            if (!e.Data.GetDataPresent(typeof(List<Igrac>)))
                return;

            var list = e.Data.GetData(typeof(List<Igrac>)) as List<Igrac>;
            foreach (var item in list)
            {
                //spremam imena u panel
                var name = item.Name;
                item.selektiran = false;
                item.BackColor = Color.FromArgb(153, 180, 209);
                var control = this.Controls.Find(name, true).FirstOrDefault();
                if (control != null)
                {
                    item.Parent.Controls.Remove(control);
                    //control.Parent.Controls.Remove(control);
                    var panel = sender as FlowLayoutPanel;
                    ((FlowLayoutPanel)sender).Controls.Add(control);
                    //postavljanje zvjezdica ako si u omiljene dropo
                    if (panel.Name == "panelOmiljeni")
                    {
                        control.Controls.Find("pbStar", true).FirstOrDefault().Visible = true;
                    }
                    else
                    {
                        control.Controls.Find("pbStar", true).FirstOrDefault().Visible = false;
                    }
                    //promjena imena
                    var igrac = igraci.FirstOrDefault(i => i.Name == name.Replace('_', ' '));
                    if (igrac != null)
                    {
                        igrac.Favorite = !igrac.Favorite;
                    }
                }
            }

        }

        private void PostaviJezik()
        {
            var kultura = new CultureInfo(postavke[0]);
            System.Threading.Thread.CurrentThread.CurrentUICulture = kultura;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Resource));
            resources.ApplyResources(this, "GlavnaForma");
            applyResources(resources, this.Controls);
        }

        private void applyResources(ComponentResourceManager resources, Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                if (ctl.Name == "panelOmiljeni" || ctl.Name == "panelIgraci")
                {
                    continue;
                }
                resources.ApplyResources(ctl, ctl.Name);
                applyResources(resources, ctl.Controls);
            }
        }

        private void GlavnaForma_Load(object sender, EventArgs e)
        {
            this.FormClosing += GlavnaForma_FormClosing;
        }

        private void GlavnaForma_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Display a MsgBox asking the user to save changes or abort.
            if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Cancel the Closing event from closing the form.
                //e.Cancel = true;
                // Call method to save file...
                if (igraci.Count > 0)
                {
                    WCPodaci.SpremiPodatkeForme(igraci, postavke[1], postavke[2]);
                }
            }
        }


        public async void UcitajTimove()
        {
            var spol = postavke[1];
            var fifaCode = postavke[2];

            try
            {
                toolStripStatusLabel.Text = Resource.ucitavam;
                timovi = await WCPodaci.DohvatiTimove(spol);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = "";
                MessageBox.Show($"{Resource.greska} " + ex.Message);
            }

            comboBoxTim.BeginInvoke(
                (Action)(() =>
                {
                    comboBoxTim.Items.Clear();
                    foreach (var tim in timovi.OrderBy(t => t.Naziv))
                    {
                        comboBoxTim.Items.Add(tim.Naziv);
                    }

                    if (postavke.Count() >= 2)
                    {
                        if (fifaCode != "")
                        {
                            comboBoxTim.SelectItemByValue(fifaCode);
                        }
                        else
                        {
                            comboBoxTim.Text = "";
                        }
                    }

                }));
            
            toolStripStatusLabel.Text = "";
        }

        private void UcitajIgraceUPanele(List<Player> igraci)
        {
            panelIgraci.Controls.Clear();
            panelOmiljeni.Controls.Clear();

            if (igraci != null && igraci.Count() > 0)
            {
                foreach (var igrac in igraci)
                {
                    var igracControl = new Igrac(igrac);
                    igracControl.slikaIgraca.ContextMenuStrip = cm;
                    if (igrac.Image != null)
                    {
                        try
                        {
                            igracControl.slikaIgraca.Image = new Bitmap(igrac.Image);
                        }
                        catch (FileNotFoundException ex)
                        {
                            MessageBox.Show($"{Resource.greska} " + Resource.greskaSlika);
                        }
                    }
                    if (igrac.Favorite)
                    {
                        panelOmiljeni.Controls.Add(igracControl);
                    }
                    else
                    {
                        panelIgraci.Controls.Add(igracControl);
                    }
                }
            }
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip menu = sender as ContextMenuStrip;
            Control sourceControl = menu.SourceControl;

            var igracClick = sourceControl.Parent as Igrac;

            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = $"{Resource.imageFiles}(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                //var igrac = sender as Igrac;
                igracClick.slikaIgraca.Image = new Bitmap(open.FileName);
                // image file path  
                var igracSlika = igraci.FirstOrDefault(i => i.Name == igracClick.Name.Replace('_', ' '));
                igracSlika.Image = open.FileName;
                //textBox1.Text = open.FileName;
            }

        }

        private void comboBoxTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fifaCode = comboBoxTim.Text.Substring(comboBoxTim.Text.IndexOf('(') + 1, 3);
            if (postavke.Count() <= 2)
            {
                postavke.Add(fifaCode);
            }
            else
            {
                postavke[2] = fifaCode;
            }
            WCPostavke.SpremiPostavke(postavke);
            UcitajIgrace(postavke[1], fifaCode);
        }

        private async void UcitajIgrace(string spol, string fifaCode)
        {
            try
            {
                toolStripStatusLabel.Text = Resource.ucitavam;
                igraci = await WCPodaci.DohvatiIgrace(spol, fifaCode);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = "";
                MessageBox.Show($"{Resource.greska} " + ex.Message);
            }
            UcitajIgraceUPanele(igraci);
            toolStripStatusLabel.Text = "";
        }

        private void btnPostavke_Click(object sender, EventArgs e)
        {
            var postavkeForma = new PostavkeForma();
            DialogResult dr = postavkeForma.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var stariSpol = postavke[1];
                var stariFifaCodel = postavke[2];
                postavke.Clear();
                postavke = postavkeForma.postavke;
                postavke[2] = stariFifaCodel;
                PostaviJezik();
                if (postavke[1] != stariSpol)
                {
                    postavke[2] = "";
                    igraci.Clear();
                    UcitajTimove();
                    UcitajIgraceUPanele(igraci);
                }
            }
        }

        private void btnGolovi_Click(object sender, EventArgs e)
        {
            var igraciPoGolivima = igraci.Where(i => i.ZabijeniGolovi > 0).OrderByDescending(i => i.ZabijeniGolovi).ToList();
            var rangForma = new RangPrint(igraciPoGolivima, "ListaGolova");
            rangForma.ShowDialog();
        }

        private void btnKartoni_Click(object sender, EventArgs e)
        {
            var igraciPoKartonima = igraci.Where(i => i.ZutiKartoni > 0).OrderByDescending(i => i.ZutiKartoni).ToList();
            var rangForma = new RangPrint(igraciPoKartonima, "ListaKartona");
            rangForma.ShowDialog();
        }

        private async void btnUtakmice_Click(object sender, EventArgs e)
        {
            await DohvatiUtakmice(postavke[1], postavke[2]);
            var utakmiceGledatelji = utakmice.OrderByDescending(u => Convert.ToInt32(u.Attendance)).ToList();
            var rangForma = new RangPrint(utakmiceGledatelji);
            rangForma.ShowDialog();
        }

        private async Task DohvatiUtakmice(string spol, string fifaCode)
        {
            try
            {
                toolStripStatusLabel.Text = Resource.ucitavam;
                utakmice = await WCPodaci.DohvatiUtakmice(spol, fifaCode);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = "";
                MessageBox.Show($"{Resource.greska} " + ex.Message);
            }

            toolStripStatusLabel.Text = "";

            return;
        }
    }
}
