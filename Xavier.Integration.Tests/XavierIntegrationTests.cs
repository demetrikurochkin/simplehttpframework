using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Xavier.Integration.Tests.Common;
using Xavier.Integration.Tests.Helpers;

namespace Xavier.Integration.Tests
{
    [TestFixture]
    public class XavierIntegrationTests
    {
        [TestFixtureSetUp]
        public void TestInitialize()
        {
        }

        [Test]
        [Category("positive POST")]
        public void GetAndPurchaseVdpService()
        {
            var baseUrl = ConfigurationManager.AppSettings["baseUri"];
            var vdpUrlPath = ConfigurationManager.AppSettings["VdpPreviewResultUri"];

            const string vdpJsonRequestString = "{ \"previewRequest\": " +
                                                "{\"EntryID\":\"QA03VDP12312\"" +
                                                ",\"VariableData\":[" +
                                                "{\"Key\":\"Name\",\"Value\":\"asdf\"}," +
                                                "{\"Key\":\"City\",\"Value\":\"asdf\"}," +
                                                "{\"Key\":\"State\",\"Value\":\"asdf\"}," +
                                                "{\"Key\":\"Language\",\"Value\":\"English\"}" +
                                                "]" +
                                                "}" +
                                                "}";

            HttpClient pullVdpServiceClient = new HttpClient(UrlHelper.Combine(baseUrl, vdpUrlPath));

            string vdpServiceStringResponse = pullVdpServiceClient.Post(vdpJsonRequestString).ResponseBody;

            const string stringOfRequiredValues = "id, pages, resources, page, image";
            
            Assert.IsNotNull(JsonParserHelper.IsJsonResponseCorrect(stringOfRequiredValues, vdpServiceStringResponse).Item1,
                "Actual response keys are : {0}\n Response doesn't contains key: {1}\n",
                stringOfRequiredValues, JsonParserHelper.IsJsonResponseCorrect(stringOfRequiredValues,
                vdpServiceStringResponse).Item2);

        }

        [Test]
        [Category("negative POST")]
        [ExpectedException(typeof(WebException))]
        public void GetAndPurchaseVdpServiceAtNegative()
        {
            var baseUrl = ConfigurationManager.AppSettings["baseUri"];
            var vdpUrlPath = ConfigurationManager.AppSettings["VdpPreviewResultUri"];

            string invalidData = Regex.Replace(Guid.NewGuid().ToString(), @"[\d-]", string.Empty);

            string vdpJsonRequestString = "{ \"previewRequest\": " +
                                          "{\"EntryID\":\"QA03VDP12312\"" +
                                          ",\"VariableData\":[" +
                                          "{\"Key\":\"Name\",\"Value\":\"asdf\"}," +
                                          "{\"Key\":\"City\",\"Value\":\"asdf\"}," +
                                          "{\"Key\":\"State\",\"Value\":\"asdf\"}," +
                                          "{\"Key\":\"Language\",\"Value\":\"English\"}" +
                                          "]" +
                                          "}" +
                                          "}" + invalidData;
            
            try
            {
                HttpClient negativePullVdClient = new HttpClient(UrlHelper.Combine(baseUrl, vdpUrlPath));
                Assert.AreEqual(negativePullVdClient.Post(vdpJsonRequestString).StatusCode, HttpStatusCode.BadRequest);
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.GetType().FullName);
                Debug.WriteLine(ex.GetBaseException().ToString());
            }

            Assert.Pass();
        }

