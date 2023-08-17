



namespace DemoFilePicker
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {

            try
            {
                //Single file
                var response = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = " Please select an image",
                    FileTypes = FilePickerFileType.Images

                });
                if (response.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || response.FileName.EndsWith("jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    var imageEncodeStream = await FileSystem.OpenAppPackageFileAsync(response.FileName);


                    // var stream = await response.OpenReadAsync();
                    // ImageLabel.Source = ImageSource.FromStream(() => stream);
                    await Shell.Current.DisplayAlert("info", imageEncodeStream.ToString(), " Ok");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alert", " Invalid file selected", " Ok");
                }



                //mutiple files

                //foreach (var img in response)
                //{
                //    if (img.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || img.FileName.EndsWith("jpeg", StringComparison.OrdinalIgnoreCase))
                //    {
                //        var stream = await img.OpenReadAsync();
                //        ImageLabel.Source = ImageSource.FromStream(() => stream);
                //        await Shell.Current.DisplayAlert("info", img.FullPath, " Ok");
                //        await Task.Delay(2000);
                //    }
                //    else
                //    {
                //        await Shell.Current.DisplayAlert("Alert", " Invalid file selected", " Ok");
                //    }
                //}
            }
            catch (Exception) { }


        }
    }

}
