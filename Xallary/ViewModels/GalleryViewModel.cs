using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xallary.Api;
using Xamarin.Forms;

namespace Xallary.ViewModels
{
    public class GalleryViewModel : BaseViewModel
    {
        private List<ImageSource> source;

        public List<ImageSource> Source { get => this.source; set => this.SetProperty(ref this.source, value); }

        /// <summary>
        /// Constructor
        /// </summary>
        public GalleryViewModel()
        {
            
            this.StringsToItemSource(DependencyService.Get<IFileService>().GetPicturePaths());

        }

        private void StringsToItemSource(List<string> paths)
        {
            if (paths.Any())
            {
                foreach (var path in paths)
                {
                    ImageSource tmpSource = null;
                    if (File.Exists(path))
                    {
                        tmpSource = ImageSource.FromFile(path);
                    }


                    if (tmpSource != null)
                    {
                        this.source.Add(tmpSource);
                    }
                }
            }
        }
    }
}