        [Test]
        [Category("positive GET")]
        public void SendRequestsToEdocClientService()
        {
            //ConfigurationManager.AppSettings["UploadImageUri"];
            var uploadImageUrl = "https://edocclient.inwk.com/WebCoreModule.ashx?__ac=1&amp;" +
                                 "__ac_wcmid=RAWCIL&amp;" +
                                 "__ac_lib=Radactive.WebControls.ILoad&amp;" +
                                 "__ac_key=RAWCCIL_2011&amp;__ac_sid=qfneonv0unkpkpmrbckp1fob&amp;" +
                                 "__ac_cn=&amp;__ac_ssid=&amp;" +
                                 "fr=Mon%20Sep%2015%202014%2012%3A18%3A30%20GMT%2B0400%20(Russian%20Standard%20Time)&amp;" +
                                 "ssidToClear=49b50de3-dd78-4b92-9660-017a9cc3b92c";
            //ConfigurationManager.AppSettings["UpdatePreviewUri"];
            var updatePreviewUrl = "https://edocclient.inwk.com/Telerik.RadUploadProgressHandler.ashx?" +
                                   "RadUrid=4028f4b9-ab72-45e4-af1d-48103778267c&amp;" +
                                   "RadUploadTimeStamp=1410769327956&amp;";
            //ConfigurationManager.AppSettings["ApproveAndCheckotUri"];
            var approveAndCheckoutUri = "https://edocclient.inwk.com/Telerik.RadUploadProgressHandler.ashx?" +
                                        "RadUrid=c4075a49-eb12-476f-b925-e44e9b18b7e3&amp;" +
                                        "RadUploadTimeStamp=1410769740340&amp;";
            //ConfigurationManager.AppSettings["GetPreviewUri"];
            var getPreviewUrl = "https://edocclient.inwk.com/services/eDocEngine.svc/getPreviews";
            //ConfigurationManager.AppSettings["FileDownloadUri"];
            var fileDownloadUrl = "https://edocengine.inwk.com/include/fileDownload.aspx" +
                                  "?p=rhV9ssFv00g5QT%2f4bJ3M3goXiggokx7AAMZaLzUii4%2bv0X6OaeILqrdwzEx3GA%2bY" +
                                  "&s=f004e581-ea24-4b2d-b560-b8a2c6e24135";
            //ConfigurationManager.AppSettings["StartEdocSessionUri"];
            var startSessionEdocUri = "https://edocclient.inwk.com/services/eDocEngine.svc/startSession";
            
            //
            //
            //
            //
            //
            //TODO USE EdocSessionIdHelper 
            //
            //
            //
            //
            //
            HttpClient startEdocSessionClient = new HttpClient(startSessionEdocUri);
            string startEdocSessionRequest = "{\"docCode\":\"bbd56ecd-decf-41f7-9582-01c0d70a8321\",\"docPwd\":\"9e867347-fd64-42a8-a151-b8122a8615c8\"}";
            var startSessionResponse = JObject.Parse(startEdocSessionClient.Post(startEdocSessionRequest).ResponseBody);
            var docSessionId = startSessionResponse["d"]["docSession"].Value<string>();
            //
            //
            //
            //

            HttpClient uploadImageClient = new HttpClient(uploadImageUrl);
            Assert.AreEqual(uploadImageClient.Get().StatusCode, HttpStatusCode.OK);

            HttpClient approveAndCheckoutClient = new HttpClient(approveAndCheckoutUri);
            Assert.AreEqual(approveAndCheckoutClient.Get().StatusCode, HttpStatusCode.OK);
            
            HttpClient getEdocPreviewClient = new HttpClient(getPreviewUrl);
            string getPreviewRequest = "{\"sessionCode\":\"" + docSessionId + 
                "\",\"pageNumbers\":[1],\"maxPixelSize\":1000,\"includeThumbs\":true}";
            Assert.AreEqual(getEdocPreviewClient.Post(getPreviewRequest).StatusCode, HttpStatusCode.OK);
            
            HttpClient fileDownloadEdocClient = new HttpClient(fileDownloadUrl);
            Assert.AreEqual(fileDownloadEdocClient.Get().StatusCode, HttpStatusCode.OK);
            
            HttpClient updatePreviewClient = new HttpClient(updatePreviewUrl);
            const string expectedValue = "var rawProgressData = {InProgress:false,ProgressCounters:false};";
            var updatePreviewGetRequest = updatePreviewClient.Get();
            Assert.AreEqual(expectedValue, updatePreviewGetRequest.ResponseBody);
            Assert.AreEqual(HttpStatusCode.OK, updatePreviewGetRequest.StatusCode);
        }

