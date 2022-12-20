
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Viapos.LicenceManager.LicenceInformations.Enum;
using Viapos.LicenceManager.LicenceInformations.Tables;
using Viapos.LicenceManager.LicenceInformations.Tools;

namespace Viapos.LicenceManager.LicenceInformations.Maneger
{
    public class LicenceConfirmation
    {
        private readonly Tables.License license;
        List<SystemInfo> systemInfo = new List<SystemInfo>();
        public readonly bool confirmLicense = false;
        public readonly bool LicenseFileExist = false;
        public LicenceConfirmation()
        {
            if (File.Exists(Application.StartupPath + "\\license.lic"))
            {
                LicenseFileExist = true;
                string json = EncrpytionTools.Decyrpt(File.ReadAllText(Application.StartupPath + "\\license.lic"));
                license = JsonConvert.DeserializeObject<Tables.License>(json);
                LoadSystemInfo();
                int onlineConfirmedInfo = 0;
                bool onlineLicenseError = false;
                if (license.OnlineLicense != OnlineLicenseControl.None)
                {
                    try
                    {
                        APIResponseResult result = GetOnlineLicense(license.Id);

                        if (result.ReturnType == ReturnType.Confirm)
                        {

                            License onlineLicense = JsonConvert.DeserializeObject<License>(result.value.ToString());

                            for (int i = 0; i < 6; i++)
                            {
                                var infoType = license.SystemInfos.ToList()[i].InfoType;

                                if (onlineLicense.SystemInfos.ToList()[i].Info == systemInfo.Where(c => c.InfoType == infoType).FirstOrDefault().Info)
                                {
                                    onlineConfirmedInfo += 1;
                                }
                            }
                        }

                    }

                    catch (Exception)
                    {

                        onlineLicenseError = true;

                    }


                }


                int confirmedInfo = 0;
                for (int i = 0; i < 6; i++)
                {
                    var infoType = license.SystemInfos.ToList()[i].InfoType;

                    if (license.SystemInfos.ToList()[i].Info == systemInfo.Where(c => c.InfoType == infoType).FirstOrDefault().Info)
                    {
                        confirmedInfo += 1;
                    }
                }
                if (confirmedInfo > 3)
                {
                    if (license.OnlineLicense == OnlineLicenseControl.Required && onlineLicenseError)
                    {
                        confirmLicense = false;
                        return;

                    }
                    if (license.OnlineLicense == OnlineLicenseControl.Optional && onlineLicenseError)
                    {
                        confirmLicense = true;
                        return;
                    }
                    if (license.OnlineLicense != OnlineLicenseControl.None && !onlineLicenseError)
                    {
                        if (onlineConfirmedInfo > 3)
                        {
                            confirmLicense = true;
                        }
                        else
                        {
                            confirmLicense = false;
                            return;
                        }

                    }


                    confirmLicense = true;


                }
            }
            else
            {
                LicenseFileExist = false;
            }

        }

