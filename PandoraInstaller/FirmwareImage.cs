using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraInstaller
{
    public struct FirmwareImage
    {
        public bool IsFactory;
        public string Version;
        public string Remarks;
        public byte[] Data;

        public FirmwareImage(bool IsFactory, string Version, string Remarks, byte[] Data)
        {
            this.IsFactory = IsFactory;
            this.Version = Version;
            this.Remarks = Remarks;
            this.Data = Data;
        }
    }
}
