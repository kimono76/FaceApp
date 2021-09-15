using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaceApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerificationPage : ContentPage
    {
        public VerificationPage() {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e) {
            image1.Source = entryImage1.Text;
            image2.Source = entryImage2.Text;

            var faceClient = new FaceClient(new ApiKeyServiceClientCredentials(AppSettings.ApiKey));
            faceClient.Endpoint = AppSettings.Endpoint;

            IList<FaceAttributeType> attributes = new List<FaceAttributeType>();
            attributes.Add(FaceAttributeType.Age);
            attributes.Add(FaceAttributeType.Emotion);
            attributes.Add(FaceAttributeType.Hair);

            var resultImage1 = await faceClient.Face.DetectWithUrlAsync(
                entryImage1.Text,
                true,
                true,
                attributes);
            var resultImage2 = await faceClient.Face.DetectWithUrlAsync(
                entryImage2.Text,
                true,
                true,
                attributes);

            var verificationResult = await faceClient.Face.VerifyFaceToFaceAsync(
                resultImage1[0].FaceId.Value,
                resultImage2[0].FaceId.Value
                );
            labelResult.Text = verificationResult.Confidence.ToString();
        }
    }
}