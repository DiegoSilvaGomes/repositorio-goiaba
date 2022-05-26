using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptorFix
{
    public class NewOrder
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string BeginString { get; set; }
        public string BodyLength { get; set; }
        public string MsgType { get; set; }
        public string MsgSeqNum { get; set; }
        public string SenderCompID { get; set; }
        public string TargetCompID { get; set; }
        public string SendingTime { get; set; }
        public string CheckSum { get; set; }
        public string EncryptedMethod { get; set; }
        public string HeartBtInt { get; set; }
        public string TestReqID { get; set; }
        public string BeginSeqNo { get; set; }
        public string EndSeqNo { get; set; }
        public string ClOrdID { get; set; }
        public string HandlInst { get; set; }
        public string Symbol { get; set; }
        public string Side { get; set; }
        public string TransactTime { get; set; }
        public string OrdType { get; set; }
        public string Price { get; set; }
        public string OrderQty { get; set; }
        public string NoPartyIDs { get; set; }
    }
}