        [Test]
        [Category("positive GET")]
        public void PullAllShippingServices()
        {
            Queue<string> paymentMethods = new Queue<string>();
            paymentMethods.Enqueue("EPX");
            paymentMethods.Enqueue("GENERIC");
            paymentMethods.Enqueue("ICHARGEV5");

            Queue<string> postalProviders = new Queue<string>();
            postalProviders.Enqueue("UPS_GROUND");
            postalProviders.Enqueue("UPS_NEXT_DAY");
            postalProviders.Enqueue("FEDEX_GROUND");
            postalProviders.Enqueue("FEDEX_EXPRESS_SAVER");
            postalProviders.Enqueue("FEDEX_2_DAY");
            postalProviders.Enqueue("UPS_2_DAY_AIR");
            postalProviders.Enqueue("STANDARD_OVERNIGHT");
            postalProviders.Enqueue("UPS_NEXT_DAY_EARLY");

            string baseUrl = ConfigurationManager.AppSettings["baseUri"];

            const string getShippingValues = "Options, ShowEstimates, ShowShippings," +
                                                     " QuoteUnavailable, IsValid, Message";

            const string getTaxesValues =
                "LineItems, HasDiscount, HasTax, ShippingCode, DisplayShippingName, " +
                "DisplaySubTotal, ShippingDiscounts, ShippingTotal, DisplayShippingTotal, TaxTotal, DisplayTaxTotal, " +
                "DiscountTotal, DisplayDiscountTotal, Total, DisplayTotal, " +
                "CreditCardFeeTotal, DisplayCreditCardFeeTotal, HasMultipleShipping, " +
                "IsValid";

            const string isAllowedValues = "OperationAllowed, true, " +
                                           "DialogTitle, Warning, " +
                                           "DialogBody, Spend Limit Warning";

            //TODO parse App.config to insert provider/method variable
            foreach (var method in paymentMethods)
            {
                foreach (var provider in postalProviders)
                {
                    string path = "modules/inwkb2b/cart/ShippingChoices?code=" + provider + "&paymentType=" + method + "&_=1411123293738";

                    HttpClient getShippingChoices = new HttpClient(UrlHelper.Combine(baseUrl, path));

                    var methodResponse = getShippingChoices.Get().ResponseBody;

                    Assert.IsNotNull(JsonParserHelper.IsJsonResponseCorrect(getShippingValues,
                            methodResponse).Item1,
                            "Actual response keys are : {0}\n Response doesn't contains key: {1}\n",
                            getShippingValues, JsonParserHelper.IsJsonResponseCorrect(getShippingValues,
                            methodResponse).Item2);
                }
            }
            
            foreach (var method in paymentMethods)
            {
                string path = "modules/inwkb2b/cart/GetCart?calculateTaxes=true&paymentMethod=" + method + "&_=1411123293738";

                    HttpClient getShippingChoices = new HttpClient(UrlHelper.Combine(baseUrl, path));

                    var methodResponse = getShippingChoices.Get().ResponseBody;

                    Assert.IsNotNull(JsonParserHelper.IsJsonResponseCorrect(getTaxesValues,
                            methodResponse).Item1,
                            "Actual response keys are : {0}\n Response doesn't contains key: {1}\n",
                            getTaxesValues, JsonParserHelper.IsJsonResponseCorrect(getTaxesValues,
                            methodResponse).Item2);
            }

            foreach (var method in paymentMethods)
            {
                string path = "modules/INWKB2B/Contact/IsOperationAllowed/?total=81.1908&paymentMethod=" + method + "&_=1411123293738";

                HttpClient getShippingChoices = new HttpClient(UrlHelper.Combine(baseUrl, path));

                var methodResponse = getShippingChoices.Get().ResponseBody;

                Assert.IsNotNull(JsonParserHelper.IsJsonResponseCorrect(isAllowedValues,
                        methodResponse).Item1,
                        "Actual response keys are : {0}\n Response doesn't contains key: {1}\n",
                        isAllowedValues, JsonParserHelper.IsJsonResponseCorrect(isAllowedValues,
                        methodResponse).Item2);
            }
        }

