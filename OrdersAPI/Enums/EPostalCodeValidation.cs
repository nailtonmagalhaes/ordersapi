using System.ComponentModel;

namespace OrdersAPI.Enums
{
    public enum EPostalCodeValidation
    {
        [Description("Postal code was not provided")]
        PostalCodeNotProvided,
        [Description("The postal code entered is invalid")]
        InvalidPostalCodeEntered,
        [Description("The postal code is valid")]
        ValidPostalCode
    }
}