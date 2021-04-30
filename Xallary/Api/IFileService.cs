using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Xallary.Api
{
    public interface IFileService
    {
        void SavePicture(string name, byte[] photoData);
        List<string> GetPicturePaths();
    }
}
