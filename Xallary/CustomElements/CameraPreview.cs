using System;
using System.Collections.Generic;
using System.Text;
using Xallary.Api;
using Xamarin.Forms;

namespace Xallary.CustomElements
{
    /// <summary>
    /// Custom camera preview.
    /// </summary>
    public class CameraPreview : View
    {
        public static readonly BindableProperty CameraProperty = BindableProperty.Create(
        propertyName: "Camera",
        returnType: typeof(CameraOptions),
        declaringType: typeof(CameraPreview),
        defaultValue: CameraOptions.Rear);

        public CameraOptions Camera
        {
            get { return (CameraOptions)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }
    }
}
