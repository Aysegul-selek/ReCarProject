﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string Success = "İşlem Başarılı";
        public static string Error = "İşlem Başarısız";

        public static string ThisCarIsAlreadyRentedInSelectedDateRange { get; internal set; }
        public static string ReturnDateCannotBeEarlierThanRentDate { get; internal set; }
        public static string ThisCarHasNotBeenReturnedYet { get; internal set; }
        public static string ReturnDateCannotBeLeftBlankAsThisCarWasAlsoRentedAtALaterDate { get; internal set; }
        public static string RentalDateCannotBeBeforeToday { get; internal set; }
        public static string CustomerFindeksPointIsNotEnoughForThisCar { get; internal set; }
        public static string CarNotFound { get; internal set; }
        public static string PaymentDenied { get; internal set; }
        public static string PaymentSuccessful { get; internal set; }
        public static string ThisCardIsAlreadyRegisteredForThisCustomer { get; internal set; }
    }
}
