using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xavier.Integration.Tests.Common;

namespace Xavier.Integration.Tests.Helpers
{
    class EdocSessionIdHelper
    {
        public static string GetSession(string jsonRequestString, string requiredKey, string requestUrl)
        {
            /// <example>
            ///string response = "{\"d\":" 
            ///      "{\"__type\":\"eDocEngine.sessionInfo:#eDocClient\"," +
            ///      "\"dataMap\":null,\"defaultPalette\":null," +
            ///      "\"docName\":\"IW-SR-Interactive-FreeBoxes\"," +
            ///      "\"docSession\":\"922c31ae-843f-4577-8852-d6d91b77276d\"," +
            ///      "\"fotoliaAPIkey\":\"\"," +
            ///      "\"fotoliaEnabled\":false,\"" +
            ///      "fotoliaTabText\":\"\"," +
            ///      "\"isUnBranded\":false," +
            ///      "\"numPages\":1," +
            ///      "\"pages\":" +
            ///            "[{\"__type\":\"eDocEngine.pageInfo:#eDocClient\"," +
            ///            "\"allowBlankBackground\":true," +
            ///            "\"allowColorBackground\":true," +
            ///            "\"allowNewFields\":true," +
            ///            "\"backgroundOptions\":[]," +
            ///            "\"pageBleed\":0," +
            ///            "\"pageHeight\":144," +
            ///            "\"pageNumber\":1," +
            ///            "\"pageSafeZone\":0," +
            ///            "\"pageWidth\":252}" +
            ///            "]," +
            ///      "\"templateLockDown\":" +
            ///            "{\"__type\":\"eDocEngine.TemplateLockDown:#eDocClient\"," +
            ///            "\"canAddImages\":true," +
            ///            "\"canAddText\":true," +
            ///            "\"canUseFormsFrontend\":false," +
            ///            "\"canUseRIAFrontend\":true" +
            ///            "}" +
            ///       "}" +
            ///  "}";
            /// </example>
            
            HttpClient client = new HttpClient(requestUrl);
            var startSessionResponse = JObject.Parse(client.Post(jsonRequestString).ResponseBody);
            string sessionId = null;
            sessionId = startSessionResponse["d"]["docSession"].Value<string>();
            //TODO
            //foreach (KeyValuePair<string, JToken> keyValuePair in startSessionResponse)
            //{
            //    if (keyValuePair.Value != null || keyValuePair.Key == requiredKey)
            //    {
            //        //sessionId = startSessionResponse["d"]["docSession"].Value<string>();
            //        //sessionId = keyValuePair.Value.ToString();
            //    }
            //}
            return sessionId;
        }

        //TODO
        public void GettinCurrentSession(string sessionCode, HttpClient currentClient)
        {

        }

