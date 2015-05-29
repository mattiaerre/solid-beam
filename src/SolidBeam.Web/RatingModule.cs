using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SolidBeam.Domain;
using SolidBeam.Domain.Manufacturers;
using SolidBeam.Domain.Types;
using System.Collections.Generic;
using System.Linq;

namespace SolidBeam.Web
{
    public class RatingModule : NancyModule
    {
        public RatingModule(IRatingModelFactory ratingModelFactory, IEnumerable<IType> types, IEnumerable<IManufacturer> manufacturers, IRatingEngine ratingEngine)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            Get["/"] = parameters => Response.AsRedirect("/Content/app/rating/rating.html");

            Get["/api/v0/rating/model"] = _ =>
            {
                var model = ratingModelFactory.Make();
                return JsonConvert.SerializeObject(model, Formatting.Indented, jsonSerializerSettings);
            };

            Post["/api/v0/rating/quote"] = _ =>
            {
                var data = this.Bind<PostedData>();
                var json = JObject.Parse(data.payload);

                var type = types.FirstOrDefault(e => e.GetType().Name == json["type"].Value<string>());
                var manufacturer = manufacturers.FirstOrDefault(e => e.GetType().Name == json["manufacturer"].Value<string>());

                var quote = ratingEngine.Quote(type, manufacturer);
                return JsonConvert.SerializeObject(new { quote }, Formatting.Indented, jsonSerializerSettings);
            };
        }
    }
}
