using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

public class HWIDGenerator
{
    public string GetHWID()
    {
        string processorId = GetProcessorId();
        string baseboardId = GetBaseboardId();
        string combinedId = processorId + baseboardId;

        string hwid = ComputeHash(combinedId);
        return hwid;
    }

    private string GetProcessorId()
    {
        string processorId = string.Empty;
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor"))
        {
            ManagementObjectCollection collection = searcher.Get();
            foreach (ManagementObject obj in collection)
            {
                processorId = obj["ProcessorId"].ToString();
                break;
            }
        }

        return processorId;
    }

    private string GetBaseboardId()
    {
        string baseboardId = string.Empty;
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard"))
        {
            ManagementObjectCollection collection = searcher.Get();
            foreach (ManagementObject obj in collection)
            {
                baseboardId = obj["SerialNumber"].ToString();
                break;
            }
        }

        return baseboardId;
    }

    private string ComputeHash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
