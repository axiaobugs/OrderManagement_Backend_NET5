using System.Runtime.Serialization;

namespace orderManagement.Entities.Payment
{
    public enum PaymentStatus
    {
        [EnumMember(Value = "Received Deposit")]
        ReceivedDeposit,
        [EnumMember(Value = "Received Full Payment")]
        ReceivedFullPayment,
        [EnumMember(Value = "Request To Return")]
        RequestReturn,
        [EnumMember(Value = "Return Request Approval")]
        ReturnApproval,
        [EnumMember(Value = "Return Reject")]
        ReturnReject
    }
}