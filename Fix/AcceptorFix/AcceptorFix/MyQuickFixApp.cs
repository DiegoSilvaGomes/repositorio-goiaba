using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickFix;
using QuickFix.Fields;

namespace AcceptorFix
{
    public class MyQuickFixApp : MessageCracker, IApplication
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static List<string> MsgList { get; set; }
        public void OnMessage(QuickFix.FIX44.NewOrderSingle ord, SessionID sessionID)
        {
            var order = new NewOrder();

            var msgSplit = ord.ToString().Split("");

            for (var i = 0; i < msgSplit.Length - 1; i++)
            {
                var position = msgSplit[i].IndexOf("=");
                string type = msgSplit[i].Substring(0, position);

                switch (type)
                {
                    case "8": order.BeginString = msgSplit[i].Substring(position + 1); break;
                    case "9": order.BodyLength = msgSplit[i].Substring(position + 1); break;
                    case "35": order.MsgType = msgSplit[i].Substring(position + 1); break;
                    case "34": order.MsgSeqNum = msgSplit[i].Substring(position + 1); break;
                    case "49": order.SenderCompID = msgSplit[i].Substring(position + 1); break;
                    case "56": order.TargetCompID = msgSplit[i].Substring(position + 1); break;
                    case "52": order.SendingTime = msgSplit[i].Substring(position + 1); break;
                    case "10": order.CheckSum = msgSplit[i].Substring(position + 1); break;
                    case "98": order.EncryptedMethod = msgSplit[i].Substring(position + 1); break;
                    case "108": order.HeartBtInt = msgSplit[i].Substring(position + 1); break;
                    case "112": order.TestReqID = msgSplit[i].Substring(position + 1); break;
                    case "7": order.BeginSeqNo = msgSplit[i].Substring(position + 1); break;
                    case "16": order.EndSeqNo = msgSplit[i].Substring(position + 1); break;
                    case "11": order.ClOrdID = msgSplit[i].Substring(position + 1); break;
                    case "21": order.HandlInst = msgSplit[i].Substring(position + 1); break;
                    case "55": order.Symbol = msgSplit[i].Substring(position + 1); break;
                    case "54": order.Side = msgSplit[i].Substring(position + 1); break;
                    case "60": order.TransactTime = msgSplit[i].Substring(position + 1); break;
                    case "40": order.OrdType = msgSplit[i].Substring(position + 1); break;
                    case "44": order.Price = msgSplit[i].Substring(position + 1); break;
                    case "38": order.OrderQty = msgSplit[i].Substring(position + 1); break;
                    case "453": order.NoPartyIDs = msgSplit[i].Substring(position + 1); break;

                }

            }

            logger.Info(order);
        }

        protected void ProcessOrder(Price price, OrderQty quantity, Account account)
        {

        }
        public void FromApp(Message msg, SessionID sessionID)
        {
            Crack(msg, sessionID);
        }
        public void OnCreate(SessionID sessionID) { }
        public void OnLogout(SessionID sessionID) { }
        public void OnLogon(SessionID sessionID) { }
        public void FromAdmin(Message msg, SessionID sessionID) { }
        public void ToAdmin(Message msg, SessionID sessionID)
        {
            // Console.WriteLine("OUT: " + msg);
        }
        public void ToApp(Message msg, SessionID sessionID) { }
    }
}