        [Test]
        public void PullEdocClientServiceFor_BC_EDB_EN_US_Product()
        {
            //TODO create edocBaseUri in App.settings
            string bc_sessionIdKey = "docSession";
            string bc_docPwdKey = "";

            //ConfigurationManager.AppSettings["edocBaseUri"];
            string baseUrl = "https://innerworkingsqa.inwk.com";

            //TODO is product page available
            //ConfigurationManager.AppSettings["edocProductPath"];
            const string productDetailPageUrlPath =
                "/en-US/IW/Site-Settings/Start-Page/ProductDetails/" +
                "?p=IW-Business-Card-EDB.aspx&cat=CBC2222";
            //ConfigurationManager.AppSettings["StartEdocSessionUri"];
            const string startEdocSessionUrl = "https://edocclient.inwk.com/services/eDocEngine.svc/startSession";
            //ConfigurationManager.AppSettings["GetCurrentSessionUri"];
            const string getCurrentEdocSessionUrl = "https://edocclient.inwk.com/services/eDocEngine.svc/getCurrentSession";
            //ConfigurationManager.AppSettings["GetPreviewUri"];
            const string getEdocPreviewsUrl = "https://edocclient.inwk.com/services/eDocEngine.svc/getPreviews";
            //ConfigurationManager.AppSettings["PostRasterTextUri"];
            const string postRasterTextUrl = "https://edocclient.inwk.com/services/eDocEngine.svc/rasterText";
            //ConfigurationManager.AppSettings["PostRasterImageUri"];
            const string postRasterImageUrl = "https://edocclient.inwk.com/services/eDocEngine.svc/rasterImage";
            //ConfigurationManager.AppSettings["GetFontListNamesUri"];
            const string getFontListNamesUrl = "https://edocclient.inwk.com/services/eDocEngine.svc/getFontListNames";
            //ConfigurationManager.AppSettings["FinalApproveAndCheckoutUri"];
            const string finalApproveAndCheckoutUrl = "https://edocclient.inwk.com/html5finished.aspx?" +
                                                     "docCode=bbd56ecd-decf-41f7-9582-01c0d70a8321&docPwd=9e867347-fd64-42a8-a151-b8122a8615c8&" +
                                                     "addToCartButton=%20Approve/Checkout&cancelButton=Cancel&" +
                                                     "updateButton=%20Approve/Checkout&approveWhenDone=true&" +
                                                     "cssURL=https://innerworkingsqa.inwk.com/Templates/INWKB2B/Styles/eDocFormCustom.css&" +
                                                     "postbackURL=https://innerworkingsqa.inwk.com:443%2fen-US%2fIW%2fSite-Settings%2fStart-Page%2fProductDetails%2f%3fp%3dIW-Business-Card-EDB.aspx%26cat%3dCBC2222&isSubmitFromEdit=true&" +
                                                     "docSessionCancelled=false&docSession=bd6eaf03-0f56-4f85-8ed3-e268e391b936";


            const string bc_Edb_En_Us_EdocRequest = "{\"docCode\":\"bbd56ecd-decf-41f7-9582-01c0d70a8321\",\"docPwd\":\"9e867347-fd64-42a8-a151-b8122a8615c8\"}";
            
            //TODO debug
            string sessionId = EdocSessionIdHelper.GetSession(bc_Edb_En_Us_EdocRequest, bc_sessionIdKey,
                startEdocSessionUrl);

            //TODO create
            string docCode = EdocSessionIdHelper.GetDocCode(bc_Edb_En_Us_EdocRequest, bc_docPwdKey, startEdocSessionUrl);

            //TODO: create method parsing request string and inserting sessionId(to SessionIdHelper)
            string currentSessionRequest = "{\"sessionCode\":\"" +  sessionId  + "\"}";
            string getPreviewsRequest = "{\"sessionCode\":\"" + sessionId + "\",\"pageNumbers\":[1]," +
                                        "\"maxPixelSize\":1000,\"includeThumbs\":true}";
            string getRasterTextRequest = "{\"sessionCode\":\"" + sessionId + "\",\"dpi\":151," +
                                          "\"rect\":\"17.28 13.176 143.28 47.808\",\"textStr\":\"John Smith\"," +
                                          "\"fontName\":\"EinsteinsTradeGothicBoldCondensed\",\"fontSize\":11," +
                                          "\"fontColor\":\"#000000\",\"bold\":false,\"italic\":false," +
                                          "\"underline\":false,\"leading\":0,\"tracking\":0,\"opacity\":100," +
                                          "\"alignment\":8,\"rotation\":0,\"forcefit\":false}";
            string getRasterImageRequest = "{\"sessionCode\":\"" + sessionId + "\",\"imageName\":\"IWBC-BACKER - INTERACTIVE(NOFORMATTING).PDF;1\"," +
                                           "\"dpi\":151,\"rect\":\"0 0 252.00 144.00\",\"cropParms\":null," +
                                           "\"imageborder\":false,\"imageborderwidth\":0,\"imagebordercolor\":\"#ffffff\"," +
                                           "\"opacity\":100}";
            string getFontListNamesRequest = "{\"sessionCode\":\"" + sessionId + "\"}";
            
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(UrlHelper.Combine(baseUrl, productDetailPageUrlPath)));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(startEdocSessionUrl, bc_Edb_En_Us_EdocRequest));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(getCurrentEdocSessionUrl, currentSessionRequest));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(getEdocPreviewsUrl, getPreviewsRequest));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(postRasterImageUrl, getRasterImageRequest));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(postRasterTextUrl, getRasterTextRequest));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(getFontListNamesUrl, getFontListNamesRequest));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(finalApproveAndCheckoutUrl));
        }


        [Test]
        public void PullEdocClientServiceFor_eDoc_Is_Out_Of_Stock_Product()
        {
            string bc_sessionIdKey = "docSession";
            string bc_docPwdKey = "";
            string baseUrl = "https://innerworkingsqa.inwk.com";//ConfigurationManager.AppSettings["edocBaseUri"];

            //ConfigurationManager.AppSettings[""];
            const string productDetailPageUrlPath =
                "/en-US/IW/Site-Settings/Start-Page/ProductDetails/?p=eDoc-is-out-of-stock.aspx&cat=11-28-07-04-2014-mon";//ConfigurationManager.AppSettings["edocProductPath"];
            
            const string updatePreviewUrl = "https://edocclient.inwk.com/iframeClient.aspx?" +
                                            "docCode=93a779b5-77c6-4748-b53a-e9f0a79448f3&" +
                                            "docPwd=3076f683-12e7-484e-9d5a-d40a4da8f406&" +
                                            "addToCartButton=+Approve%2fCheckout" +
                                            "&cancelButton=Cancel&" +
                                            "updateButton=+Approve%2fCheckout&" +
                                            "approveWhenDone=true&" +
                                            "cssURL=https%3a%2f%2finnerworkingsqa.inwk.com%2fTemplates%2fINWKB2B%2fStyles%2feDocFormCustom.css&" +
                                            "docSession=2188872b-496a-4f38-b54b-13348e9fb188&" +
                                            "postbackURL=https%3a%2f%2finnerworkingsqa.inwk.com%3a443%2fen-US%2fIW%2fSite-Settings%2fStart-Page%2fProductDetails%2f%3fp%3deDoc-is-out-of-stock.aspx%26cat%3d11-28-07-04-2014-mon&" +
                                            "isSubmitFromEdit=true&" +
                                            "RadUrid=d28812ca-4654-47f0-9157-d386501005e2";

            const string approveAndCheckoutUrl = "https://edocclient.inwk.com/iframeClient.aspx?" +
                                                 "docCode=93a779b5-77c6-4748-b53a-e9f0a79448f3&" +
                                                 "docPwd=3076f683-12e7-484e-9d5a-d40a4da8f406&" +
                                                 "addToCartButton=+Approve%2fCheckout&" +
                                                 "cancelButton=Cancel&" +
                                                 "updateButton=+Approve%2fCheckout&approveWhenDone=true&" +
                                                 "cssURL=https%3a%2f%2finnerworkingsqa.inwk.com%2fTemplates%2fINWKB2B%2fStyles%2feDocFormCustom.css&" +
                                                 "docSession=2188872b-496a-4f38-b54b-13348e9fb188&" +
                                                 "postbackURL=https%3a%2f%2finnerworkingsqa.inwk.com%3a443%2fen-US%2fIW%2fSite-Settings%2fStart-Page%2fProductDetails%2f%3fp%3deDoc-is-out-of-stock.aspx%26cat%3d11-28-07-04-2014-mon&" +
                                                 "isSubmitFromEdit=true&" +
                                                 "RadUrid=efd84cb7-7ff3-42fd-8940-54254ff96f05";

            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(UrlHelper.Combine(baseUrl, productDetailPageUrlPath)), "Product page is not available");
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(updatePreviewUrl));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(approveAndCheckoutUrl));
        }

        [Test]
        public void PullEdocClientServiceFor_No_Weight_eDoc()
        {
            string no_weigth_sessionIdKey = "docSessionId";
            string no_weigth_docPwdKey = "docPresetDir";
            string baseUrl = "https://innerworkingsqa.inwk.com";//ConfigurationManager.AppSettings["edocBaseUri"];

            const string productDetailPageUrlPath = "/en-US/IW/Site-Settings/Start-Page/ProductDetails/" +
                                                    "?p=eDoc-IS_disabled.aspx&cat=11-28-07-04-2014-mon";//ConfigurationManager.AppSettings["edocProductPath"];

            const string getCustomizeDocumentForDocSessionUrl = "https://edocclient.inwk.com/iframeClient.aspx?" +
                                                                 "docCode=93a779b5-77c6-4748-b53a-e9f0a79448f3&" +
                                                                 "docPwd=3076f683-12e7-484e-9d5a-d40a4da8f406&addToCartButton=%20Approve/Checkout&" +
                                                                 "cancelButton=Cancel&updateButton=%20Approve/Checkout&approveWhenDone=true&" +
                                                                 "cssURL=https://innerworkingsqa.inwk.com/Templates/INWKB2B/Styles/eDocFormCustom.css&" +
                                                                 "postbackURL=https://innerworkingsqa.inwk.com:443%2fen-US%2fIW%2fSite-Settings%2fStart-Page%2fProductDetails%2f%3fp%3deDoc-IS_disabled.aspx%26cat%3d11-28-07-04-2014-mon&" +
                                                                 "isSubmitFromEdit=true";

            const string uploadImageUrl = "https://edocclient.inwk.com/WebCoreModule.ashx?__ac=1&" +
                                          "__ac_wcmid=RAWCIL&__ac_lib=Radactive.WebControls.ILoad&" +
                                          "__ac_key=RAWCCIL_251&__ac_sid=yve22cz2m4dayzgqya0fdvxa&" +
                                          "__ac_cn=&" +
                                          "__ac_ssid=85a35d38-dff2-4091-a209-b8e652801def&" +
                                          "fr=635472955978231135&doConfig=1&" +
                                          "__controlKey=f5fec5970b415c2ae53dadbc8f65edc6216d2718";

            const string updatePreviewUrl = "https://edocclient.inwk.com/iframeClient.aspx?" +
                                            "docCode=93a779b5-77c6-4748-b53a-e9f0a79448f3&" +
                                            "docPwd=3076f683-12e7-484e-9d5a-d40a4da8f406&" +
                                            "addToCartButton=+Approve%2fCheckout&" +
                                            "cancelButton=Cancel&updateButton=+Approve%2fCheckout&" +
                                            "approveWhenDone=true&" +
                                            "cssURL=https%3a%2f%2finnerworkingsqa.inwk.com%2fTemplates%2fINWKB2B%2fStyles%2feDocFormCustom.css&" +
                                            "postbackURL=https%3a%2f%2finnerworkingsqa.inwk.com%3a443%2fen-US%2fIW%2fSite-Settings%2fStart-Page%2fProductDetails%2f%3fp%3deDoc-IS_disabled.aspx%26cat%3d11-28-07-04-2014-mon&" +
                                            "isSubmitFromEdit=true&" +
                                            "RadUrid=8b08c3c7-7cd3-4a69-960a-ff6f392d49c5";

            const string approveAndCheckoutUrl = "https://edocclient.inwk.com/iframeClient.aspx?" +
                                                 "docCode=93a779b5-77c6-4748-b53a-e9f0a79448f3&" +
                                                 "docPwd=3076f683-12e7-484e-9d5a-d40a4da8f406&" +
                                                 "addToCartButton=+Approve%2fCheckout&" +
                                                 "cancelButton=Cancel&updateButton=+Approve%2fCheckout&" +
                                                 "approveWhenDone=true&" +
                                                 "cssURL=https%3a%2f%2finnerworkingsqa.inwk.com%2fTemplates%2fINWKB2B%2fStyles%2feDocFormCustom.css&" +
                                                 "postbackURL=https%3a%2f%2finnerworkingsqa.inwk.com%3a443%2fen-US%2fIW%2fSite-Settings%2fStart-Page%2fProductDetails%2f%3fp%3deDoc-IS_disabled.aspx%26cat%3d11-28-07-04-2014-mon&" +
                                                 "isSubmitFromEdit=true&" +
                                                 "RadUrid=5cc9cd08-d8ec-4b76-bf4c-dcd26809f05e";

            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(UrlHelper.Combine(baseUrl, productDetailPageUrlPath)));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(getCustomizeDocumentForDocSessionUrl));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(uploadImageUrl));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(updatePreviewUrl));
            Assert.IsTrue(PullEdocProductHelper.IsHttpStatusOK(approveAndCheckoutUrl));
        }
    }
}

