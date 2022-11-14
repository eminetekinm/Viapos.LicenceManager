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

namespace Viapos.LicenceManager.LicenceCreater
{
    public partial class Form1 : XtraForm
    {
        LicenceInformations.Tables.License lisans = new LicenceInformations.Tables.License();

        public Form1()
        {
            InitializeComponent();
        }


        private void chkClientButton_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClientButton.Checked)
            {
                lisans.LicenseType = LicenseType.Single;
                txtLisansCount.Enabled = false;
            }
            else
            {
                lisans.LicenseType = LicenseType.Server;
                txtLisansCount.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            LicenceInformations.Maneger.SystemInformations info = new LicenceInformations.Maneger.SystemInformations();
            DiskDrive drive = info.GetDiskList().FirstOrDefault(
                c => c.PartitionName == Application.StartupPath.Substring(0, 3));

            lisans.Id = Guid.NewGuid();
            lisans.UserName = txtUserName.Text;
            lisans.Company = txtCompany.Text;
            if (chkClientButton.Checked)
            {
                lisans.LicenseCount = 1;
            }
            else
            {
                lisans.LicenseCount = Convert.ToInt32(txtLisansCount.Value);
            }

            for (int i = 0; i < checkedListBoxControl1.Items.Count; i++)
            {

                if (checkedListBoxControl1.Items[i].CheckState == CheckState.Checked)
                {

                    lisans.Modules.Add(new Module
                    {
                        ModuleTypeEnum = (ModuleTypeEnum)i
                    });
                }

            }

            lisans.SystemInfos.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.BaseBoard,
                Info = JsonConvert.SerializeObject(info.GetBaseBoardInfo())
            });

            lisans.SystemInfos.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.Bios,
                Info = JsonConvert.SerializeObject(info.GetBiosInfo())
            });

            lisans.SystemInfos.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.Cpu,
                Info = JsonConvert.SerializeObject(info.GetCpuInfo())
            });
            lisans.SystemInfos.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.Network,
                Info = JsonConvert.SerializeObject(info.GetNetworkList().FirstOrDefault())
            });

            lisans.SystemInfos.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.DiskDrive,
                Info = JsonConvert.SerializeObject(drive)
            });
            lisans.SystemInfos.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.OSystem,
                Info = JsonConvert.SerializeObject(info.GetOSystemInfo())
            });
            var json = JsonConvert.SerializeObject(lisans);
            XtraSaveFileDialog dialog = new XtraSaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, EncrpytionTools.Encyrpt(json));
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LicenceConfirmation confirmation = new LicenceConfirmation();
           var item= confirmation.GetOnlineLicense(Guid.Parse("b06b90cd-e155-45f6-9ec0-294572ed79db"));

            MessageBox.Show(item);
        }
    }
}