        private void LoadSystemInfo()
        {
            LicenceInformations.Maneger.SystemInformations info = new LicenceInformations.Maneger.SystemInformations();
            DiskDrive drive = info.GetDiskList().FirstOrDefault(
                c => c.PartitionName == Application.StartupPath.Substring(0, 3));

            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.BaseBoard,
                Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(info.GetBaseBoardInfo()))
            });

            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.Bios,
                Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(info.GetBiosInfo()))
            });

            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.Cpu,
                Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(info.GetCpuInfo()))
            });
            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.Network,
                Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(info.GetNetworkList().FirstOrDefault()))
            });

            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.DiskDrive,
                Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(drive))
            });
            systemInfo.Add(new SystemInfo
            {
                InfoType = SystemInfoEnum.OSystem,
                Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(info.GetOSystemInfo()))
            });

        }
        public bool ModuleConfirm(ModuleTypeEnum module)
        {
            if (!confirmLicense || license == null)
            {
                return false;
            }
            return license.Modules.Any(c => c.ModuleTypeEnum == module);
        }
        public LicenseInfo GetLicenseInfo()
        {
            return new LicenseInfo
            {
                UserName = license.UserName,
                Company = license.Company,
                LicenseCount = license.LicenseCount

            };
        }
        public int LicenseCount()
        {
            return license.LicenseCount;
        }
        public APIResponseResult GetOnlineLicense(Guid id)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:5051");
                RestRequest request = new RestRequest("api/license/getlisence");
                request.AddParameter("id", id);

                var response = client.Get(request);

                var result = JsonConvert.DeserializeObject<APIResponseResult>(EncrpytionTools.Decyrpt(response.Content.Trim('\"')));

                return result;

            }
            catch (Exception e)
            {

                APIResponseResult result = new APIResponseResult
                {
                    ReturnType = ReturnType.Error,
                    value = "Bağlantı Hatası"
                };

            }

        }

    }
    public APIResponseResult LicenseAdd(License license)
    {
        var json = JsonConvert.SerializeObject(license);
        RestClient client = new RestClient("http://localhost:5051");
        RestRequest request = new RestRequest("api/license/licenseAdd");
        request.AddParameter("userLicense", EncrpytionTools.Encyrpt(json), ParameterType.HttpHeader);
        var response = client.Post(request);
        var content = response.Content.Trim('\"');
        var result = JsonConvert.DeserializeObject<APIResponseResult>(EncrpytionTools.Decyrpt(content));
        return result;
    }
    public APIResponseResult DemoLicenseCheck(License license)
    {
        var json = JsonConvert.SerializeObject(license);
        RestClient client = new RestClient("http://localhost:5051");
        RestRequest request = new RestRequest("api/license/demoLicense");
        request.AddParameter("userLicense", EncrpytionTools.Encyrpt(json), ParameterType.HttpHeader);
        var response = client.Post(request);
        var content = response.Content.Trim('\"');
        var result = JsonConvert.DeserializeObject<APIResponseResult>(EncrpytionTools.Decyrpt(content));
        return result;
    }
    public License LisenceCreat(LicenseType licenseType, string userName, string company, OnlineLicenseControl onlineLicense, List<int> modules, int licenseCount = 1)
    {
        License lisans = new License();
        LicenceInformations.Maneger.SystemInformations info = new LicenceInformations.Maneger.SystemInformations();
        DiskDrive drive = info.GetDiskList().FirstOrDefault(
            c => c.PartitionName == Application.StartupPath.Substring(0, 3));

        lisans.Id = Guid.NewGuid();
        lisans.UserName = userName;
        lisans.Company = company;
        lisans.OnlineLicense = onlineLicense;
        lisans.LicenseCount = licenseCount;
        lisans.CreatedTime = DateTime.Now;

        for (int i = 0; i < modules.Count; i++)
        {
            lisans.Modules.Add(new Module
            {
                ModuleTypeEnum = (ModuleTypeEnum)i,
                LicenseId = lisans.Id,
                Id = Guid.NewGuid()
            }); ;
        }

        lisans.SystemInfos.Add(new SystemInfo
        {
            Id = Guid.NewGuid(),
            LicenseId = lisans.Id,
            InfoType = SystemInfoEnum.BaseBoard,
            Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(info.GetBaseBoardInfo()))

        });

        lisans.SystemInfos.Add(new SystemInfo
        {
            InfoType = SystemInfoEnum.Bios,
            Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(info.GetBiosInfo()))
        });

        lisans.SystemInfos.Add(new SystemInfo
        {
            InfoType = SystemInfoEnum.Cpu,
            Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(info.GetCpuInfo()))
        });
        lisans.SystemInfos.Add(new SystemInfo
        {
            InfoType = SystemInfoEnum.Network,
            Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(info.GetNetworkList().FirstOrDefault()))
        });

        lisans.SystemInfos.Add(new SystemInfo
        {
            InfoType = SystemInfoEnum.DiskDrive,
            Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(drive))
        });
        lisans.SystemInfos.Add(new SystemInfo
        {
            InfoType = SystemInfoEnum.OSystem,
            Info = Md5Hash.HashMd5(JsonConvert.SerializeObject(info.GetOSystemInfo()))
        });

        return lisans;
    }

    public void LicenseFileCreat(License license)
    {
        var json = JsonConvert.SerializeObject(license);
        XtraSaveFileDialog dialog = new XtraSaveFileDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(dialog.FileName, EncrpytionTools.Encyrpt(json));
        }
    }

}
}
