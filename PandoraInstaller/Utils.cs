using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace PandoraInstaller
{
    public class Utils
    {
        public static bool FormatDrive(Form mainForm, char driveLetter, string label = "", string fileSystem = "NTFS", bool quickFormat = true, bool enableCompression = false, int? clusterSize = null)
        {
            #region args check

            if (!Char.IsLetter(driveLetter) || fileSystem != "NTFS" && fileSystem != "FAT32")
            {
                return false;
            }

            #endregion
            bool success = false;
            string drive = driveLetter + ":";
            try
            {
                var psi = new ProcessStartInfo();
                psi.FileName = "format.com";
                psi.CreateNoWindow = false;
                psi.WorkingDirectory = Environment.SystemDirectory;
                psi.Arguments = "/FS:" + fileSystem +
                                             " /Y" +
                                             " /V:" + label +
                                             (quickFormat ? " /Q" : "") +
                                             ((fileSystem == "NTFS" && enableCompression) ? " /C" : "") +
                                             (clusterSize.HasValue ? " /A:" + clusterSize.Value : "") +
                                             " " + drive;
                psi.UseShellExecute = false;
                psi.Verb = "runas";
                //var formatProcess = Process.Start(psi);
                var formatProcess = ProcessStartWaitDisown(mainForm, psi);
                formatProcess.WaitForExit();
                success = formatProcess.ExitCode == 0;
            }
            catch (Exception) { return false; }
            return success;
        }

        public static bool ExtractSFX(Form MainForm, byte[] SFXData, string Target)
        {
            if (SFXData == null || string.IsNullOrWhiteSpace(Target))
                return false;

            bool success = false;
            try
            {
                // Write the SFX to some temp place
                var tmpf = Path.GetTempFileName();
                File.Delete(tmpf);
                tmpf += ".exe";
                File.WriteAllBytes(tmpf, SFXData);

                var psi = new ProcessStartInfo();
                psi.FileName = tmpf;
                psi.Arguments = "-o\"" + Target + "\" -y";
                psi.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                psi.UseShellExecute = true;
                //var extractProcess = Process.Start(psi);
                //extractProcess.WaitForExit();
                var extractProcess = ProcessStartWaitDisown(MainForm, psi);

                File.Delete(tmpf);

                success = extractProcess.ExitCode == 0;
            }
            catch (Exception) { return false; }

            return success;
        }

        private static Process ProcessStartWaitDisown(Form mform, ProcessStartInfo psi)
        {
            var windowField = typeof(Control).GetField("window", BindingFlags.Instance |
                                    BindingFlags.NonPublic);

            Form form = new Form();
            NativeWindow window = (NativeWindow)windowField.GetValue(form);
            var process = Process.Start(psi);
            process.EnableRaisingEvents = true;

            while (process.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(1);
            }

            window.AssignHandle(process.MainWindowHandle);
            Control.CheckForIllegalCrossThreadCalls = false;

            EventHandler handler = (s, ev) => form.DialogResult = DialogResult.OK;
            process.Exited += handler;
            form.ShowDialog(mform);
            process.Exited -= handler;
            Control.CheckForIllegalCrossThreadCalls = true;
            SwitchToThisWindow(mform.Handle, true);
            return process;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const int FILE_SHARE_READ = 0x1;
        const int FILE_SHARE_WRITE = 0x2;
        const int FSCTL_LOCK_VOLUME = 0x00090018;
        const int FSCTL_DISMOUNT_VOLUME = 0x00090020;
        const int IOCTL_STORAGE_EJECT_MEDIA = 0x2D4808;
        const int IOCTL_STORAGE_MEDIA_REMOVAL = 0x002D4804;

        public static bool EjectDrive(char driveLetter)
        {
            string path = @"\\.\" + driveLetter + @":";
            IntPtr handle = CreateFile(path, GENERIC_READ | GENERIC_WRITE,
            FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, 0x3, 0, IntPtr.Zero);

            if ((long)handle == -1)
                return false;

            int dummy = 0;

            DeviceIoControl(handle, IOCTL_STORAGE_EJECT_MEDIA, IntPtr.Zero, 0,
                IntPtr.Zero, 0, ref dummy, IntPtr.Zero);

            CloseHandle(handle);

            return true;
        }
        [DllImport("kernel32", SetLastError = true)]
        private static extern IntPtr CreateFile
            (string filename, uint desiredAccess,
                uint shareMode, IntPtr securityAttributes,
                int creationDisposition, int flagsAndAttributes,
                IntPtr templateFile);
        [DllImport("kernel32")]
        private static extern int DeviceIoControl
            (IntPtr deviceHandle, uint ioControlCode,
                IntPtr inBuffer, int inBufferSize,
                IntPtr outBuffer, int outBufferSize,
                ref int bytesReturned, IntPtr overlapped);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);
    }
}
