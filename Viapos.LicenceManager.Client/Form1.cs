using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Viapos.LicenceManager.LicenceInformations.Enum;
using Viapos.LicenceManager.SystemInformations.Tools;

namespace Viapos.LicenceManager.Client
{
    public partial class Form1 : Form
    {
        LicenceConfirmation confirm = new LicenceConfirmation();
        public Form1()
        {

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (confirm.ModuleConfirm(ModuleTypeEnum.Stok))
            {
                MessageBox.Show("MODÜL KULLANILABİLİR");
            }
            else
            {
                MessageBox.Show("MODÜL KULLANILAMAZ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (confirm.ModuleConfirm(ModuleTypeEnum.Cari))
            {
                MessageBox.Show("MODÜL KULLANILABİLİR");
            }
            else
            {
                MessageBox.Show("MODÜL KULLANILAMAZ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (confirm.ModuleConfirm(ModuleTypeEnum.Fatura))
            {
                MessageBox.Show("MODÜL KULLANILABİLİR");
            }
            else
            {
                MessageBox.Show("MODÜL KULLANILAMAZ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (confirm.ModuleConfirm(ModuleTypeEnum.İrsaliye))
            {
                MessageBox.Show("MODÜL KULLANILABİLİR");
            }
            else
            {
                MessageBox.Show("MODÜL KULLANILAMAZ");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (confirm.ModuleConfirm(ModuleTypeEnum.Kasa))
            {
                MessageBox.Show("MODÜL KULLANILABİLİR");
            }
            else
            {
                MessageBox.Show("MODÜL KULLANILAMAZ");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(confirm.LicenseCount().ToString());
        }
    }
}
