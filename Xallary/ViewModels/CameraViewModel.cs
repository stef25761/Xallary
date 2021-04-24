using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xallary.ViewModels
{
    public class CameraViewModel : BaseViewModel
    {
        private bool showPhoto;
        private string photoPath;

        public CameraViewModel()
        {
            PickPhotoCommand = new Command(this.DoPickPhoto);
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

                await LoadPhotoAsync(photo);

                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        public ICommand PickPhotoCommand { get; }
        public ICommand CapturePhotoCommand { get; }

        public bool ShowPhoto { get => this.showPhoto; set => this.SetProperty(ref this.showPhoto, value); }
        public string PhotoPath { get => this.photoPath; set => this.SetProperty(ref this.photoPath, value); }

        /// <summary>
        /// Pick photo command.
        /// </summary>
        async private void DoPickPhoto()
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
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }

            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
            {
                await stream.CopyToAsync(newStream);
            }

            PhotoPath = newFile;
            ShowPhoto = true;
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
