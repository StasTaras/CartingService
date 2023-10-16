namespace CartingService.Models.ResponseModels
{
    public class ResponseCartItemImage
    {
        public ResponseCartItemImage(
            string url,
            string altText)
        {
            Url = url;
            AltText = altText;
        }

        public string Url { get; set; }

        public string AltText { get; set; }
    }
}
