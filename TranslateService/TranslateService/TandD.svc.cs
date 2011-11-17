using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using TranslateService.api.microsofttranslator.com;
using TranslateService.services.aonaware.com;

namespace TranslateService
{
    [ServiceBehavior(Namespace = "webclientvilhena.apphb.com")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TandD : ITandD
    {
        private const string Apiid = "C1E6D88CE2967328BBA9BC6C932B9D177247CAE5";
        private static readonly LanguageServiceClient LanguageServiceClient = new LanguageServiceClient();
        private static readonly DictServiceSoapClient DictServiceSoapClient= new DictServiceSoapClient("DictServiceSoap12");

        public MeaningResp TraslateAndMeaning(WordReq wordReq)
        {
            var resp = new MeaningResp {OriginalWord = wordReq.Word};

            string translation = GetTranslation(wordReq);
            resp.Translated = resp.OriginalWord != translation;
            if (resp.Translated)
            {
                resp.TranslatedWord = translation;
                resp.Meanings = GetMeans(translation);
            }
            return resp;
        }

        private static string[] GetMeans(string translation)
        {
            return DictServiceSoapClient.Define(translation)
                .Definitions
                .Select(definition => definition.WordDefinition)
                .ToArray();
        }

        private static string GetTranslation(WordReq wordReq)
        {
            var languageService = new LanguageServiceClient();
            return LanguageServiceClient.Translate(Apiid, wordReq.Word, "pt", "en", "text/html", "general");
        }
    }
}
