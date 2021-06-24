using Newtonsoft.Json.Converters;

namespace ApiEstudo.Framework.Converters
{
    public class OnlyDateConverter : IsoDateTimeConverter
    {
        public OnlyDateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
