//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _03_Transactions.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using _03_Transactions.LocalResource;

    public partial class UserTransactions
    {
        public int TransactionId { get; set; }

        [Display(Name = "Transaction" )]
        public string TransactionName { get; set; }

        [Display(Name = "Amount")]
        public int Amount { get; set; }
    }
}
