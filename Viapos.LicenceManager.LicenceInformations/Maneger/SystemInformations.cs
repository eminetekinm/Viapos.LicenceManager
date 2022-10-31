using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using Viapos.LicenceManager.LicenceInformations.Tables;

namespace Viapos.LicenceManager.LicenceInformations.Maneger
{
    public class SystemInformations
    {
        public List<Network> GetNetworkList()
        {
            List<Network> list = new List<Network>();
            foreach (var network in NetworkInterface.GetAllNetworkInterfaces().
                Where(c => c.OperationalStatus == OperationalStatus.Up
            && !String.IsNullOrEmpty(c.GetPhysicalAddress().ToString())))
            {
                list.Add(new Network
                {
                    Caption = network.Name,
                    Description = network.Description,
                    MacAddress = network.GetPhysicalAddress().ToString()
                });
            }
            return list;
        }
        public Bios GetBiosInfo()
        {
            ManagementObjectSearcher manegmet = new ManagementObjectSearcher(
                queryString: "Select SMBIOSBIOSVersion, Caption, Manufacturer, SerialNumber, ReleaseDate From Win32_BIOS ");
            ManagementObjectCollection collection = manegmet.Get();
            Bios bios = new Bios();
            foreach (var prop in collection)
            {
                bios.SMBIOSBIOSVersion = prop["SMBIOSBIOSVersion"].ToString();
                bios.Caption = prop["Caption"].ToString();
                bios.Manufacturer = prop["Manufacturer"].ToString();
                bios.SerialNumber = prop["SerialNumber"].ToString();
                bios.ReleaseDate = ManagementDateTimeConverter.ToDateTime(prop["ReleaseDate"].ToString());

            }
            return bios;
        }
        public BaseBoard GetBaseBoardInfo()
        {
            ManagementObjectSearcher manegmet = new ManagementObjectSearcher(
               queryString: "Select Name, Product, Manufacturer, SerialNumber From Win32_BaseBoard ");
            ManagementObjectCollection collection = manegmet.Get();
            BaseBoard baseBoard = new BaseBoard();
            foreach (var prop in collection)
            {
                baseBoard.Name = prop["Name"].ToString();
                baseBoard.Product = prop["Product"].ToString();
                baseBoard.Manufacturer = prop["Manufacturer"].ToString();
                baseBoard.SerialNumber = prop["SerialNumber"].ToString();
            }
            return baseBoard;
        }
        public Cpu GetCpuInfo()
        {
            ManagementObjectSearcher manegmet = new ManagementObjectSearcher(
               queryString: "Select Name, Caption, DeviceID, ProcessorId, NumberOfCores From Win32_Processor ");
            ManagementObjectCollection collection = manegmet.Get();
            Cpu cpu = new Cpu();
            foreach (var prop in collection)
            {
                cpu.Name = prop["Name"].ToString();
                cpu.Caption = prop["Caption"].ToString();
                cpu.DeviceID = prop["DeviceID"].ToString();
                cpu.ProcessorId = prop["ProcessorId"].ToString();
                cpu.NumberOfCores = prop["NumberOfCores"].ToString();
            }
            return cpu;
        }
        public OSystem GetOSystemInfo()
        {
            ManagementObjectSearcher manegmet = new ManagementObjectSearcher(
               queryString: "Select Name, Caption, SerialNumber, RegisteredUser From Win32_OperatingSystem ");
            ManagementObjectCollection collection = manegmet.Get();
            OSystem oSystem = new OSystem();
            foreach (var prop in collection)
            {
                oSystem.Name = prop["Name"].ToString();
                oSystem.Caption = prop["Caption"].ToString();
                oSystem.SerialNumber = prop["SerialNumber"].ToString();
                oSystem.RegisteredUser = prop["RegisteredUser"].ToString();
            }
            return oSystem;
        }
        public List<DiskDrive> GetDiskList()
        {
            List<DiskDrive> list = new List<DiskDrive>();

            ManagementObjectSearcher diskManegment = new ManagementObjectSearcher(
                queryString: "Select Name, Caption, DeviceID, SerialNumber, Model From Win32_DiskDrive ");

            foreach (ManagementObject drive in diskManegment.Get())
            {
                ManagementObjectSearcher partitionManagement = new ManagementObjectSearcher(
                    String.Format("associators of{{{0}}} where AssocClass=Win32_DiskDriveToDiskPartition", drive.Path.RelativePath));
                foreach (ManagementObject partition in partitionManagement.Get())
                {
                    ManagementObjectSearcher logicalManagementnew = new ManagementObjectSearcher(
                        String.Format("associators of{{{0}}} where AssocClass=Win32_LogicalDiskToPartition", partition.Path.RelativePath));
                    foreach (ManagementObject logicalDisk in logicalManagementnew.Get())
                    {
                        list.Add(new DiskDrive
                        {
                            Name = drive["Name"].ToString(),
                            SerialNumber = drive["SerialNumber"].ToString(),
                            Caption = drive["Caption"].ToString(),
                            DeviceID = drive["DeviceID"].ToString(),
                            Model = drive["Model"].ToString(),
                            FileSystem = logicalDisk["FileSystem"].ToString(),
                            MediaType = logicalDisk["MediaType"].ToString(),
                            PartitionName = logicalDisk["Name"].ToString(),
                            VolumeSerialNumber = logicalDisk["VolumeSerialNumber"].ToString(),

                        });
                    }
                }
            }

            return list;
        }
    }
}
