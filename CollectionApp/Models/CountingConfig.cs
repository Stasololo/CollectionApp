using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class CountingConfig : GenericClass
    {
        public string Name { get; set; }
        public int TypeDeposit { get; set; }
        public int DateDeposit { get; set; }
        public int DateCollect { get; set; }
        public int DatePayment { get; set; }
        public int DatePacking { get; set; }
        public int Bag { get; set; }
        public int Wallet { get; set; }
        public int Currency { get; set; }

        public int Deposit1 { get; set; }
        public int Deposit2 { get; set; }
        public int Deposit3 { get; set; }
        public int Deposit4 { get; set; }
        public int Deposit5 { get; set; }
        public int Deposit6 { get; set; }
        public int Deposit7 { get; set; }

        public int DeclaredNote { get; set; }
        public int DeclaredCoin { get; set; }
        public int DeclaredOther { get; set; }

        public int OpenCard { get; set; }
        public int DateDepositNull { get; set; }
        public int DateCollectNull { get; set; }
        public int DatePaymentNull { get; set; }
        public int DatePackingNull { get; set; }
        public int BagNull { get; set; }
        public int WalletNull { get; set; }
        public int CurrencyNull { get; set; }

        public int Deposit1Null { get; set; }
        public int Deposit2Null { get; set; }
        public int Deposit3Null { get; set; }
        public int Deposit4Null { get; set; }
        public int Deposit5Null { get; set; }
        public int Deposit6Null { get; set; }
        public int Deposit7Null { get; set; }

        public int DeclaredNoteNull { get; set; }
        public int DeclaredCoinNull { get; set; }
        public int DeclaredOtherNull { get; set; }
        public int OpenCardNull { get; set; }
    }
}