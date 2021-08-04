using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentGatewayIBMS.Models.Write
{
    public partial class TblAccount
    {
        public long IntAccountId { get; set; }
        public string StrOwnerName { get; set; }
        public string StrMobileNo { get; set; }
        public string StrEmail { get; set; }
        public string StrPassword { get; set; }
        public string StrBusinessLogo { get; set; }
        public string StrBusinessName { get; set; }
        public long IntOwnerNid { get; set; }
        public string StrBusinessEmail { get; set; }
        public string StrBusinessAddress { get; set; }
        public long? IntSmsBalance { get; set; }
        public string StrTradeLicense { get; set; }
        public long? IntLastmodifiedBy { get; set; }
        public long? IntCreatedBy { get; set; }
        public DateTime? DteLastModifiedDate { get; set; }
        public DateTime? DteCreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DteServerDateTime { get; set; }
    }
}
