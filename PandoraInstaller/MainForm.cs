using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Threading;

namespace PandoraInstaller
{
    public partial class MainForm : Form
    {
        CultureInfo CustomCulture;
        private List<string> DriveLetters = new List<string>();
        private List<bool> DriveIsValid = new List<bool>();
        private List<FirmwareImage> FirmwareImages = new List<FirmwareImage>();
        private bool ValidImage = false, ValidDrive = false;

        public MainForm()
        {
            CustomCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            CustomCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = CustomCulture;

            InitializeComponent();
            AddImages();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshImages();
            RefreshDrives();
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            if (versionCbox.Items.Count == 0)
                return;
            if (string.IsNullOrWhiteSpace((string)versionCbox.SelectedItem))
                return;
            if (driveCbox.SelectedIndex > DriveLetters.Count)
            {
                AddImages();
                return;
            }
            if (FirmwareImages[versionCbox.SelectedIndex].Data.Length == 0)
                return;

            FirmwareImage image = FirmwareImages[versionCbox.SelectedIndex];

            if (driveCbox.Items.Count == 0)
                return;
            if (string.IsNullOrWhiteSpace((string)driveCbox.SelectedItem))
                return;
            if (string.IsNullOrWhiteSpace(DriveLetters[driveCbox.SelectedIndex]))
                return;
            if (DriveLetters[driveCbox.SelectedIndex].Length != 1)
                return;
            if (driveCbox.SelectedIndex > DriveLetters.Count)
            {
                RefreshDrives();
                return;
            }

            char driveLetter = DriveLetters[driveCbox.SelectedIndex][0];
            string driveLabel = image.IsFactory ? "FACTORY" : "PANDORA";
            bool failure = false;

            mainPanel.Enabled = false;
            if (MessageBox.Show(this,
                string.Format("Do you really want to install {0} {1} to the following drive?\nAll data should be preserved, but this is still at your own risk!\n\n{2}",
                image.IsFactory ? "the factory firmware" : "Pandora",
                image.Version,
                (string)driveCbox.SelectedItem),
                "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                try
                {
                    DriveInfo drive = new DriveInfo(driveLetter.ToString());
                    if (!drive.IsReady)
                        throw new Exception();
                    if (drive.DriveType != DriveType.Removable)
                        throw new Exception();
                    if (!drive.DriveFormat.ToUpper().StartsWith("FAT"))
                        throw new Exception();
                    if (drive.AvailableFreeSpace < 100 * 1024 * 1024)
                        throw new Exception();

                    // Innner try to prevent process failure if changing the label fails
                    try
                    {
                        drive.VolumeLabel = driveLabel;
                    }
                    catch (Exception) { }
                }
                catch (Exception)
                {
                    RefreshDrives();
                    failure = true;
                }

                if (!failure)
                {
                    if (Utils.ExtractSFX(this, image.Data, driveLetter + ":\\"))
                    {
                        bool ejectionFailed = false;
                        try
                        {
                            if (!Utils.EjectDrive(driveLetter))
                                throw new Exception();
                        }
                        catch (Exception)
                        {
                            ejectionFailed = true;
                        }

                        infoLabel.Text = string.Format("{0} has been successfully installed to drive {1}:\\ {2}.\n" +
                            "Next, you should remove it from your computer and turn off your controller.\n" +
                        "Now, plug the USB stick into the turned-off controller and then apply power to it.\n" +
                        "You should now be guided through the automated installation process on the controller's screen.\n" +
                        "Please wait until the process completes and do not interrupt it by turning the controller off (e.g. power outtages) or by removing the USB stick.\n" +
                        "Once the installation finishes, you will be asked to remove the USB stick and the controller will boot into the CNC's main screen.\n" +
                        "Your installation is now complete. You may now remove the installation files from the USB stick, but this step is completely optional.\n\nHave fun!",
                            image.IsFactory ? "The factory firmware" : "Pandora",
                            driveLetter,
                            ejectionFailed ? "but you still have to manually eject the drive to continue" : "and the drive has been ejected");
                        driveBox.Visible = false;
                        versionBox.Visible = false;
                        this.Height -= driveBox.Height + 30;
                        installButton.Visible = false;
                        closeButton.Location = installButton.Location;
                        closeButton.Text = "Finish";
                        mainPanel.Enabled = true;
                        this.CancelButton = null;
                        this.AcceptButton = closeButton;
                        closeButton.Font = installButton.Font;
                        Utils.SwitchToThisWindow(this.Handle, true);
                        closeButton.Focus();
                        return;
                    }
                    else
                        failure = true;
                }

                if(failure)
                {
                    Utils.SwitchToThisWindow(this.Handle, true);
                    MessageBox.Show(this,
                        string.Format("{0} could not be installed to the selected drive!", image.IsFactory ? "The factory firmware" : "Pandora"),
                        "Installation failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Utils.SwitchToThisWindow(this.Handle, true);
                }
            }

            mainPanel.Enabled = true;
            this.Focus();
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            if (driveCbox.Items.Count == 0)
                return;
            if (string.IsNullOrWhiteSpace((string)driveCbox.SelectedItem))
                return;
            if (driveCbox.SelectedIndex > DriveLetters.Count)
            {
                RefreshDrives();
                return;
            }
            if (string.IsNullOrWhiteSpace(DriveLetters[driveCbox.SelectedIndex]))
                return;
            if (DriveLetters[driveCbox.SelectedIndex].Length != 1)
                return;

            char driveLetter = DriveLetters[driveCbox.SelectedIndex][0];

            mainPanel.Enabled = false;
            if (MessageBox.Show(this, string.Format("Do you really want to continue formatting the following drive?\nAll data on this drive will be destroyed!!!\n\n{0}",
                (string)driveCbox.SelectedItem),
                "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                if (Utils.FormatDrive(this, driveLetter, "UPDATE", "FAT32"))
                {
                    Utils.SwitchToThisWindow(this.Handle, true);
                    MessageBox.Show(this, "The drive was successfully formatted!", "Formatting completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Utils.SwitchToThisWindow(this.Handle, true);
                    MessageBox.Show(this, "The drive was not successfully formatted!", "Formatting failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Utils.SwitchToThisWindow(this.Handle, true);

                RefreshDrives();
            }

            mainPanel.Enabled = true;
            this.Focus();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshDrives();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoImage_Click(object sender, EventArgs e)
        {
            Process.Start("http://pandora-cnc.eu/");
        }

        private void forumImage_Click(object sender, EventArgs e)
        {
            Process.Start("http://madmodder.net/index.php?topic=11598.new;topicseen#new");
        }

        private void driveCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            formatButton.Enabled = !string.IsNullOrWhiteSpace((string)driveCbox.SelectedItem);
            ValidDrive = false;

            if (!string.IsNullOrWhiteSpace((string)driveCbox.SelectedItem))
            {
                if (DriveIsValid.Count > driveCbox.SelectedIndex && DriveLetters.Count > driveCbox.SelectedIndex)
                {
                    if (DriveIsValid[driveCbox.SelectedIndex])
                    {
                        DriveInfo di = new DriveInfo(DriveLetters[driveCbox.SelectedIndex]);
                        if (di.AvailableFreeSpace < 100 * 1024 * 1024)
                        {
                            Utils.SwitchToThisWindow(this.Handle, true);
                            MessageBox.Show(this,
                                string.Format("There is not enough space (~ 100 MB) left on drive {0}:\\ to install Pandora.\nYou can try formatting the drive to continue installing.",
                                DriveLetters[driveCbox.SelectedIndex]),
                                "Drive full!", MessageBoxButtons.OK);
                            Utils.SwitchToThisWindow(this.Handle, true);
                        }
                        else
                            ValidDrive = true;
                    }
                }
                else
                    RefreshDrives();
            }

            UpdateInstallButton();
        }

        private void versionCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidImage = false;

            if (versionCbox.Items.Count != 0)
            {
                if (!string.IsNullOrWhiteSpace((string)versionCbox.SelectedItem))
                {
                    if (driveCbox.SelectedIndex > DriveLetters.Count)
                        AddImages();
                    else if (FirmwareImages[versionCbox.SelectedIndex].Data.Length != 0)
                        ValidImage = true;
                }
            }

            UpdateInstallButton();
        }

        private void UpdateInstallButton()
        {
            installButton.Enabled = ValidDrive && ValidImage;
        }

        private void RefreshDrives()
        {
            DriveLetters.Clear();
            DriveIsValid.Clear();
            driveCbox.Items.Clear();
            formatButton.Enabled = false;
            string[] allDrives = Directory.GetLogicalDrives();

            DriveInfo di;
            foreach (string drive in allDrives)
            {
                if (string.IsNullOrWhiteSpace(drive))
                    continue;
                if (drive.Length < 1)
                    continue;

                string driveLetter = drive.Substring(0, 1).ToUpper();
                di = new DriveInfo(driveLetter);

                bool driveIsFat = false;
                bool driveIsReady = false;
                string fileSystem = "Unknown";
                string volumeLabel = "";
                float totalSize = 0;
                try
                {
                    if (di.DriveFormat.ToUpper().StartsWith("FAT"))
                        driveIsFat = true;
                    driveIsReady = di.IsReady;
                    fileSystem = di.DriveFormat;
                    volumeLabel = di.VolumeLabel;
                    totalSize = (float)Math.Round((float)di.TotalSize / 1024 / 1024 / 1024, 2);
                }
                catch (Exception) { }

                if (di.DriveType == DriveType.Removable)
                {
                    DriveLetters.Add(driveLetter);
                    DriveIsValid.Add(driveIsFat && driveIsReady);
                    driveCbox.Items.Add(string.Format("{0}:\\ ({1}{2}{3},{4} {5} GB)", driveLetter, string.IsNullOrWhiteSpace(volumeLabel) ? "" : "\'" + volumeLabel + "\', ",
                        fileSystem, !driveIsFat ? "!!!" : "", !driveIsReady ? " Not ready," : "", totalSize));
                }
            }

            if (driveCbox.Items.Count > 0)
                driveCbox.SelectedIndex = 0;
        }

        private void RefreshImages()
        {
            // Clear the combobox
            versionCbox.Items.Clear();

            // Now add the images to the combobox
            foreach (FirmwareImage image in FirmwareImages)
                versionCbox.Items.Add(string.Format("{0} {1} ({2})", image.IsFactory ? "Factory" : "Pandora", image.Version, image.Remarks));

            // Then, select the first entry
            if(versionCbox.Items.Count > 0)
                versionCbox.SelectedIndex = 0;
        }

        private void AddImages()
        {
            // Clear the previous images
            FirmwareImages.Clear();

            // Add the new images

            // Factory:
            // 06/03/2020 [112] (Latest)
            FirmwareImages.Add(new FirmwareImage(true, "06/03/2020 [r112]", "Latest, Recommended for DDCSV1.1/2.1/3.1", Properties.Resources.DDCSVx1_20200306112));
            // 30/07/2018 [98]
            FirmwareImages.Add(new FirmwareImage(true, "30/07/2018 [r98]", "DDCSV1.1 and DDCSV2.1", Properties.Resources.DDCSV11_RMHV21_2018073098));
            // 11/08/2017 [89]
            FirmwareImages.Add(new FirmwareImage(true, "11/08/2017 [r89]", "DDCSV1.1 and probably DDCSV2.1 ", Properties.Resources.DDCSV11_2017081189));
            // 10/06/2016 [80]
            FirmwareImages.Add(new FirmwareImage(true, "10/06/2016 [r80]", "Proven for DDCSV1.1 - Not 2.1!", Properties.Resources.DDCSV11_2016061080));

            // Pandora:
            // 16/04/2017 (Recommended)
            FirmwareImages.Add(new FirmwareImage(false, "16/04/2017", "Most recommended", Properties.Resources.Pandora_20170416));
            // 26/08/2018 (Latest Beta)
            FirmwareImages.Add(new FirmwareImage(false, "26/08/2018", "Latest Beta!", Properties.Resources.Pandora_20180818));
        }
    }
}
