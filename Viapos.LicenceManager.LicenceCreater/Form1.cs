using DevExpress.XtraEditors;
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
using Viapos.LicenceManager.LicenceInformations.Maneger;
using Viapos.LicenceManager.LicenceInformations.Tables;

using Viapos.LicenceManager.LicenceInformations.Tools;
using License = Viapos.LicenceManager.LicenceInformations.Tables.License;

namespace Viapos.LicenceManager.LicenceCreater
{
    public partial class Form1 : XtraForm
    {
        LicenceConfirmation confirmation = new LicenceConfirmation();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LicenseType licenseType;

            if (chkClientButton.Checked)
            {
                licenseType = LicenseType.Single;
                txtLisansCount.Enabled = false;
            }
            else
            {
                licenseType = LicenseType.Server;
                txtLisansCount.Enabled = true;
            }
            List<int> modules = new List<int>();

            for (int i = 0; i < checkedListBoxControl1.Items.Count; i++)
            {

                if (checkedListBoxControl1.Items[i].CheckState == CheckState.Checked)
                {

                    modules.Add(i);
                }

            }
            License license = confirmation.LisenceCreat(licenseType, txtUserName.Text, txtCompany.Text, (OnlineLicenseControl)comboBoxEdit1.SelectedIndex, modules, (int)txtLisansCount.Value);
            confirmation.LicenseFileCreat(license);
            APIResponseResult result = confirmation.LicenseAdd(license);
            lblSonuc.Text = result.value.ToString();
        }


    }
}

