using System;
using Newtonsoft.Json;
using Xunit;
using gdp_agg;
using System.IO;
using Newtonsoft.Json.Linq;
namespace gdp.tests
{
    public class Class1
    {
        [Fact]
        public static void isPresent()
        {
            string path = @"../../../../data_datafile.csv";
            Assert.True(File.Exists(path));
        }
        [Fact]
        public static void testGDP()
        {
            Program.aggGDP();
            string path1 = @"../../../../test_expected-output.json";
            string path2 = @"../../../../dataOutput.json";


            /*            JToken xpctJSON = JToken.Parse(path1);
                        JToken actJSON = JToken.Parse(path2);*/


            JToken xpctJSON = JsonConvert.DeserializeObject<JToken>(File.ReadAllText(path1));
            JToken actJSON = JsonConvert.DeserializeObject<JToken>(File.ReadAllText(path2));
            bool res = JObject.DeepEquals(xpctJSON, actJSON);
            /*Assert.True(File.Exists(path1));*/
        }
       
    }
}