        //TODO
        public bool IsCurrentSessionSet(string sessionId)
        {
            var updateCurrentSessionUrl = "https://edocclient.inwk.com/services/eDocEngine.svc/updateCurrentSession";//ConfigurationManager.AppSettings["updateCurrentSession"];
            //post update current sesstion
            //https://edocclient.inwk.com/services/eDocEngine.svc/updateCurrentSession
            //resp: {"d":1} 200 OK
            //{"sessionCode":"f57d83da-2950-43ca-bc3e-d21d47da5ee2","userEntries":[{"elementName":"__background1__","elementValue":"IWBC-BACKER - INTERACTIVE(NOFORMATTING).PDF;1","elementPrompt":"__background1__","elementReposition":"","imageData":"","fontOpacity":100,"textStyle":{"fontName":null,"fontSize":0,"fontColor":null,"fontBold":false,"fontItalic":false,"fontUnderline":false,"fontLeading":0,"fontAlignment":0,"fontTracking":100,"fieldPositionRect":"0 0 252.00 144.00","fieldZOrder":0,"fieldPageNumber":1,"fieldControlType":"advancedImageUpload","fieldRotation":0,"cropParms":null,"imageBorder":false,"imageBorderWidth":0,"imageBorderColor":"#ffffff","opacity":100,"fotoliaID":0}},{"elementName":"areaName","elementValue":"John Smith","elementPrompt":"Full Name and Title","elementReposition":"","imageData":"","fontOpacity":100,"textStyle":{"fontName":"EinsteinsTradeGothicBoldCondensed","fontSize":11,"fontColor":"#000000","fontBold":false,"fontItalic":false,"fontUnderline":false,"fontLeading":0,"fontAlignment":8,"fontTracking":0,"fieldPositionRect":"17.28 13.176 143.28 47.808","fieldZOrder":1,"fieldPageNumber":1,"fieldControlType":"TextArea","fieldRotation":0,"cropParms":null,"imageBorder":false,"imageBorderWidth":0,"imageBorderColor":"#ffffff","opacity":100,"fotoliaID":0}},{"elementName":"areaAddress","elementValue":"600 West Chicago Avenue","elementPrompt":"Enter Information","elementReposition":"","imageData":"","fontOpacity":100,"textStyle":{"fontName":"EinsteinsTradeGothicBoldCondensed","fontSize":8,"fontColor":"#000000","fontBold":false,"fontItalic":false,"fontUnderline":false,"fontLeading":0,"fontAlignment":3,"fontTracking":0,"fieldPositionRect":"149.76 94.392 238.536 130.464","fieldZOrder":2,"fieldPageNumber":1,"fieldControlType":"TextArea","fieldRotation":0,"cropParms":null,"imageBorder":false,"imageBorderWidth":0,"imageBorderColor":"#ffffff","opacity":100,"fotoliaID":0}},{"elementName":"areaPhone","elementValue":"Main: 312-642-3700","elementPrompt":"Phone","elementReposition":"","imageData":"","fontOpacity":100,"textStyle":{"fontName":"EinsteinsTradeGothicBoldCondensed","fontSize":8,"fontColor":"#000000","fontBold":false,"fontItalic":false,"fontUnderline":false,"fontLeading":0,"fontAlignment":3,"fontTracking":0,"fieldPositionRect":"157.896 32.472 238.536 82.008","fieldZOrder":3,"fieldPageNumber":1,"fieldControlType":"TextArea","fieldRotation":0,"cropParms":null,"imageBorder":false,"imageBorderWidth":0,"imageBorderColor":"#ffffff","opacity":100,"fotoliaID":0}},{"elementName":"email","elementValue":"jsmith@inwk.com","elementPrompt":"E-mail","elementReposition":"","imageData":"","fontOpacity":100,"textStyle":{"fontName":"EinsteinsTradeGothicBoldCondensed","fontSize":8,"fontColor":"#000000","fontBold":false,"fontItalic":false,"fontUnderline":false,"fontLeading":0,"fontAlignment":3,"fontTracking":0,"fieldPositionRect":"149.76 21.96 238.536 30.24","fieldZOrder":4,"fieldPageNumber":1,"fieldControlType":"TextBox","fieldRotation":0,"cropParms":null,"imageBorder":false,"imageBorderWidth":0,"imageBorderColor":"#ffffff","opacity":100,"fotoliaID":0}},{"elementName":"web","elementValue":"www.inwk.com","elementPrompt":"Website","elementReposition":"","imageData":"","fontOpacity":100,"textStyle":{"fontName":"EinsteinsTradeGothicBoldCondensed","fontSize":8,"fontColor":"#0078B0","fontBold":false,"fontItalic":false,"fontUnderline":false,"fontLeading":0,"fontAlignment":3,"fontTracking":0,"fieldPositionRect":"149.76 13.176 238.536 21.456","fieldZOrder":5,"fieldPageNumber":1,"fieldControlType":"TextBox","fieldRotation":0,"cropParms":null,"imageBorder":false,"imageBorderWidth":0,"imageBorderColor":"#ffffff","opacity":100,"fotoliaID":0}}]}
            
            return false;
        }

        //TODO checkout
        public static string GetDocCode(string jsonRequestString, string requiredKey, string requestUrl)
        {
            HttpClient client = new HttpClient(requestUrl);
            var startSessionResponse = JObject.Parse(client.Post(jsonRequestString).ResponseBody);
            string docPwd = null;
            var json = JObject.Parse(jsonRequestString);
            return docPwd = json["docPwd"].Value<string>();
        }
    }

}
