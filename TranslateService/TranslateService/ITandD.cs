using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TranslateService
{
    [ServiceContract(Namespace = "webclientvilhena.apphb.com")]
    public interface ITandD
    {
        [OperationContract]
        MeaningResp TraslateAndMeaning(WordReq wordReq);
    }

    [DataContract(Namespace = "webclientvilhena.apphb.com")]
    public class WordReq
    {
        [DataMember]
        public string Word { get; set; }
    }

    [DataContract(Namespace = "webclientvilhena.apphb.com")]
    public class MeaningResp
    {
        [DataMember]
        public string OriginalWord { get; set; }
        [DataMember]
        public string TranslatedWord { get; set; }
        [DataMember]
        public string[] Meanings { get; set; }
        [DataMember]
        public bool Translated { get; set; }
    }

}
