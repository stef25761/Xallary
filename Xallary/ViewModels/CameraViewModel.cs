using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xallary.Api;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xallary.ViewModels
{
    public class CameraViewModel : BaseViewModel
    {
        //AUFGABE START

        //AUFGABE ENDE


        public CameraViewModel()
        {
            PickPhotoCommand = new Command(this.PickPhotoAsync);
            CapturePhotoCommand = new Command(this.DoCapturePhoto, () => MediaPicker.IsCaptureSupported);
        }

        /// <summary>
        /// Capture photo command.
        /// </summary>
        async private void DoCapturePhoto()
        {

            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var ms = new MemoryStream())
                using (var newStream = File.OpenWrite(newFile))
                {

                    await stream.CopyToAsync(ms);

                    DependencyService.Resolve<IFileService>().SavePicture(photo.FileName, ms.ToArray());
                    

                }

                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }
        public ICommand PickPhotoCommand { get; }
        public ICommand CapturePhotoCommand { get; }

        //AUFGABE START

        //AUFGABE ENDE


        /// <summary>
        /// Pick photo command.
        /// </summary>
        /// 

        async private void PickPhotoAsync()
        {
            try
            {
                
                var photo = await MediaPicker.PickPhotoAsync();
                await this.LoadPhotoAsync(photo);
                Console.WriteLine($"PickPhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PickPhotoAsync THREW: {ex.Message}");
            }
        }
        
        async private Task LoadPhotoAsync(FileResult photo)
        {
            //AUFGABE START

            //AUFGABE ENDE
        }

        public override void OnDisappearing()
        {
            PhotoPath = null;


            base.OnDisappearing();
        }
        public override void OnAppearing()
        {
            base.OnAppearing();
            this.DoCapturePhoto();
        }
    }
}
