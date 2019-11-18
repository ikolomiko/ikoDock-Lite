using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace ikoDock_Lite
{
    public partial class ikoDock_Lite_Form : Form
    {
        public ikoDock_Lite_Form() => InitializeComponent();

        public void DosyaAc(string yol)
        {
            Process prc = new Process();
            prc.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + $@"{yol}";
            prc.Start();
        }

        public void Animasyon(int artış) => Location = new Point((Location.X + artış), Location.Y);

        private void button1_Click(object sender, EventArgs e)
        {
            if (Location.X != -92) timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point pnt = new Point(-92, 270);
            Animasyon(+4);
            timer2.Stop();
            Opacity = 1;
            if (Location.X >= pnt.X)
            {
                timer1.Stop();
                Location = pnt;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Point pnt = new Point(-146, 270);
            Animasyon(-4);
            timer1.Stop();
            Opacity = 0.4;
            if (Location.X <= pnt.X)
            {
                timer2.Stop();
                Location = pnt;
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (Location.X == -92) timer2.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e) => DosyaAc(@"\Documents");

        private void pictureBox2_Click(object sender, EventArgs e) => DosyaAc(@"\Pictures");

        private void pictureBox3_Click(object sender, EventArgs e) => DosyaAc(@"\Downloads");

        private void pictureBox4_Click(object sender, EventArgs e) => DosyaAc(@"\Music");

        private void pictureBox5_Click(object sender, EventArgs e) => DosyaAc(@"\Videos");

        private void ikoDockuKapatToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
    }
}
