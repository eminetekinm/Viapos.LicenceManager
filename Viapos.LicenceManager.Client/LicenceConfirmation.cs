using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Viapos.LicenceManager.LicenceInformations.Enum;
using Viapos.LicenceManager.LicenceInformations.Tables;
using Viapos.LicenceManager.SystemInformations.Tables;
using Viapos.LicenceManager.SystemInformations.Tools;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace Viapos.LicenceManager.Client
{
    public class LicenceConfirmation
    {
        private readonly LicenceInformations.Tables.License license;
        List<SystemInfo> systemInfo = new List<SystemInfo>();
        private bool confirmLicense = false;
        public LicenceConfirmation()
        {
            if (File.Exists(Application.StartupPath + "\\license.lic"))
            {
                string json = EncrpytionTools.Decyrpt(File.ReadAllText(Application.StartupPath + "\\license.lic"));
                license = JsonConvert.DeserializeObject<LicenceInformations.Tables.License>(json);
                LoadSystemInfo();
                int confirmedInfo = 0;
                for (int i = 0; i < 6; i++)
                {
                    var infoType = license.SystemInfos[i].InfoType;

                    if (license.SystemInfos[i].Info == systemInfo.Where(c => c.InfoType == infoType).FirstOrDefault().Info)
                    {
                        confirmedInfo += 1;
                    }
                }
                if (confirmedInfo>3)
                {
                    confirmLicense = true;
                }
            }

        }

        private void LoadSystemInfo()
        {
            SystemInformations.Maneger.SystemInformations info = new SystemInformations.Maneger.SystemInformations();
            DiskDrive drive = info.GetDiskList().FirstOrDefault(
                c => c.PartitionName == Application.StartupPath.Substring(0, 3));

            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.BaseBoard,
                Info = JsonConvert.SerializeObject(info.GetBaseBoardInfo())
            });

            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.Bios,
                Info = JsonConvert.SerializeObject(info.GetBiosInfo())
            });

            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.Cpu,
                Info = JsonConvert.SerializeObject(info.GetCpuInfo())
            });
            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.Network,
                Info = JsonConvert.SerializeObject(info.GetNetworkList().FirstOrDefault())
            });

            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.DiskDrive,
                Info = JsonConvert.SerializeObject(drive)
            });
            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.OSystem,
                Info = JsonConvert.SerializeObject(info.GetOSystemInfo())
            });

        }
        public bool ModuleConfirm(ModuleTypeEnum module)
        {
            if (!confirmLicense || license==null)
            {
                return false;
            }
            return license.Modules.Any(c => c.ModuleTypeEnum == module);
        }
        public int LicenseCount()
        {
            return license.LicenseCount;
        }
    }
}
