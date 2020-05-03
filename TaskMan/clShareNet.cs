using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.IO;

using System.Text;
using System.Windows;

class clShareNet
{
    public static void ShareFolder(string FolderPath, string ShareName, string Description)
    {
        try
        {
            ManagementClass managementClass = new ManagementClass("Win32_Share");
            ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
            ManagementBaseObject outParams;

            inParams["Description"] = Description;
            inParams["Name"] = ShareName;
            inParams["Path"] = FolderPath;
            inParams["Type"] = 0x0;

            outParams = managementClass.InvokeMethod("Create", inParams, null);

            if ((uint)(outParams.Properties["ReturnValue"].Value)!=0)
            {
                throw new Exception("Unable to share directory.");
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "error!");
        }
    }
}

